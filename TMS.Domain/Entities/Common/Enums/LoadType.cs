using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities.Common.Enums
{
    public enum LoadType
    {
        CargadeGranelSólido = 1,
        CargadeGranelLíquido = 2,
        CargaFrigorificadaouAquecida = 3,
        CargaConteinerizada= 4,
        CargaGeral= 5,
        CargaNeogranel = 6,
        CargaPerigosaGranelSólido = 7 ,
        CargaPerigosaGranelLíquido = 8,
        CargaPerigosaCargaFrigorificadaOuaquecida = 9,
        CargaPerigosaConteinerizada = 10,
        CargaPerigosaCargaGeral = 11,
        CargaGranelPressurizada = 12,
    }
}
