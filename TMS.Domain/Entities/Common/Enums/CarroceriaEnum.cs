using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TMS.Domain.Entities.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CarroceriaEnum
    {
        [EnumMember(Value = "Não aplicável (Tanque, Caçamba, Boiadeira, etc)")]
        NaoAplicavel,

        [EnumMember(Value = "Aberta")]
        Aberta,

        [EnumMember(Value = "Fechada/Baú")]
        FechadaBau,

        [EnumMember(Value = "Granelera")]
        Granelera,

        [EnumMember(Value = "Porta Container")]
        PortaContainer,

        [EnumMember(Value = "Sider")]
        Sider,

        [EnumMember(Value = "")]
        Null
    }
}
