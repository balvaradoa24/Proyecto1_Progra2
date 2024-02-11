
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Proyecto1
    {
        static void Main(string[] args)
        {

            int tamano = 1;
            int[] edad = new int[tamano];
            int[] cedula = new int[tamano];
            int[] numeroPago = new int[tamano];
            int[] numeroCaja = new int[tamano];
            int[] tipoServicio = new int[tamano];
            int opcion = 0;
            String[] nombre = new String[tamano];
            String[] apellido1 = new String[tamano];
            String[] apellido2 = new String[tamano];
            string[] nombreServicio = new string[tamano];
            DateTime fecha = DateTime.Now;
            DateTime hora = DateTime.Now;
            double[] numeroFactura = new double[tamano];
            double[] montoPagar = new double[tamano];
            double[] montoPagaCliente = new double[tamano];
            double[] montoComision = new double[tamano];
            double[] montoDeducido = new double[tamano];
            double[] vuelto = new double[tamano];

            menu();
            void inicializar()
            {

                cedula = Enumerable.Repeat(0, tamano).ToArray<int>();
                nombre = Enumerable.Repeat("", tamano).ToArray<string>();
                apellido1 = Enumerable.Repeat("", tamano).ToArray<string>();
                apellido2 = Enumerable.Repeat("", tamano).ToArray<string>();
                numeroPago = Enumerable.Repeat(0, tamano).ToArray<int>();
                numeroCaja = Enumerable.Repeat(0, tamano).ToArray<int>();
                tipoServicio = Enumerable.Repeat(0, tamano).ToArray<int>();
                numeroFactura = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                montoPagar = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                vuelto = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                Console.WriteLine("Los arreglos han sido inicializados...");
                Console.ReadKey();
                Console.Clear();
            }

            void menu()
            {
                do
                {
                    Console.WriteLine("Menú Principal");
                    Console.WriteLine("1. Inicializar Vectores");
                    Console.WriteLine("2. Realizar Pagos");
                    Console.WriteLine("3. Consultar Pagos");
                    Console.WriteLine("4. Modificar Pagos");
                    Console.WriteLine("5. Eliminar Pagos");
                    Console.WriteLine("6. Submenú Reportes");
                    Console.WriteLine("7. Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            inicializar();
                            break;
                        case 2:
                            realizarPago();
                            break;
                        case 3:
                            consultarPagos();
                            break;
                        case 4:
                            //ModificarPagos();
                            break;
                        case 5:
                            //EliminarPagos();
                            break;
                        case 6:
                            // SubmenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                } while (opcion != 7);
            }

            void ingresoDatos()
            {
                double electricidad = 0.04;
                double telefono = 0.055;
                double agua = 0.065;

                char continuar = 's';

                while (continuar == 's' || continuar == 'S')
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine("Ingrese la cedula: "); cedula[i] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre: "); nombre[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el primer apellido: "); apellido1[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el segundo apellido: "); apellido2[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el numero de factura: "); numeroFactura[i] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Ingrese el tipo de servicio:   [1-Electricidad  2-Telefono   3-Agua]"); tipoServicio[i] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Ingrese el monto a pagar:"); montoPagar[i] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Ingrese el monto entregado:");
                        montoPagaCliente[i] = Convert.ToDouble(Console.ReadLine());

                        switch (tipoServicio[i])
                        {
                            case 1:
                                montoComision[i] = electricidad;
                                break;
                            case 2:
                                montoComision[i] = telefono;
                                break;
                            case 3:
                                montoComision[i] = agua;
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                return;
                        }

                        montoPagar[i] = (montoPagar[i] * montoComision[i]) + montoPagar[i];

                        montoDeducido[i] = montoPagar[i] - montoComision[i];

                        vuelto[i] = montoPagaCliente[i] - montoPagar[i];

                        Console.WriteLine("\n¿Desea Continuar S/N?");
                        continuar = Console.ReadKey().KeyChar;
                        Console.WriteLine("\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            void generarNumeroPago()
            {

                ingresoDatos();

                Console.WriteLine(" ");
                Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                Console.WriteLine("                  Tienda la Favorita  -  Ingreso de Datos");
                Console.WriteLine("                                     ");

                Random aleatorio = new Random();
                var randomNumber = aleatorio.Next(0, 10);


                for (int i = 0; i < numeroPago.Length; i++)
                {
                    string input = Console.ReadLine();
                    Console.WriteLine($"Numero de pago: {randomNumber}");

                    Console.WriteLine($"Fecha:              {fecha.ToShortDateString()}                                      Hora:           {hora.ToShortTimeString()}");
                    Console.WriteLine("                                                                                                                                ");
                    Console.WriteLine($"Cedula:             {cedula[i]}                                          Nombre:         {nombre[i]}");
                    Console.WriteLine($"Apellido:           {apellido1[i]}                                          Apellido 2:     {apellido2[i]}");
                    Console.WriteLine(" ");
                    Console.WriteLine($"Tipo de Servicio    {tipoServicio[i]}                        [1-Electricidad  2-Telefono   3-Agua]");
                    Console.WriteLine(" ");
                    Console.WriteLine($"Numero de Factura       12345                                      Monto a Pagar          {montoPagar[i]}");
                    Console.WriteLine($"Comision autorizada    {montoComision[i]}                                   Paga con                 {montoPagaCliente[i]}");
                    Console.WriteLine($"Monto deducible       {montoDeducido[i]}                                    Vuelto                   {montoPagaCliente[i] - montoPagar[i]}");
                    int.TryParse(input, out int numero);
                    numeroPago[i] = numero;

                    Console.WriteLine(" ");
                    Console.WriteLine("                           Desea Continuar S/N?");
                    Console.WriteLine(" ");
                }
            }

            void realizarPago()
            {
                generarNumeroPago();
                Console.WriteLine("Ingrese el tipo de Pago que desea hacer");
            }

            void consultarPagos()
            {
                bool encontrado = false; ;
                Console.WriteLine("Numero de pago: ");
                int numbPago = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                for (int i = 0; i < numeroPago.Length; i++)
                {
                    if (numbPago.Equals(numeroPago[i]))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Consultar Datos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numeroPago[i]}");

                        encontrado = true;
                        break;
                    }

                    if (encontrado == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Consultar Datos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numbPago}");
                        Console.WriteLine("                 Pago no se encuentra Registrado");

                        Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                        Console.ReadKey();
                        Console.WriteLine("\n");

                    }
                }
            }


        }
    }
}




