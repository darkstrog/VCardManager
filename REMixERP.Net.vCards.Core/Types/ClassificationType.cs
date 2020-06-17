using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    public enum ClassificationType
    {
        [Description("Публичный")]
        Public,
        [Description("Личный")]
        Private,
        [Description("Конфиденциальный")]
        Confidential
    }
}