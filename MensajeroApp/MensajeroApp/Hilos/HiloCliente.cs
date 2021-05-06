using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketUtils;
using MensajeroModel.DAL;
using MensajeroModel.DTO;

namespace MensajeroApp.Hilos
{
    class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private IMensajesDAL dal = MensajesDALFactory.CreateDal();

        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {

            string nombre;
            string mensaje;

            do
            {
                Console.WriteLine("Ingrese su nombre");
                nombre = clienteSocket.Leer().Trim();

            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese su mensaje");
                mensaje = clienteSocket.Leer().Trim();
            } while (mensaje == string.Empty || mensaje.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = mensaje,
                Tipo = "TCP"
            };
            lock (dal)
            {
                dal.Save(m);
            }
           
            clienteSocket.CerrarConexion();


        }

    }
}
