using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    /// <summary>
    ///     This property parameter specifies the type of electronic mail address.
    /// </summary>
    public enum EmailType
    {
        /// <summary>
        ///     Indicates America On-Line.
        /// </summary>
        [Description("AmericaOnline")]
        AmericaOnline,

        /// <summary>
        ///     Indicates AppleLink.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("AppleLink")]
        AppleLink,

        /// <summary>
        ///     Indicates AT&amp;T Mail.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("ATTMail")]
        ATTMail,

        /// <summary>
        ///     Indicates CompuServe Information Service.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("CompuServeInformationServices")]
        CompuServeInformationServices,

        /// <summary>
        ///     Indicates eWorld.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("EWorld")]
        EWorld,

        /// <summary>
        ///     Indicates Internet SMTP (default).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("Smtp")]
        Smtp,

        /// <summary>
        ///     Indicates IBM Mail.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("IBMMail")]
        IBMMail,

        /// <summary>
        ///     Indicates MCI Mail.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("MCIMail")]
        MCIMail,

        /// <summary>
        ///     Indicates PowerShare.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("PowerShare")]
        PowerShare,

        /// <summary>
        ///     Indicates Prodigy information service.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("Prodigy")]
        Prodigy,

        /// <summary>
        ///     Indicates Telex number.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("Telex")]
        Telex,

        /// <summary>
        ///     Indicates X.400 service.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [Description("X400")]
        X400
    }
}