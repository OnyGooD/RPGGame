using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                MessageBox.Show($"Hiba történt a karakterek betöltésekor: {ex.Message}");
            }
        }

        private void CharacterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterListBox.SelectedItem is Character selectedCharacter)
            {
                CharacterDetails.Text = $"Név: {selectedCharacter.Nev}\n" +
                                        $"Faj: {selectedCharacter.Faj}\n" +
                                        $"Kaszt: {selectedCharacter.Kaszt}\n" +
                                        $"Erő: {selectedCharacter.Ero}\n" +
                                        $"Ügyesség: {selectedCharacter.Ugyesseg}\n" +
                                        $"Életerő: {selectedCharacter.Eletero}\n" +
                                        $"Mágia: {selectedCharacter.Magia}";
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
                MessageBox.Show($"{selectedCharacter.Nev} harcra kész!", "Harc");
            }
            else
            {
                MessageBox.Show("Válassz egy karaktert a harc megkezdéséhez!", "Figyelmeztetés");
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
        public string Kep { get; set; }
    }
}