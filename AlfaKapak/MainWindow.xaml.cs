using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace AlfaKapak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ImagesClass ımagesClass = new ImagesClass();
        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";
            string selectedImagePath = "";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;
                // Seçilen resim yolunu kullanabilirsiniz
                // Örneğin: YourImageControl.Source = new BitmapImage(new Uri(selectedImagePath));
            }
            return selectedImagePath;
        }
        private void btnBgImage_Click(object sender, RoutedEventArgs e)
        {
            ımagesClass.BgPath = OpenFileDialog();
        }

        private void btnSmall1_Click(object sender, RoutedEventArgs e)
        {
            ımagesClass.SmallPath1 = OpenFileDialog();
        }

        private void btnSmall2_Click(object sender, RoutedEventArgs e)
        {
            ımagesClass.SmallPath2 = OpenFileDialog();
        }

        private void btnAddFeatures_Click(object sender, RoutedEventArgs e)
        {
            lbxFeatures.Items.Add(String.IsNullOrEmpty(tbxFeatureAdd.Text) == true ? MessageBox.Show("Lütfen Eklenecek Özelliği Yazın") : tbxFeatureAdd.Text);
        }

        private void btnHazirla_Click(object sender, RoutedEventArgs e)
        {
            List<string> listBoxValues = lbxFeatures.Items.Cast<string>().ToList();
            ımagesClass.Features = listBoxValues;
            ımagesClass.Title = tbxMainTitle.Text;
            ımagesClass.LittleTitle = tbxLittleTitle.Text;
            Görüntü görüntü = new Görüntü(ımagesClass);
            görüntü.Show();
        }

        private void btnRemoveFeature_Click(object sender, RoutedEventArgs e)
        {
            lbxFeatures.Items.Remove(lbxFeatures.SelectedItem == null ? MessageBox.Show("Kaldırmak İstediğini Özelliği Listeden Seçiniz") : lbxFeatures.SelectedItem);
        }

        private void tbxMainTitle_Kopyala_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxMainTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
