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
    public enum RodadoEnum
    {
        [EnumMember(Value = "Caminhão truck (3-4 eixos)")]
        CaminhaoTruck,

        [EnumMember(Value = "Caminhão toco (2 eixos)")]
        CaminhaoToco,

        [EnumMember(Value = "Cavalo (2-3 eixos e acopla carroceria)")]
        Cavalo,

        [EnumMember(Value = "VAN (2 eixos)")]
        VAN,

        [EnumMember(Value = "Utilitários (2 eixos)")]
        Utilitarios,

        [EnumMember(Value = "Outros")]
        Outros,

        [EnumMember(Value = "")]
        Null
    }
}
