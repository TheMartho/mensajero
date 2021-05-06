using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    public partial class Program
    {
        static IMensajesDAL DAL = MensajesDALFactory.CreateDal();

        static void IngresarMensajes()
        {
            string nombre;
            string mensaje;

            do
            {
                Console.WriteLine("Ingrese su nombre");
                nombre = Console.ReadLine();

            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese su mensaje");
                mensaje = Console.ReadLine();
            } while (mensaje == string.Empty || mensaje.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = mensaje,
                Tipo = "Aplicacion"
            };
            lock (DAL)
            {
                DAL.Save(m);
            }
            

        }

        static void MostrarMensajes()
        {
            List<Mensaje> mensajes = DAL.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre:{0}  Detalle:{1}  tipo{2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }

        static bool menu()
        {
            bool flag = true;
            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("(1) Ingresar Mensajes ");
            Console.WriteLine("(2) Mostrar Mensajes");
            Console.WriteLine("(0) Salir");
            string respuesta = Console.ReadLine().Trim();
            switch (respuesta)
            {
                case "1":
                    IngresarMensajes();
                    break;
                case "2":
                    MostrarMensajes();
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("La opcion no es valida");
                    break;

            }
            return flag;
        }
    }
}
