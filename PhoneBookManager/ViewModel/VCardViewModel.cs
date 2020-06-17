using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;
using PhoneBookManager.Core.Extensions;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PhoneBookManager.ViewModel
{
    class VCardViewModel : ViewModelBase
    {
        #region properties
        #region v2.1 https://www.imc.org/pdi/vcard-21.txt
        public DateTime? BirthDay
        {
            get { return Card.BirthDay; }
            set { Card.BirthDay = ((DateTime)value).Date; OnPropertyChanged("Birthday"); }
        }

        private AddressViewModel selectedAddress;
        public AddressViewModel SelectedAddress { get { return selectedAddress; } set { if (selectedAddress != value) { selectedAddress = value; OnPropertyChanged(); } } }
        public ObservableCollection<AddressViewModel> Addresses { get; set; }

        public DeliveryAddress DeliveryAddress { get { return Card.DeliveryAddress; } set { if (Card.DeliveryAddress != value) { Card.DeliveryAddress = value; OnPropertyChanged(); } } }

        private TelephoneViewModel selectedPhone;
        public TelephoneViewModel SelectedPhone { get { return selectedPhone; } set { if (selectedPhone != value) { selectedPhone = value; OnPropertyChanged(); } } }
        private ObservableCollection<TelephoneViewModel> telephones;
        public ObservableCollection<TelephoneViewModel> Telephones { get { return telephones; } set { if (telephones != value) { telephones = value; OnPropertyChanged(); } } }
        public string DisplayNumber
        {
            get
            {
                string tel= String.Empty;
                if (Telephones != null) tel = Telephones.FirstOrDefault(x=>x.Preference==0)?.Number;
                return string.Join(string.Empty, Regex.Matches(tel, @"\d+").OfType<Match>().Select(m => m.Value));
            }
        }

        private EmailViewModel selectedEmail;
        public EmailViewModel SelectedEmail {get { return selectedEmail; }set { if (selectedEmail != value) { selectedEmail = value; OnPropertyChanged(); } }}
        public ObservableCollection<EmailViewModel> Emails { get; set; }

        //public string Mailer { get { return Card.Mailer; } set { if (Card.Mailer != value) { Card.Mailer = value; OnPropertyChanged(); } }}

        public string Title { get { return Card.Title; } set { if (Card.Title != value) { Card.Title = value; OnPropertyChanged(); } } }

        public string Role { get { return Card.Role; } set { if (Card.Role != value) { Card.Role = value; OnPropertyChanged(); } } }

        //public TimeZoneInfo TimeZone { get { return Card.TimeZone; } set { if (Card.TimeZone != value) { Card.TimeZone = value; OnPropertyChanged(); } } }

        public Photo Logo { get { return Card.Logo; } set { if (Card.Logo != value) { Card.Logo = value; OnPropertyChanged(); } } }

        public Photo Photo { get { return Card.Photo; } set { if (Card.Photo != value) { Card.Photo = value; OnPropertyChanged(); } } }

        public string Note { get { return Card.Note; } set { if (Card.Note != value) { Card.Note = value; OnPropertyChanged(); } } }

        public DateTime? LastRevision { get { return Card.LastRevision; } set { if (Card.LastRevision != value) { Card.LastRevision = value; OnPropertyChanged(); } } }

        public Uri Url { get { return Card.Url; } set { if (Card.Url != value) { Card.Url = value; OnPropertyChanged(); } } }

        //public string UniqueIdentifier { get { return Card.UniqueIdentifier; } set { if (Card.UniqueIdentifier != value) { Card.UniqueIdentifier = value; OnPropertyChanged(); } } }

        public VCardVersion Version { get { return Card.Version; } set { if (Card.Version != value) { Card.Version = value; OnPropertyChanged(); } } }
        #region Organization Name & Unit

        public string Organization { get { return Card.Organization; } set { if (Card.Organization != value) { Card.Organization = value; OnPropertyChanged(); } } }

        public string OrganizationalUnit { get { return Card.OrganizationalUnit; } set { if (Card.OrganizationalUnit != value) { Card.OrganizationalUnit = value; OnPropertyChanged(); } } }

        #endregion

        #region Geographic Position

        //public double Longitude { get { return Card.Longitude; } set { if (Card.Longitude != value) { Card.Longitude = value; OnPropertyChanged(); } } }

        //public double Latitude { get { return Card.Latitude; } set { if (Card.Latitude != value) { Card.Latitude = value; OnPropertyChanged(); } } }

        #endregion

        #region Name & Formatted Name

        public string FormattedName
        {
            get
            {
                return Card.FormattedName; 
            }
            set
            {
                if (Card.FormattedName != value)
                {
                    Card.FormattedName = value; 
                    OnPropertyChanged();
                }
            }
        }

        #region Name

        public string LastName 
        {
            get
            {
                return Card.LastName;
            }
            set
            {
                if (Card.LastName != value)
                {
                    Card.LastName = value;
                    FormattedName = FirstName + " " + MiddleName + " " + LastName;
                    OnPropertyChanged();
                }
            }
        }

        public string FirstName 
        {
            get
            {
                return Card.FirstName; 
            }
            set
            {
                if (Card.FirstName != value) 
                {
                    Card.FirstName = value;
                    FormattedName = FirstName + " " + MiddleName + " " + LastName; 
                    OnPropertyChanged();
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return Card.MiddleName;
            }
            set
            {
                if (Card.MiddleName != value)
                {
                    Card.MiddleName = value;
                    FormattedName = FirstName + " " + MiddleName + " " + LastName;
                    OnPropertyChanged();
                }
            }
        }

        public string Prefix
        { 
            get
            { 
                return Card.Prefix;
            } 
            set
            { 
                if (Card.Prefix != value)
                { 
                    Card.Prefix = value;
                    OnPropertyChanged();
                } 
            } 
        }

        public string Suffix
        {
            get 
            {
                return Card.Suffix;
            }
            set 
            {
                if (Card.Suffix != value)
                { 
                    Card.Suffix = value;
                    OnPropertyChanged(); 
                }
            }
        }

        #endregion

        #endregion

        #endregion
        #region v3.0 RFC 2426 (https://www.ietf.org/rfc/rfc2426.txt)
        public string NickName { get { return Card.NickName; } set { Card.NickName = value; OnPropertyChanged(); } }

        //public string[] Categories { get { return Card.Categories; } set { Card.Categories = value; OnPropertyChanged(); } }

        //public string SortString { get { return Card.SortString; } set { Card.SortString = value; OnPropertyChanged(); } }

        //public string Sound { get { return Card.Sound; } set { Card.Sound = value; OnPropertyChanged(); } }

        //public string Key { get { return Card.Key; } set { Card.Key = value; OnPropertyChanged(); } }

        //public ClassificationType Classification { get { return Card.Classification; } set { Card.Classification = value; OnPropertyChanged(); } }

        #endregion
        #region v4.0 RFC 6350 (https://www.ietf.org/rfc/rfc6350.txt)

        //public Uri Source { get { return Card.Source; } set { Card.Source = value; OnPropertyChanged(); } }

        //public Kind Kind { get { return Card.Kind; } set { Card.Kind = value; OnPropertyChanged(); } }

        //public DateTime? Anniversary { get { return Card.Anniversary; } set { Card.Anniversary = value; OnPropertyChanged(); } }

        //public Gender Gender { get { return Card.Gender; } set { Card.Gender = value; OnPropertyChanged(); } }

        //public IEnumerable<Impp> Impps { get { return Card.Impps; } set { Card.Impps = value; OnPropertyChanged(); } }

        //public IEnumerable<Language> Languages { get { return Card.Languages; } set { Card.Languages = value; OnPropertyChanged(); } }

        //public IEnumerable<Relation> Relations { get { return Card.Relations; } set { Card.Relations = value; OnPropertyChanged(); } }

        //public IEnumerable<Uri> CalendarUserAddresses { get { return Card.CalendarUserAddresses; } set { Card.CalendarUserAddresses = value; OnPropertyChanged(); } }

        //public IEnumerable<Uri> CalendarAddresses { get { return Card.CalendarAddresses; } set { Card.CalendarAddresses = value; OnPropertyChanged(); } }

        #endregion
        public IEnumerable<CustomExtension> CustomExtensions { get { return card.CustomExtensions; } set { card.CustomExtensions = value; OnPropertyChanged(); } }
        public ObservableCollection<VCard> ConcatInnerVcard { get; set; }
        #endregion

        VCard card;
        public VCard Card { get { return card; } set { card = value; OnPropertyChanged("Card"); } }

        readonly IDialogService imageDialogService;
        
        #region commands
        
        private RelayCommand addPhoneNumber;
        public RelayCommand AddPhoneNumber
        {
            get
            {
                return addPhoneNumber ??
                        (addPhoneNumber = new RelayCommand(obj =>
                        {
                            TelephoneViewModel NewTelephone = new TelephoneViewModel();
                            if (Telephones == null)
                            {
                                Telephones = new ObservableCollection<TelephoneViewModel>{ NewTelephone };
                            }
                            else
                            {
                                Telephones.Add(NewTelephone);
                            }

                        }));
            }
        }

        private RelayCommand delPhoneNumber;
        public RelayCommand DelPhoneNumber
        {
            get
            {
                return delPhoneNumber ??
                        (delPhoneNumber = new RelayCommand(obj =>
                        {
                            Telephones.Remove((TelephoneViewModel)((ListBoxItem)obj).Content);
                            //var toRemove = obj as IList;
                            //while (toRemove.Count > 0)
                            //{
                            //    Telephones.Remove((TelephoneViewModel)toRemove[0]);
                            //}
                        }));
            }
        }

        private RelayCommand addEmail;
        public RelayCommand AddEmail
        {
            get
            {
                return addEmail ??
                        (addEmail = new RelayCommand(obj =>
                        {
                            EmailViewModel NewEmail = new EmailViewModel { EmailAddress = "", Type = EmailType.Smtp };
                            Emails.Add(NewEmail);
                        }));
            }
        }
        private RelayCommand delEmail;
        public RelayCommand DelEmail
        {
            get
            {
                return delEmail ??
                        (delEmail = new RelayCommand(obj =>
                        {
                            Emails.Remove((EmailViewModel)((ListBoxItem)obj).Content);
                            //var toRemove = obj as IList;
                            //while (toRemove.Count > 0)
                            //{
                            //    Emails.Remove((EmailViewModel)toRemove[0]);
                            //}
                        }));
            }
        }

        private RelayCommand addAddress;
        public RelayCommand AddAddress
        {
            get
            {
                return addAddress ??
                        (addAddress = new RelayCommand(obj =>
                        {

                            AddressViewModel NewAddress = new AddressViewModel { Street = "", Type = AddressType.Home };//С целью упрощения и по аналогии с телефонной книгой андройда весь адрес пишем в Street
                            Addresses.Add(NewAddress);

                        }));
            }
        }
        private RelayCommand delAddress;
        public RelayCommand DelAddress
        {
            get
            {
                return delAddress ??
                        (delAddress = new RelayCommand(obj =>
                        {
                            Addresses.Remove((AddressViewModel)((ListBoxItem)obj).Content);
                            //var toRemove = obj as IList;
                            //while (toRemove.Count > 0)
                            //{
                            //    Addresses.Remove((AddressViewModel)toRemove[0]);
                            //}
                        }));
            }
        }

        private RelayCommand setImageCommand;
        public RelayCommand SetImageCommand
        {
            get
            {
                return setImageCommand ??
                        (setImageCommand = new RelayCommand(obj => {
                            try
                            {
                                if (imageDialogService.OpenFileDialog() == true)
                                {
                                    var path = imageDialogService.FilePath[0];
                                    var ext = Path.GetExtension(path);
                                    byte[] image = File.ReadAllBytes(path);
                                    string base64img = Convert.ToBase64String(image);
                                    Photo = new Photo(true, ext, base64img);
                                }
                            }
                            catch (Exception ex)
                            {
                                imageDialogService.ShowMessage(ex.Message);
                            }

                        }));
            }
        }

        private RelayCommand clearImageCommand;
        public RelayCommand ClearImageCommand
        {
            get
            {
                return clearImageCommand ??
                        (clearImageCommand = new RelayCommand(obj =>
                        {
                            Photo = null;
                        },x => { return Photo != null;}
                        ));
            }
        }


        #endregion

        #region constructors
       
        public VCardViewModel(IDialogService _imageDialogService, VCard _card = null)
        {
            Card = _card ?? new VCard();
            imageDialogService = _imageDialogService;

            Telephones = new ObservableCollection<TelephoneViewModel>();
            Emails = new ObservableCollection<EmailViewModel>();
            Addresses = new ObservableCollection<AddressViewModel>();
            ConcatInnerVcard = new ObservableCollection<VCard>();

            FillTelephones(Card.Telephones);
            FillEmails(Card.Emails);
            FillAddresses(Card.Addresses);


            Telephones.CollectionChanged += Changed_PhonesCollection;
            Emails.CollectionChanged += Changed_EmailsCollection;
            Addresses.CollectionChanged += Changed_AddressesCollection;
        }
        

        #endregion
        #region events
        private void FillTelephones(IEnumerable<Telephone> telephones)
        {
            if (telephones != null)
            {
                foreach (var item in telephones)
                {
                    Telephones.Add(new TelephoneViewModel(item));
                }
            }
        }
        private void FillEmails(IEnumerable<Email> emails)
        {
            if (emails != null)
            {
                foreach (var item in emails)
                {
                    Emails.Add(new EmailViewModel(item));
                }
            }
        }
        private void FillAddresses(IEnumerable<Address> addresses)
        {
            if (addresses != null)
            {
                foreach (var item in addresses)
                {
                    Addresses.Add(new AddressViewModel(item));
                }
            }
        }
        public void Changed_PhonesCollection(object Sender, NotifyCollectionChangedEventArgs e)
        {
            var _sender = Sender as ObservableCollection<TelephoneViewModel>;
            var deletingTelephone = e.OldItems;
            if (Card.Telephones == null) Card.Telephones = new List<Telephone>();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Card.AddTelephone(_sender.LastOrDefault().Telephone);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        try
                        {
                            foreach (var item in deletingTelephone)
                            {
                                Card.RemoveTelephone(((TelephoneViewModel)item).Telephone);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Что то пошло не так...: {ex.Message}");
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
        public void Changed_EmailsCollection(object Sender, NotifyCollectionChangedEventArgs e)
        {
            //if(Card.Emails==null)Card.Emails = Emails.Select(x => x.Email);
            var _sender = Sender as ObservableCollection<EmailViewModel>;
            var deletingTelephone = e.OldItems;
            if (Card.Emails == null) Card.Emails = new List<Email>();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Card.AddEmail(_sender.LastOrDefault().Email);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        try
                        {
                            foreach (var item in deletingTelephone)
                            {
                                Card.RemoveEmail(((EmailViewModel)item).Email);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Что то пошло не так...: {ex.Message}");
                        }


                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
        public void Changed_AddressesCollection(object Sender, NotifyCollectionChangedEventArgs e)
        {
            //if (Card.Addresses==null) Card.Addresses = Addresses.Select(x => x.Address);
            var _sender = Sender as ObservableCollection<AddressViewModel>;
            var deletingTelephone = e.OldItems;
            if (Card.Addresses == null) Card.Addresses = new List<Address>();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Card.AddAddress(_sender.LastOrDefault().Address);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        try
                        {
                            foreach (var item in deletingTelephone)
                            {
                                Card.RemoveAddress(((AddressViewModel)item).Address);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Что то пошло не так...: {ex.Message}");
                        }


                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
