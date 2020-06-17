using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    /// <summary>
    /// Specifies the components of the sex and gender identity of the object the vCard represents.
    /// </summary>
    public enum Gender
    {
        [Description("Женщина")]
        Female,
        [Description("Мужчина")]
        Male,
        [Description("Не применяемый")]
        NotApplicable,
        [Description("Другое")]
        Other,
        [Description("Не определен")]
        Unknown
    }
}