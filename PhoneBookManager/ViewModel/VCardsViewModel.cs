using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using PhoneBookManager.Core.Extensions;
using PhoneBookManager.Extensions;
using PhoneBookManager.MVVM;
using PhoneBookManager.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PhoneBookManager.ViewModel
{
    class VCardsViewModel : ViewModelBase
    {
        readonly IFileService fileService;
        readonly IDialogService dialogService;
        readonly IDialogService imageDialogService;

        public ObservableCollection<VCardViewModel> ContactsList { get; set; }
        private readonly CollectionViewSource contactsSource;
        public ICollectionView ContactsSource
        {
            get
            {
                return this.contactsSource.View;
            }
        }

        private ObservableCollection<VCardViewModel> _selectedContacts;
        public ObservableCollection<VCardViewModel> SelectedContacts
        {
            get
            {
                return _selectedContacts;
            }
            set
            {
                {
                    _selectedContacts = value;
                    OnPropertyChanged("SelectedContacts");
                }
            }
        }

        private VCardViewModel _currentContact;
        public VCardViewModel CurrentContact
        {
            get
            {
                return _currentContact;
            }
            set
            {
                if (_currentContact != value)
                {    
                    _currentContact = value;
                    OnPropertyChanged("CurrentContact");
                }
            }
        }

        #region commands
        private RelayCommand clearListCommand;
        public RelayCommand ClearListCommand
        {
            get
            {
                return clearListCommand ??
                        (clearListCommand = new RelayCommand(obj => ContactsList.Clear(),
                                                             x => { return ContactsList.Count > 0; })
                );
            }
        }

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                        (openCommand = new RelayCommand(obj =>
                        {
                            try
                            {
                                if (dialogService.OpenFileDialog() == true)
                                {
                                    var paths = dialogService.FilePath;
                                    OpenFile(paths);
                                }
                            }
                            catch (Exception ex)
                            {
                                dialogService.ShowMessage(ex.Message);
                            }
                        }
                    ));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                        (saveCommand = new RelayCommand(obj =>
                        {
                            try
                            {
                                if (dialogService.SaveFileDialog() == true)
                                {
                                    var path = dialogService.FilePath[0];
                                    var vcard = new List<VCard> { CurrentContact.Card };
                                    fileService.Save(path, vcard);
                                }
                            }
                            catch (Exception ex)
                            {
                                dialogService.ShowMessage(ex.Message);
                            }
                        },
                        x =>  { return CurrentContact?.Card==null? false:true; }
                    ));
            }
        }

        private RelayCommand saveAllInOneCommand;
        public RelayCommand SaveAllInOneCommand
        {
            get
            {
                return saveAllInOneCommand ??
                        (saveAllInOneCommand = new RelayCommand(obj =>
                        {
                            try
                            {
                                if (dialogService.SaveFileDialog() == true)
                                {
                                    var path = dialogService.FilePath[0];
                                    var vcard = ContactsList.Select(x => x.Card).ToList();
                                    fileService.Save(path, vcard);
                                }
                            }
                            catch (Exception ex)
                            {
                                dialogService.ShowMessage(ex.Message);
                            }
                        },
                        x => { return ContactsList.Count > 0; }
                    ));
            }
        }

        private RelayCommand saveAllCommand;
        public RelayCommand SaveAllCommand
        {
            get
            {
                return saveAllCommand ??
                        (saveAllCommand = new RelayCommand(obj =>
                        {
                            try
                            {
                                if (dialogService.SaveFileDialog() == true)
                                {
                                    var path = dialogService.FilePath[0];
                                    var vcard = ContactsList.Select(x => x.Card).ToList();
                                    fileService.SaveAll(path, vcard);
                                }
                            }
                            catch (Exception ex)
                            {
                                dialogService.ShowMessage(ex.Message);
                            }
                        },
                        x => { return ContactsList.Count > 0; }
                    ));
            }
        }

        private RelayCommand addVcardCommand;
        public RelayCommand AddVcardCommand
        {
            get
            {
                return addVcardCommand ??
                        (addVcardCommand = new RelayCommand(obj => ContactsList.Add(new VCardViewModel(imageDialogService))));
            }
        }

        private RelayCommand delSelectedCommand;
        public RelayCommand DelSelectedCommand
        {
            get
            {
                return delSelectedCommand ??
                        (delSelectedCommand = new RelayCommand(obj =>
                        {
                            if (SelectedContacts!=null)
                            {
                                while (SelectedContacts.Count>0)
                                {
                                    ContactsList.Remove((VCardViewModel)SelectedContacts[0]);
                                }
                            }
                        },x=> { return SelectedContacts.Count>0; }));
            }
        }

        private RelayCommand searchDublicateNumbersCommand;
        public RelayCommand SearchDublicateNumbersCommand
        {
           get
            {
                return searchDublicateNumbersCommand ??
                    (searchDublicateNumbersCommand = new RelayCommand(obj =>
                    {
                        if ((bool)obj)
                        {
                            contactsSource.Filter += VcardCollectionDublicates_Filter;
                            DublicatesNumbers = CurrentContact?.Card?.Telephones?.Select(item => item.Number)?.ToList();
                            ContactsSource.SortDescriptions.Add(new SortDescription("FormattedName", ListSortDirection.Ascending));
                        }
                        else
                        {
                            contactsSource.Filter -= VcardCollectionDublicates_Filter;
                            DublicatesNumbers = new List<string>();
                            ContactsSource.SortDescriptions.Add(new SortDescription("FormattedName", ListSortDirection.Ascending));
                        }
                    }, x => { return CurrentContact!= null; }
                ));
            }
        }

        private RelayCommand mergeCardsCommand;
        public RelayCommand MergeCardsCommand
        {
            get
            {
                return mergeCardsCommand ??
                        (mergeCardsCommand = new RelayCommand(obj =>
                        {
                            try
                            {
                                if (SelectedContacts != null)
                                {
                                    var recipiens = (SelectedContacts[0]).Card;
                                    List<VCard> result = new List<VCard>();
                                    for (var i = 1; i < SelectedContacts.Count; i++)
                                    {
                                        recipiens.Concat((SelectedContacts[i]).Card);
                                        result.Add(SelectedContacts[i].Card);
                                    }
                                    while (SelectedContacts.Count>0)
                                    {
                                        ContactsList.Remove(SelectedContacts[0]);
                                    }
                                    
                                    ContactsList.Add(new VCardViewModel(imageDialogService, recipiens) { ConcatInnerVcard=new ObservableCollection<VCard>(result)});
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Не удалось объединить контакты.{ex}");
                            }


                        },
                        x=> { return SelectedContacts.Count>1; }));
            }
        }

        #endregion

        public void OpenFile(string[] filepath)
        {
            try
            {
                foreach (var path in filepath)
                {
                    var VCards = fileService.Open(path);
                    foreach (var vCard in VCards)
                    {
                        ContactsList.Add(new VCardViewModel(imageDialogService, vCard));
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #region filters
        private string filterText;
        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.contactsSource.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }
        private IList<string> dublicatesNumbers;
        public IList<string> DublicatesNumbers
        {
            get { return dublicatesNumbers; }
            set
            {
                if (dublicatesNumbers != value) dublicatesNumbers = value;
                this.contactsSource.View.Refresh();
                OnPropertyChanged("DublicatesNumbers");
            }
        }
        void VcardCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            VCardViewModel vcard = e.Item as VCardViewModel;
            if (vcard.Card.Serialize().Contains(FilterText))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        void VcardCollectionDublicates_Filter(object sender, FilterEventArgs e)
        {
            if (DublicatesNumbers?.Count() == 0 || DublicatesNumbers == null)
            {
                e.Accepted = true;
                return;
            }

            VCardViewModel vcard = e.Item as VCardViewModel;
            var numbers = (vcard.Card?.Telephones?.Select(item => item.Number));

            if (numbers?.Intersect(DublicatesNumbers).Count() > 0)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        #endregion

        public VCardsViewModel(IDialogService _dialogService, IFileService _fileService, IDialogService _imageDialogService,string[] filepath=null)
        {
            dialogService = _dialogService;
            fileService = _fileService;
            imageDialogService = _imageDialogService;
            ContactsList = new ObservableCollection<VCardViewModel>();
            SelectedContacts = new ObservableCollection<VCardViewModel>();
            contactsSource = new CollectionViewSource
            {
                Source = ContactsList
            };
            DublicatesNumbers = new List<string>();
            contactsSource.Filter += VcardCollection_Filter;
            ContactsSource.SortDescriptions.Add(new SortDescription("FormattedName", ListSortDirection.Ascending));
            if (filepath!=null) OpenFile(filepath);
        }
    }
}
