using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    //using System;

    class Program
    {
        static void Main(string[] args)
        {
            SistemaReservas sistema = new SistemaReservas();
            bool salir = false;

            while (!salir)
            {
                // Menú de opciones Intereactivas
                Console.WriteLine("\n--- Sistema de Gestión de Alquiler de Vehículos ---");
                Console.WriteLine("1. Registrar un nuevo vehículo");
                Console.WriteLine("2. Eliminar un vehículo");
                Console.WriteLine("3. Actualizar estado de un vehículo");
                Console.WriteLine("4. Realizar una reserva");
                Console.WriteLine("5. Cancelar una reserva");
                Console.WriteLine("6. Mostrar información de vehículos");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione una opción: ");

                //  Opción del usuario
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarVehiculo(sistema);
                        break;

                    case "2":
                        EliminarVehiculo(sistema);
                        break;

                    case "3":
                        ActualizarEstadoVehiculo(sistema);
                        break;

                    case "4":
                        RealizarReserva(sistema);
                        break;

                    case "5":
                        CancelarReserva(sistema);
                        break;

                    case "6":
                        MostrarVehiculos(sistema);
                        break;

                    case "7":
                        Console.WriteLine("Saliendo del sistema...");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

    }
}
