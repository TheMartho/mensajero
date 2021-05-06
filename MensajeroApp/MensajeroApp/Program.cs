using MensajeroApp.Hilos;
using System;
using System.Configuration;
using System.Threading;

namespace MensajeroApp
{
    partial class Program
    {
        //1.Crear Menu
        //2. Dos metodos IngresarMensajes y MostrarMensajes
        //3. Al ingresar un mensaje definir el tipo como Aplicación

  
       
        static void Main(string[] args)
        {

            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Hilo Del Server Socket");
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();


            while (menu());

        }
    }
}
