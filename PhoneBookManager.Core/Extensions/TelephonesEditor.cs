using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookManager.Core.Extensions
{
        
    public static class TelephonesEditor
    {
        public static void RemoveTelephone(this VCard vcard,Telephone telephone)
        {
            if (vcard.Telephones != null)
            {
                var PhoneList = vcard.Telephones as List<Telephone>;
                PhoneList.Remove(telephone);
            }
        }
        public static void AddTelephone(this VCard vcard, Telephone telephone)
        {
            (vcard.Telephones as IList<Telephone>).Add(telephone);
        }
    }
}
