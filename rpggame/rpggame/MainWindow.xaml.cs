﻿using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace rpggame
{
    public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void VeletlenNev_Click(object sender, RoutedEventArgs e)
    {
        var nevek = File.ReadAllLines("nevek.txt");
        var random = new Random();
        NevMezo.Text = nevek[random.Next(nevek.Length)];
    }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            var karakter = $"{NevMezo.Text};" +
                        $"{(FajLista.SelectedItem as ComboBoxItem)?.Content.ToString()};" +
                        $"{(KasztLista.SelectedItem as ComboBoxItem)?.Content.ToString()};" +
                        $"{EroMezo.Text};" +
                        $"{UgyessegMezo.Text};" +
                        $"{EleteroMezo.Text};" +
                        $"{MagiaMezo.Text}";

           
            File.AppendAllText("karakterek.txt", karakter + Environment.NewLine);
            MessageBox.Show("Karakter mentve!");
        }

            private void Betoltes_Click(object sender, RoutedEventArgs e)
    {
        if (File.Exists("karakter.json"))
        {
            var karakter = JsonSerializer.Deserialize<dynamic>(File.ReadAllText("karakter.json"));

            NevMezo.Text = karakter.Nev;
            FajLista.SelectedItem = FajLista.Items[0];
            foreach (ComboBoxItem item in FajLista.Items)
                if (item.Content.ToString() == karakter.Faj.ToString())
                    FajLista.SelectedItem = item;

            KasztLista.SelectedItem = KasztLista.Items[0];
            foreach (ComboBoxItem item in KasztLista.Items)
                if (item.Content.ToString() == karakter.Kaszt.ToString())
                    KasztLista.SelectedItem = item;

            EroMezo.Text = karakter.Ero;
            UgyessegMezo.Text = karakter.Ugyesseg;
            EleteroMezo.Text = karakter.Eletero;
            MagiaMezo.Text = karakter.Magia;
        }
        else
        {
            MessageBox.Show("Nincs elmentett karakter!");
        }
    }
}
}
