using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Teorioa
{
   public class CadenaDeTexto
    {
      public CadenaDeTexto(float latitud, float  longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        public float Latitud { get; set; }
        public float Longitud { get; set; }



  

    }
}
