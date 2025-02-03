using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace rpgharc
{
    public partial class MainWindow : Window
    {
        private List<Character> characters;

        public MainWindow()
        {
            InitializeComponent();
            LoadCharacters();
        }

        private void LoadCharacters()
        {
            try
            {
                // Feltételezzük, hogy a "karakterek.txt" a következő formátumú:
                // "nev;faj;kaszt;ero;ugyesseg;eletero;magia"
                // majd a sorok: "Beni;Ember;Harcos;5;5;5;3"
                string[] lines = File.ReadAllLines("karakterek.txt");
                characters = lines.Skip(1)
                    .Select(line =>
                    {
                        var parts = line.Split(';');
                        return new Character
                        {
                            Nev = parts[0],
                            Faj = parts[1],
                            Kaszt = parts[2],
                            Ero = int.Parse(parts[3]),
                            Ugyesseg = int.Parse(parts[4]),
                            Eletero = int.Parse(parts[5]),
                            Magia = int.Parse(parts[6]),
                            Kep = $"images/{parts[1].ToLower()}_{parts[2].ToLower()}.png"
                        };
                    }).ToList();
                CharacterListBox.ItemsSource = characters;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a karakterek betöltésekor: {ex.Message}");
            }
        }

        private void CharacterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterListBox.SelectedItem is Character selectedCharacter)
            {
                CharacterDetails.Text = $"🧙‍♂️ Név: {selectedCharacter.Nev}\n" +
                                          $"⚔ Faj: {selectedCharacter.Faj}\n" +
                                          $"🏹 Kaszt: {selectedCharacter.Kaszt}\n" +
                                          $"💪 Erő: {selectedCharacter.Ero}\n" +
                                          $"🤸‍♂️ Ügyesség: {selectedCharacter.Ugyesseg}\n" +
                                          $"❤️ Életerő: {selectedCharacter.Eletero}\n" +
                                          $"✨ Mágia: {selectedCharacter.Magia}";
                try
                {
                    CharacterImage.Source = new BitmapImage(new Uri(selectedCharacter.Kep, UriKind.Relative));
                }
                catch
                {
                    CharacterImage.Source = null;
                }
            }
        }

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterListBox.SelectedItem is Character selectedCharacter)
            {
                // A karakter adatait egy sorban összekomponáljuk, például:
                // "nev;faj;kaszt;ero;ugyesseg;eletero;magia"
                string characterData = $"{selectedCharacter.Nev};{selectedCharacter.Faj};{selectedCharacter.Kaszt};" +
                                       $"{selectedCharacter.Ero};{selectedCharacter.Ugyesseg};{selectedCharacter.Eletero};{selectedCharacter.Magia}";
                // Frissítsd az elérési utat a harcrendszeres alkalmazás exe-jéhez!
                string fightAppPath = @"C:\Users\Tamás\Desktop\rpgprojekt\RPGGame\rpgharc\FightSystem.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo(fightAppPath, characterData);
                Process.Start(startInfo);

                // Vizuális visszajelzés animációval:
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.5,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                    AutoReverse = true
                };
                FightButton.BeginAnimation(Button.OpacityProperty, animation);
            }
            else
            {
                MessageBox.Show("Válassz egy karaktert a harc megkezdéséhez!", "Figyelmeztetés");
            }
        }
    }

    // Karakter osztály – ezt akár közös library-ben is tarthatod, ha mindkét projekt használja
    public class Character
    {
        public string Nev { get; set; }
        public string Faj { get; set; }
        public string Kaszt { get; set; }
        public int Ero { get; set; }
        public int Ugyesseg { get; set; }
        public int Eletero { get; set; }
        public int Magia { get; set; }
        public string Kep { get; set; }
    }
}
