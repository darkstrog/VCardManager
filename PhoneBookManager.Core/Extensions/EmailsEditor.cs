using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookManager.Core.Extensions
{
    public static class EmailsEditor
    {
        public static void RemoveEmail(this VCard vcard, Email email)
        {
            if (vcard.Emails != null)
            {
                var EmailList = vcard.Emails as List<Email>;
                EmailList.Remove(email);
            }
        }
        public static void AddEmail(this VCard vcard, Email email)
        {
            (vcard.Emails as IList<Email>).Add(email);
        }
    }
}
