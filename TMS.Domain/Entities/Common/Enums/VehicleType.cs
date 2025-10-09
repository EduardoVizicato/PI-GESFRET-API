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
    public enum VehicleType
    {
        [EnumMember(Value = "Tração")]
        Tracao,

        [EnumMember(Value = "Reboque (Carreta)")]
        ReboqueCarreta
    }
}
