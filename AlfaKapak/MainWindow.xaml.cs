using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;

namespace AlfaKapak
{
    public partial class MainWindow : Window
    {
        private ImagesClass imagesClass = new ImagesClass();

        public MainWindow()
        {
            InitializeComponent();
        }

        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";
            string selectedImagePath = "";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;
            }

            return selectedImagePath;
        }

        private void btnBgImage_Click(object sender, RoutedEventArgs e)
        {
            imagesClass.BgPath = OpenFileDialog();
            if (!string.IsNullOrEmpty(imagesClass.BgPath))
            {
                btnBgImage.Background = Brushes.Green;
            }
            else
            {
                btnBgImage.Background = Brushes.Red;
            }
        }

        private void btnSmall1_Click(object sender, RoutedEventArgs e)
        {
            imagesClass.SmallPath1 = OpenFileDialog();
            if (!string.IsNullOrEmpty(imagesClass.BgPath))
            {
                btnSmall1.Background = Brushes.Green;
            }
            else
            {
                btnSmall1.Background = Brushes.Red;
            }
        }

        private void btnSmall2_Click(object sender, RoutedEventArgs e)
        {
            imagesClass.SmallPath2 = OpenFileDialog();
            if (!string.IsNullOrEmpty(imagesClass.BgPath))
            {
                btnSmall2.Background = Brushes.Green;
            }
            else
            {
                btnSmall2.Background = Brushes.Red;
            }
        }

        private void btnAddFeatures_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxFeatureAdd.Text))
            {
                if (lbxFeatures.Items.Count < 5)
                {
                    lbxFeatures.Items.Add(tbxFeatureAdd.Text);
                    tbxFeatureAdd.Clear();
                }
                else
                {
                    MessageBox.Show("En fazla 5 öğe ekleyebilirsiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen eklenecek özelliği yazın.");
            }
        }


        private void btnHazirla_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTextBoxes() && CheckPaths())
            {
                List<string> listBoxValues = lbxFeatures.Items.Cast<string>().ToList();
                imagesClass.Features = listBoxValues;
                imagesClass.Title = tbxMainTitle.Text;
                imagesClass.LittleTitle = tbxLittleTitle.Text;
                Görüntü görüntü = new Görüntü(imagesClass);
                görüntü.Show();
            }
        }

        private bool CheckPaths()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(imagesClass.BgPath))
            {
                MessageBox.Show("Arka plan resmi seçilmemiş.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(imagesClass.SmallPath1))
            {
                MessageBox.Show("Küçük Resim 1 seçilmemiş.");
                isValid = false;
            }

            if (string.IsNullOrEmpty(imagesClass.SmallPath2))
            {
                MessageBox.Show("Küçük Resim 2 seçilmemiş.");
                isValid = false;
            }

            return isValid;
        }


        private bool CheckTextBoxes()
        {
            if (string.IsNullOrEmpty(tbxMainTitle.Text) || string.IsNullOrEmpty(tbxLittleTitle.Text))
            {
                MessageBox.Show("Başlık ve alt başlık boş olamaz.");
                return false;
            }
            return true;
        }

        private void btnRemoveFeature_Click(object sender, RoutedEventArgs e)
        {
            if (lbxFeatures.SelectedItem != null)
            {
                lbxFeatures.Items.Remove(lbxFeatures.SelectedItem);
            }
            else
            {
                MessageBox.Show("Kaldırmak istediğiniz özelliği listeden seçiniz.");
            }
        }

        private void tbxMainTitle_Kopyala_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxMainTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
