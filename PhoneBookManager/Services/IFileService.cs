using MixERP.Net.VCards;
using System.Collections.Generic;

namespace PhoneBookManager.Services
{
    interface IFileService
    {
        List<VCard> Open(string filename);
        void Save(string filename, List<VCard> vCardList);
        void SaveAll(string filename, List<VCard> vCardList);
    }
}
