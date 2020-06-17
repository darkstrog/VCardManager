using PhoneBookManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBookManager.View
{
    /// <summary>
    /// Логика взаимодействия для MainLayout.xaml
    /// </summary>
    public partial class MainLayout : UserControl
    {
        public MainLayout()
        {
            InitializeComponent();
        }

        private void ListCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _contacts = ((VCardsViewModel)DataContext).SelectedContacts;
            var _sender = sender as ListView;
            if (_sender != null)
            {
                _contacts.Clear();
                foreach (var item in _sender.SelectedItems)
                {
                    _contacts.Add((VCardViewModel)item);
                }
            }
            else
            {
                _contacts.Clear();
            }
        }

        private void ListCards_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ((VCardsViewModel)DataContext).OpenFile(files);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
        }
    }
}
