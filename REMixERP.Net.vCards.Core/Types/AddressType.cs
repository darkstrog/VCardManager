using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    /// <summary>
    ///     This property parameter specifies the sub-types of physical delivery that is associated with the delivery address.
    ///     For example, the label may need to be differentiated for Home, Work, Parcel, Postal, Domestic, and International
    ///     physical delivery. One or more sub-types can be specified for a given delivery address.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        ///     Indicates a domestic address.
        /// </summary>
        [Description("Внутренний")]
        Domestic,

        /// <summary>
        ///     Indicates an international address
        /// </summary>
        [Description("Международный")]
        International,

        /// <summary>
        ///     Indicates an postal address
        /// </summary>
        [Description("Почтовый")]
        Postal,

        /// <summary>
        ///     Indicates an parcel delivery address
        /// </summary>
        [Description("Для посылок")]
        Parcel,

        /// <summary>
        ///     Indicates an home address
        /// </summary>
        [Description("Домашний")]
        Home,

        /// <summary>
        ///     Indicates an work address
        /// </summary>
        [Description("Рабочий")]
        Work
    }
}