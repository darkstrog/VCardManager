using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PhoneBookManager.Services
{
    class ImageDialogService : IDialogService
    {
        public string[] FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileNames;
                return true;
            }

            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            saveFileDialog.DefaultExt = "*.jpg";

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileNames;
                return true;
            }

            return false;
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
