using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PhoneBookManager.ViewModel
{
    class EmailViewModel : ViewModelBase, IDataErrorInfo
    {
        public EmailType Type { get { return Email.Type; } set { if (Email.Type != value) { Email.Type = value; OnPropertyChanged(); } } }
        public string EmailAddress { get { return Email.EmailAddress; } set { if (Email.EmailAddress != value) { Email.EmailAddress = value; OnPropertyChanged(); } } }
        public int Preference { get { return Email.Preference; } set { if (Email.Preference != value) { Email.Preference = value; OnPropertyChanged(); } } }

        public Email email;
        public Email Email { get { return email; } set { if (email != value) { email = value; OnPropertyChanged(); } } }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "EmailAddress":
                        if (!Regex.IsMatch(EmailAddress, @"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$"))
                        {
                            error = "Неверный формат EMail";
                        }
                        break;
                }
                return error;
            }
        }

        public EmailViewModel()
        {
            Email = new Email();
        }
        public EmailViewModel(Email email)
        {
            Email = email;
        }
    }
}
