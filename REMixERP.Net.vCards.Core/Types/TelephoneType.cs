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
        [Description("����������������")]
        Preferred,

        /// <summary>
        /// Indicates a work number.
        /// </summary>
        [Description("�������")]
        Work,

        /// <summary>
        /// Indicates a home number
        /// </summary>
        [Description("��������")]
        Home,

        /// <summary>
        /// Indicates a voice number (Default).
        /// </summary>
        [Description("��������� �����")]
        Voice,

        /// <summary>
        /// Indicates a facsimile number.
        /// </summary>
        [Description("����")]
        Fax,

        /// <summary>
        /// Indicates a messaging service on the number.
        /// </summary>
        [Description("��� ���������")]
        Message,

        /// <summary>
        /// Indicates a cellular number.
        /// </summary>
        [Description("���������")]
        Cell,

        /// <summary>
        /// Indicates a pager number.
        /// </summary>
        [Description("�������")]
        Pager,

        /// <summary>
        /// Indicates a bulletin board service number.
        /// </summary>
        [Description("Bbs")]
        Bbs,

        /// <summary>
        /// Indicates a MODEM number.
        /// </summary>
        [Description("�����")]
        Modem,

        /// <summary>
        /// Indicates a car-phone number.
        /// </summary>
        [Description("����������")]
        Car,

        /// <summary>
        /// Indicates an Integrated Services Digital Network number.
        /// </summary>
        [Description("�������� �����")]
        Isdn,

        /// <summary>
        /// Indicates a video-phone number.
        /// </summary>
        [Description("�����")]
        Video,
        /// <summary>
        /// Indicates preferred number.
        /// </summary>
        [Description("������")]
        Personal
    }
}