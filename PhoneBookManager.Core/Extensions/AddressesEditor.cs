using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookManager.Core.Extensions
{
    public static class AddressesEditor
    {
        public static void RemoveAddress(this VCard vcard, Address address)
        {
            if (vcard.Emails != null)
            {
                var AddressList = vcard.Addresses as IList<Address>;
                AddressList.Remove(address);
            }
        }
        public static void AddAddress(this VCard vcard, Address address)
        {
            (vcard.Addresses as IList<Address>).Add(address);
        }
    }
}
