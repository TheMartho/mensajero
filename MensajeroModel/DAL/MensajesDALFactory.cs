using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    //LARMAN UML Patterns Libro de patronces de diseño
    public class MensajesDALFactory
    {
        public static IMensajesDAL CreateDal()
        {
            return MensajesDALArchivos.GetInstancia();
        }
    }
}
