using System.ComponentModel;

namespace MixERP.Net.VCards.Types
{
    public enum ClassificationType
    {
        [Description("���������")]
        Public,
        [Description("������")]
        Private,
        [Description("����������������")]
        Confidential
    }
}