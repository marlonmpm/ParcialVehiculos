using AlguilerVehicular.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlguilerVehicular.Clases
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaReservas sistema = new SistemaReservas();
            bool salir = false;

            while (!salir)
            {
                // Menú de opciones Interactivas
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

        // Método para registrar un nuevo vehículo
        static void RegistrarVehiculo(SistemaReservas sistema)
        {
            Console.WriteLine("Seleccione el tipo de vehículo (1. Automóvil, 2. Motocicleta, 3. Camión): ");
            string tipoVehiculo = Console.ReadLine();

            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Año de Fabricación: ");
            int añoFabricacion = int.Parse(Console.ReadLine());
            Console.Write("Precio de Alquiler: ");
            double precioAlquiler = double.Parse(Console.ReadLine());

            Vehiculo nuevoVehiculo;

            // Dependiendo de la selección, se crea el tipo de vehículo
            switch (tipoVehiculo)
            {
                case "1":
                    nuevoVehiculo = new Automovil(marca, modelo, añoFabricacion, precioAlquiler);
                    break;
                case "2":
                    nuevoVehiculo = new Motocicleta(marca, modelo, añoFabricacion, precioAlquiler);
                    break;
                case "3":
                    nuevoVehiculo = new Camion(marca, modelo, añoFabricacion, precioAlquiler);
                    break;
                default:
                    Console.WriteLine("Tipo de vehículo no válido.");
                    return;
            }

            sistema.RegistrarVehiculo(nuevoVehiculo);
        }

        // Método para eliminar un vehículo
        static void EliminarVehiculo(SistemaReservas sistema)
        {
            Console.Write("Ingrese la marca del vehículo a eliminar: ");
            string marca = Console.ReadLine();

            Vehiculo vehiculo = sistema.BuscarVehiculoPorMarca(marca);
            if (vehiculo != null)
            {
                sistema.EliminarVehiculo(vehiculo);
                Console.WriteLine("Vehículo eliminado.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        // Método para actualizar el estado de un vehículo
        static void ActualizarEstadoVehiculo(SistemaReservas sistema)
        {
            Console.Write("Ingrese la marca del vehículo a actualizar: ");
            string marca = Console.ReadLine();

            Vehiculo vehiculo = sistema.BuscarVehiculoPorMarca(marca);
            if (vehiculo != null)
            {
                Console.WriteLine("Seleccione el nuevo estado (1. Disponible, 2. Alquilado, 3. En mantenimiento): ");
                string estado = Console.ReadLine();

                switch (estado)
                {
                    case "1":
                        sistema.ActualizarEstadoVehiculo(vehiculo, EstadoVehiculo.Disponible);
                        break;
                    case "2":
                        sistema.ActualizarEstadoVehiculo(vehiculo, EstadoVehiculo.Alquilado);
                        break;
                    case "3":
                        sistema.ActualizarEstadoVehiculo(vehiculo, EstadoVehiculo.EnMantenimiento);
                        break;
                    default:
                        Console.WriteLine("Estado no válido.");
                        return;
                }

                Console.WriteLine("Estado actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        // Método para realizar una reserva
        static void RealizarReserva(SistemaReservas sistema)
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la cédula del cliente: ");
            string cedula = Console.ReadLine();

            Cliente cliente = new Cliente(nombre, cedula);

            Console.Write("Ingrese la marca del vehículo a reservar: ");
            string marca = Console.ReadLine();

            Vehiculo vehiculo = sistema.BuscarVehiculoPorMarca(marca);
            if (vehiculo != null && vehiculo.EstaDisponible())
            {
                Console.Write("Ingrese la fecha de inicio de la reserva (yyyy-MM-dd): ");
                DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
                Console.Write("Ingrese la fecha de fin de la reserva (yyyy-MM-dd): ");
                DateTime fechaFin = DateTime.Parse(Console.ReadLine());

                sistema.RealizarReserva(cliente, vehiculo, fechaInicio, fechaFin);
                Console.WriteLine("Reserva realizada correctamente.");
            }
            else
            {
                Console.WriteLine("Vehículo no disponible o no encontrado.");
            }
        }

        // Método para cancelar una reserva
        static void CancelarReserva(SistemaReservas sistema)
        {
            Console.Write("Ingrese la marca del vehículo cuya reserva desea cancelar: ");
            string marca = Console.ReadLine();

            Vehiculo vehiculo = sistema.BuscarVehiculoPorMarca(marca);
            if (vehiculo != null)
            {
                sistema.CancelarReservaPorVehiculo(vehiculo);
                Console.WriteLine("Reserva cancelada.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        // Método para mostrar información de los vehículos registrados
        static void MostrarVehiculos(SistemaReservas sistema)
        {
            sistema.MostrarTodosLosVehiculos();
        }
    }
}