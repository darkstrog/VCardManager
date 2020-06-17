using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    public enum LanguageType
    {
        [Description("Неизвестно")]
        Unknown,
        [Description("Неформальный")]
        Home,
        [Description("Деловой")]
        Work
    }
}