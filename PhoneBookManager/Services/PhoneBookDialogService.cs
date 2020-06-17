using Microsoft.Win32;
using System.Windows;

namespace PhoneBookManager.Services
{
    class PhoneBookDialogService : IDialogService
    {
        public string[] FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл визитной карточки|*.vcf";
            openFileDialog.DefaultExt = "*.vcf";
            openFileDialog.Multiselect = true;
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
            saveFileDialog.Filter = "Файл визитной карточки|*.vcf";
            saveFileDialog.DefaultExt = "*.vcf";
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
