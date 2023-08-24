using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlfaKapak
{
    /// <summary>
    /// Görüntü.xaml etkileşim mantığı
    /// </summary>
    public partial class Görüntü : Window
    {
        public Görüntü(ImagesClass ımages)
        {

            InitializeComponent();
            BitmapImage BgImageB = new BitmapImage(new Uri(ımages.BgPath));
            BitmapImage SmallImage2B = new BitmapImage(new Uri(ımages.SmallPath2));
            BitmapImage SmallImage1B = new BitmapImage(new Uri(ımages.SmallPath1));

            SmallImage1.Source = SmallImage1B;
            SmallImage2.Source = SmallImage2B;
            BgImage.Source = BgImageB;
            MainTitle.Content = ımages.Title;
            LittleTitle.Content = ımages.LittleTitle;

            foreach (string property in ımages.Features)
            {
                StackPanel itemStackPanel = new StackPanel();
                itemStackPanel.Orientation = Orientation.Horizontal;

                Image iconImage = new Image();
                iconImage.Source = new BitmapImage(new Uri("/AlfaKapak;component/TickIcon.png", UriKind.Relative));
                iconImage.Width = 16;
                iconImage.Height = 16;

                Label label = new Label();
                label.Content = property;
                label.FontFamily = new FontFamily("Bebas Neue");
                label.FontSize = 23;
                Color color = (Color)ColorConverter.ConvertFromString("#222753");
                SolidColorBrush brush = new SolidColorBrush(color);
                label.Foreground = brush;

                itemStackPanel.Children.Add(iconImage);
                itemStackPanel.Children.Add(label);

                labelStackPanel.Children.Add(itemStackPanel);
            }

        }
    }
}
