using MixERP.Net.VCards;
using PhoneBookManager.Services;
using PhoneBookManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBookManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var _mainWindow = new VCardsViewModel(new PhoneBookDialogService(), new VCardFileService(), new ImageDialogService());
            DataContext = new RootViewModel() {RootVM=_mainWindow };
        }
        public MainWindow(string fileName)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
            {
                try
                {
                    var _mainWindow = new VCardsViewModel(new PhoneBookDialogService(), new VCardFileService(), new ImageDialogService(),new string[] { fileName });
                    DataContext = new RootViewModel() { RootVM = _mainWindow };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    var _mainWindow = new VCardsViewModel(new PhoneBookDialogService(), new VCardFileService(), new ImageDialogService());
                    DataContext = new RootViewModel() { RootVM = _mainWindow };
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
        }

        private void RootWindow_DragEnter(object sender, DragEventArgs e)
        {
        }
    }
}
