using MixERP.Net.VCards;
using MixERP.Net.VCards.Helpers;
using MixERP.Net.VCards.Serializer;
using PhoneBookManager.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBookManager.Services
{
    class VCardFileService : IFileService
    {
        public List<VCard> Open(string path)
        {
            var normalizedFile = AndroidContactsHelper.NormalizeTagTrigger(path);
            return new List<VCard>(Deserializer.DeserializeString(VCardHelper.SplitCards(normalizedFile)));
        }

        public void Save(string filename, List<VCard> vCardList)
        {
            string serialized = String.Empty;
            foreach (var vCard in vCardList)
            {
                serialized += vCard.Serialize();
            }
            try
            {
                File.WriteAllText(filename, serialized, new UTF8Encoding(false));
                SaveFileComplete?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButton.OK);
            }

        }
        public void SaveAll(string filename, List<VCard> vCardList)
        {
            foreach (var vCard in vCardList)
            {
                var serialized = vCard.Serialize();
                var _filename= filename;
                try
                {
                    while (File.Exists(_filename))
                    {
                        Random rnd = new Random();
                        _filename = Path.GetDirectoryName(_filename)+ @"\" + Path.GetFileNameWithoutExtension(_filename)+rnd.Next(1,10)+Path.GetExtension(filename);
                    }
                    File.WriteAllText(_filename, serialized, new UTF8Encoding(false));
                    SaveFileComplete?.Invoke(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButton.OK);
                }
            }
        }
        public event EventHandler SaveFileComplete;

    }
}
