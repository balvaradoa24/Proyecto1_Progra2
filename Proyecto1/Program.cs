
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
            int tamano = 10;
            int[] edad = new int[tamano];
            int[] cedula = new int[tamano];
            int[] numeroPago = new int[tamano];
            int[] numeroCaja = new int[tamano];
            int[] tipoServicio = new int[tamano];
            int opcion = 0;
            String[] nombre = new String[tamano];
            String[] apellido1 = new String[tamano];
            String[] apellido2 = new String[tamano];
            DateTime fecha = DateTime.Now;
            DateTime hora = DateTime.Now;
            double[] numeroFactura = new double[tamano];
            double[] montoPagar = new double[tamano];
            double[] montoComision = new double[tamano];
            double[] montoDeducido = new double[tamano];
            double[] montoCliente = new double[tamano];
            double[] vuelto = new double[tamano];


            menu();

            void inicializar()
            {
                cedula = Enumerable.Repeat(0, tamano).ToArray<int>();
                nombre = Enumerable.Repeat("", tamano).ToArray<string>();
                apellido1 = Enumerable.Repeat("", tamano).ToArray<string>();
                apellido2 = Enumerable.Repeat("", tamano).ToArray<string>();
                edad = Enumerable.Repeat(0, tamano).ToArray<int>();
                numeroPago = Enumerable.Repeat(0, tamano).ToArray<int>();
                numeroCaja = Enumerable.Repeat(0, tamano).ToArray<int>();
                tipoServicio = Enumerable.Repeat(0, tamano).ToArray<int>();
                numeroFactura = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                montoPagar = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                montoComision = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                montoDeducido = Enumerable.Repeat(0.5, tamano).ToArray<double>();
                montoCliente = Enumerable.Repeat(0.5, tamano).ToArray<double>();
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
                            //ConsultarPagos();
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

                void ingresoDatos()
                {
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
                            Console.WriteLine("Ingrese el monto que pagara:"); montoCliente[i] = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("\n¿Desea calcular el salario de otro empleado? (s/n):");
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


                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine($"Numero de pago: {randomNumber}");

                        Console.WriteLine($"Fecha:              {fecha.ToShortDateString()}                                      Hora:           {hora.ToShortTimeString()}");
                        Console.WriteLine("                                                                                                                                ");
                        Console.WriteLine($"Cedula:             {cedula[i]}                                            Nombre:         {nombre[i]}");
                        Console.WriteLine($"Apellido:           {apellido1[i]}                                            Apellido 2:     {apellido2[i]}");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Tipo de Servicio    {tipoServicio[i]}                        [1-Electricidad  2-Telefono   3-Agua]");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Numero de Factura       12345                                      Monto a Pagar          {montoPagar[i]}");
                        Console.WriteLine($"Comision autorizada     498.3                                      Paga con                 {montoCliente[i]}");
                        Console.WriteLine($"Monto deducible       11851.2                                      Vuelto                   {montoCliente[i] - montoPagar[i]}");
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

                void elejitTipoServicio()
                {
                    
                    for (int i = 0; i<tamano; i++)
                    {
                      


                    } 


                }





            }

        }
    }
}




