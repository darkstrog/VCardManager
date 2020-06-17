using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PhoneBookManager.ViewModel
{
    class TelephoneViewModel : ViewModelBase, IDataErrorInfo
    {
        public TelephoneType Type
        {
            get { return Telephone.Type; }
            set { if (Telephone.Type != value) { Telephone.Type = value; OnPropertyChanged(); } }
        }
        public string Number
        {
            get { return Telephone.Number; }
            set { if (Telephone.Number != value) { Telephone.Number = value; OnPropertyChanged(); } }
        }
        public int Preference
        {
            get { return Telephone.Preference; }
            set { if (Telephone.Preference != value) { Telephone.Preference = value; OnPropertyChanged(); } }
        }
        public Telephone telephone;
        public Telephone Telephone
        {
            get { return telephone; }
            set { if (telephone != value) { telephone = value; OnPropertyChanged(); } }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        { get
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "Number":
                        if (!Regex.IsMatch(Number, @"^((8 |\+7)[\- ] ?)? (\(?\d{ 3}\)?[\- ]?)?[\d\- ]{ 7,10}$" ))
                        {
                            error = "Неверный формат номера";
                        }
                        break;
                }
                return error;
            } }

        public TelephoneViewModel()
        {
            Telephone = new Telephone();
        }
        public TelephoneViewModel(Telephone telephone)
        {
            Telephone = telephone;
        }
    }
}
