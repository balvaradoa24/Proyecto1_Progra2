
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Proyecto1
{
	class Ejercicio_1_Libro_Consola
	{
		static void Main(string[] args)
		{
			int tamano = 10;
			String[] nombre = new String[tamano];
			String[] apellido1 = new String[tamano];
			String[] apellido2 = new String[tamano];
			DateTime[] fecha= new DateTime[tamano];
			DateTime[] hora = new DateTime[tamano];
			int[] edad = new int[tamano];
			int[] cedula = new int[tamano];
            int[] numeroPago = new int[tamano];
            int[] numeroCaja = new int[tamano];
			int[] tipoServicio = new int[tamano];
            double[] numeroFactura = new double[tamano];
            double[] montoPagar = new double[tamano];
			double[] montoComision = new double[tamano];
			double[] montoDeducido= new double[tamano];
			double[] montoCliente = new double[tamano];
			double[] vuelto = new double[tamano];
			int opcion = 0;
			menu();

			void inicializar()
			{	
				cedula = Enumerable.Repeat(0, tamano).ToArray<int>();
				nombre = Enumerable.Repeat("", tamano).ToArray<string>();
				apellido1= Enumerable.Repeat("", tamano).ToArray<string>();
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
                            //RealizarPagos();
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







            }

		}
	}
}




