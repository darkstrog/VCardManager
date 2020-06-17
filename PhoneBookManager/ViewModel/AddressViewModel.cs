using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookManager.ViewModel
{
    class AddressViewModel : ViewModelBase
    {
        public AddressType Type { get { return Address.Type; } set { Address.Type = value; OnPropertyChanged(); } }

        /// <summary>
        ///     Post office box number
        /// </summary>
        public string PoBox { get; set; }

        public string ExtendedAddress { get; set; }

        public string Street { get { return Address.Street; } set { Address.Street = value; OnPropertyChanged(); } }

        public string Locality { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }

        public string Country { get; set; }

        #region v4.0

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string Label { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public int Preference { get; set; }

        #endregion

        #region Non Standard
        public IEquatable<CustomExtension> Extensions { get; set; }
        #endregion

        private Address address;

        public Address Address { get { return address; } set { address = value; OnPropertyChanged(); } }
        public AddressViewModel()
        {
            Address = new Address();
        }
        public AddressViewModel(Address address)
        {
            Address = address;
        }
    }
}
