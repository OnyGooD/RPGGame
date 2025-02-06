using System;
using System.Windows;

namespace FightSystem
{
    public partial class MainWindow : Window
    {
        private Character player;
        private Character enemy;
        private Random rnd = new Random();
        private int roundCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            ProcessCommandLineArguments();
            InitializeEnemy();
            UpdateUI();
            AppendCombatLog("⚔️ A harc kezdete! ⚔️");
        }

        private void ProcessCommandLineArguments()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string characterData = args[1];
                string[] parts = characterData.Split(';');
                if (parts.Length == 7)
                {
                    try
                    {
                        player = new Character
                        {
                            Nev = parts[0],
                            Faj = parts[1],
                            Kaszt = parts[2],
                            Ero = int.Parse(parts[3]),
                            Ugyesseg = int.Parse(parts[4]),
                            Eletero = 100,
                            Magia = int.Parse(parts[6])
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba az adatok feldolgozásakor: {ex.Message}");
                        Application.Current.Shutdown();
                    }
                }
                else
                {
                    MessageBox.Show("Hibás karakteradatok érkeztek!");
                    Application.Current.Shutdown();
                }
            }
            else
            {
                MessageBox.Show("Nem érkeztek karakteradatok!");
                Application.Current.Shutdown();
            }
        }

        private void InitializeEnemy()
        {
            enemy = new Character
            {
                Nev = "Goblin",
                Faj = "Szörny",
                Kaszt = "Harcos",
                Ero = rnd.Next(3, 8),
                Ugyesseg = rnd.Next(3, 8),
                Eletero = 100,
                Magia = rnd.Next(1, 5)
            };
        }

        private void UpdateUI()
        {
            if (player != null)
            {
                PlayerNameText.Text = $"Név: {player.Nev}";
                PlayerHealthText.Text = $"Életerő: {player.Eletero}";
                PlayerStatsText.Text = $"Erő: {player.Ero} | Ügyesség: {player.Ugyesseg} | Mágia: {player.Magia}";
            }
            if (enemy != null)
            {
                EnemyNameText.Text = $"Név: {enemy.Nev}";
                EnemyHealthText.Text = $"Életerő: {enemy.Eletero}";
                EnemyStatsText.Text = $"Erő: {enemy.Ero} | Ügyesség: {enemy.Ugyesseg} | Mágia: {enemy.Magia}";
            }
        }

        private void AppendCombatLog(string text)
        {
            CombatLogTextBox.AppendText($"{text}\n");
            CombatLogTextBox.ScrollToEnd();
        }

        private int RollDice(int sides = 20)
        {
            return rnd.Next(1, sides + 1);
        }

        private int CalculateDamage(Character attacker, Character defender, int diceRoll)
        {
            int damage = attacker.Ero + diceRoll - defender.Ugyesseg;
            return damage > 0 ? damage : 0;
        }

        private void NextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (player.Eletero <= 0 || enemy.Eletero <= 0)
            {
                AppendCombatLog("🛑 A harc már véget ért!");
                return;
            }

            roundCounter++;
            AppendCombatLog($"\n--- {roundCounter}. Kör: Harc kezdete! ⚔️🔥 ---");

            int playerDice = RollDice();
            int playerDamage = CalculateDamage(player, enemy, playerDice);
            string playerAttackMessage = $"🗡️ {player.Nev} dobott {playerDice}, sebzése: {playerDamage}";
            if (playerDice == 20)
            {
                playerAttackMessage += " ⚡ KRITIKUS TALÁLAT! ⚡";
            }
            AppendCombatLog(playerAttackMessage);
            enemy.Eletero -= playerDamage;
            if (enemy.Eletero < 0) enemy.Eletero = 0;

            if (enemy.Eletero > 0)
            {
                int enemyDice = RollDice();
                int enemyDamage = CalculateDamage(enemy, player, enemyDice);
                string enemyAttackMessage = $"🔪 {enemy.Nev} dobott {enemyDice}, sebzése: {enemyDamage}";
                if (enemyDice == 20)
                {
                    enemyAttackMessage += " ⚡ KRITIKUS TALÁLAT! ⚡";
                }
                AppendCombatLog(enemyAttackMessage);
                player.Eletero -= enemyDamage;
                if (player.Eletero < 0) player.Eletero = 0;
            }

            UpdateUI();

            if (player.Eletero == 0 || enemy.Eletero == 0)
            {
                string result = player.Eletero == 0 ? "💀 Vesztettél!" : "🏆 Nyertél!";
                AppendCombatLog($"\nHarc vége: {result}");
                NextRoundButton.IsEnabled = false;
            }
        }
    }

    public class Character
    {
        public string Nev { get; set; }
        public string Faj { get; set; }
        public string Kaszt { get; set; }
        public int Ero { get; set; }
        public int Ugyesseg { get; set; }
        public int Eletero { get; set; }
        public int Magia { get; set; }
    }
}
