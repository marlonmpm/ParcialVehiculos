using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    // Clase que representa un cliente en el sistema
    public class Cliente
    {
        public string Nombre { get; private set; }
        public string Cedula { get; private set; }

        // Constructor para inicializar los atributos del cliente
        public Cliente(string nombre, string cedula)
        {
            Nombre = nombre;
            Cedula = cedula;
        }

        // Método para mostrar información básica del cliente
        public void MostrarInformacion()
        {
            Console.WriteLine($"Cliente: {Nombre}, Cédula: {Cedula}");
        }
    }
}
