using MixERP.Net.VCards;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PhoneBookManager.Core.Extensions
{
    public static class VCardExtensions
    {
        /// <summary>
        /// Производит слияние контактов
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public static void Concat(this VCard first, VCard second)
        {
            //Все коллекции объединяем
            #region Collections
            if (first.Addresses == null) first.Addresses = new List<Address>();
            if (first.Emails == null) first.Emails = new List<Email>();
            if (first.Telephones == null) first.Telephones = new List<Telephone>();
            if (first.Impps == null) first.Impps = new List<Impp>();
            if (first.Languages == null) first.Languages = new List<Language>();
            if (first.Relations == null) first.Relations = new List<Relation>();
            if (first.CalendarUserAddresses == null) first.CalendarUserAddresses = new List<Uri>();
            if (first.CalendarAddresses == null) first.CalendarAddresses = new List<Uri>();
            if (first.CustomExtensions == null) first.CustomExtensions = new List<CustomExtension>();

            if (second.Addresses != null) first.Addresses= first.Addresses.Union(second.Addresses).ToList();
            if (second.Emails != null) first.Emails= first.Emails.Union(second.Emails).ToList();
            if (second.Telephones != null) first.Telephones= first.Telephones.Union(second.Telephones).ToList();
            if (second.Impps != null) first.Impps= first.Impps.Union(second.Impps).ToList();
            if (second.Languages != null) first.Languages= first.Languages.Union(second.Languages).ToList();
            if (second.Relations != null) first.Relations= first.Relations.Union(second.Relations).ToList();
            if (second.CalendarUserAddresses != null) first.CalendarUserAddresses= first.CalendarUserAddresses.Union(second.CalendarUserAddresses).ToList();
            if (second.CalendarAddresses != null) first.CalendarAddresses= first.CalendarAddresses.Union(second.CalendarAddresses).ToList();
            //if (second.CustomExtensions != null) first.CustomExtensions = first.CustomExtensions.Union(second.CustomExtensions);
            #endregion
            //Если свойство первой карточки пустое заполняем его значением из второго
            foreach (PropertyInfo prop in typeof(VCard).GetProperties())
            {
                try
                {
                    if (prop.PropertyType.Name != "IEnumerable`1")
                    {
                        var _prop = prop.GetValue(first);
                        var _prop2 = prop.GetValue(second);
                        if (_prop == null)
                            prop.SetValue(first, _prop2);
                    }
                }
                catch { continue; }
            }
            
        }
    }
    
}
