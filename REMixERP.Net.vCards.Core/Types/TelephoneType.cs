using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    /// <summary>
    /// This property parameter specifies the sub-type of telephone that is associated with the telephone number (e.g., Home, Work, Cellular, Facsimile, Video, Modem, Message Service, or Preferred). One or more sub-type values can be specified for a given telephone number.
    /// </summary>
    public enum TelephoneType
    {
        /// <summary>
        /// Indicates preferred number.
        /// </summary>
        [Description("Предпочтительный")]
        Preferred,

        /// <summary>
        /// Indicates a work number.
        /// </summary>
        [Description("Рабочий")]
        Work,

        /// <summary>
        /// Indicates a home number
        /// </summary>
        [Description("Домашний")]
        Home,

        /// <summary>
        /// Indicates a voice number (Default).
        /// </summary>
        [Description("Голосовая связь")]
        Voice,

        /// <summary>
        /// Indicates a facsimile number.
        /// </summary>
        [Description("Факс")]
        Fax,

        /// <summary>
        /// Indicates a messaging service on the number.
        /// </summary>
        [Description("Для сообщений")]
        Message,

        /// <summary>
        /// Indicates a cellular number.
        /// </summary>
        [Description("Мобильный")]
        Cell,

        /// <summary>
        /// Indicates a pager number.
        /// </summary>
        [Description("Пейджер")]
        Pager,

        /// <summary>
        /// Indicates a bulletin board service number.
        /// </summary>
        [Description("Bbs")]
        Bbs,

        /// <summary>
        /// Indicates a MODEM number.
        /// </summary>
        [Description("Модем")]
        Modem,

        /// <summary>
        /// Indicates a car-phone number.
        /// </summary>
        [Description("Автомобиль")]
        Car,

        /// <summary>
        /// Indicates an Integrated Services Digital Network number.
        /// </summary>
        [Description("Интернет связь")]
        Isdn,

        /// <summary>
        /// Indicates a video-phone number.
        /// </summary>
        [Description("Видео")]
        Video,
        /// <summary>
        /// Indicates preferred number.
        /// </summary>
        [Description("Личный")]
        Personal
    }
}