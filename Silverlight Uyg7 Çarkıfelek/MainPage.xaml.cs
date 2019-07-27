using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight_Uyg7_Çarkıfelek
{
    public partial class MainPage : UserControl
    {
        ObservableCollection<Kelimeler> Kelime = new ObservableCollection<Kelimeler>();
       
        
        public MainPage()
        {
            InitializeComponent();
            Kelime.Add(new Kelimeler() { Kategori = "Ünlü", Kelime = "FARUK BEY" });
            Kelime.Add(new Kelimeler() { Kategori = "Ünlü", Kelime = "ALI" });
            Kelime.Add(new Kelimeler() { Kategori = "Ünlü", Kelime = "BERKE ABI" });
            Kelime.Add(new Kelimeler() { Kategori = "Şehir", Kelime = "ISTANBUL" });
            Kelime.Add(new Kelimeler() { Kategori = "Şehir", Kelime = "IZMIR" });
            Kelime.Add(new Kelimeler() { Kategori = "Şehir", Kelime = "ANKARA" });
            Kelime.Add(new Kelimeler() { Kategori = "Şehir", Kelime = "ANTALYA" });
            Kelime.Add(new Kelimeler() { Kategori = "Çizgi Film", Kelime = "TOM VE JERRY" });
            Kelime.Add(new Kelimeler() { Kategori = "Film", Kelime = "LOGAN" });
            Kelime.Add(new Kelimeler() { Kategori = "Takım", Kelime = "FENERBAHÇE" });
            Kelime.Add(new Kelimeler() { Kategori = "Film", Kelime = "STAR WARS" });
            Kelimeseç();
            
        }
        
        private void Kelimeseç()
        {
            Random rnd = new Random();
            Kelimeler seçılıkelime = Kelime[rnd.Next(0, 10)];
            
            for (int i = 0; i < seçılıkelime.Kelime.Length; i++)
            {
                
                char[] harfler = seçılıkelime.Kelime.ToCharArray();
                if (seçılıkelime.Kelime[i] != ' ')
                {
                    Label a = new Label()
                    {
                        
                        Width = 60,
                        Height = 30,
                        Margin= new Thickness(3),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Tag=seçılıkelime.Kelime[i],
                        Background = new SolidColorBrush(Colors.DarkGray),
                        BorderBrush = new SolidColorBrush(Colors.Black),
                        BorderThickness = new Thickness(2),


                    };
                    
                    sp.Children.Add(a);
                }
                else
                {
                    Label çerçeve = new Label()
                    {
                        Width=30,
                        Tag=""

                    };
                    sp.Children.Add(çerçeve);
                }
            };
            tbka.Text = seçılıkelime.Kategori;

        }
        
        int tıkla = 0;
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tıkla==0)
            {
                Storyboard1.Begin();
                sptahmin.Visibility = Visibility.Collapsed;
                tıkla++;
            }
            else if (tıkla==1)
            {
                Storyboard1.Pause();
                sptahmin.Visibility = Visibility.Visible;
                tıkla++;
            }
            else if (tıkla==2)
            {
                Storyboard1.Resume();
                sptahmin.Visibility = Visibility.Collapsed;
                tıkla = 1;
            }
        }
        bool hareket = true;
        bool geldimi = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            geldimi = false;
            foreach (Label item in sp.Children)
            {
                if (tbtahmin.Text==item.Tag.ToString() && item.Tag.ToString()!= "")
                {
                    geldimi = true;
                    
                    
                    item.Background = new SolidColorBrush(Colors.White);
                    item.Content = item.Tag;
                    sptahmin.Visibility = Visibility.Collapsed;
                }
                else if (tbtahmin.Text != item.Tag.ToString())
                {
                    sptahmin.Visibility = Visibility.Collapsed;
                }
            }
            if (hareket == true && geldimi == true)
            {
                Storyboard2.Begin();
                hareket = false;

            }
            else if (geldimi == true)
            {
                Storyboard3.Begin();
                hareket = true;
            }

        }
    }
}
