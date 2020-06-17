using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    /// <summary>
    /// See RFC 6350-6.6.6 for more info.
    /// </summary>
    public enum RelationType
    {
        [Description("Контакт")]
        Contact,
        [Description("Знакомый")]
        Acquaintance,
        [Description("Друг")]
        Friend,
        [Description("Повстречавшийся")]
        Met,
        [Description("Соратник")]
        CoWorker,
        [Description("Коллега")]
        Colleague,
        [Description("Сo-resident")]
        CoResident,
        [Description("Сосед")]
        Neighbor,
        [Description("Ребенок")]
        Child,
        [Description("Родитель")]
        Parent,
        [Description("Брат")]
        Sibling,
        [Description("Супруг")]
        Spouse,
        [Description("Родственник")]
        Kin,
        [Description("Muse")]
        Muse,
        [Description("Crush")]
        Crush,
        [Description("Date")]
        Date,
        [Description("Возлюбленный(ая)")]
        Sweetheart,
        [Description("Я")]
        Me,
        [Description("Агент")]
        Agent,
        [Description("В чрезвычайной ситуации")]
        Emergency
    }
}