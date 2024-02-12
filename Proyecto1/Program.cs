
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

            int tamano = 2;
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
                            consultarPagos(cedula, numeroPago, tipoServicio, nombre, apellido1, apellido2, montoPagar, montoComision, montoPagaCliente, montoDeducido, vuelto);
                            break;
                        case 4:
                            modificarPagos(cedula, numeroPago, tipoServicio, nombre, apellido1, apellido2, montoPagar, montoComision, montoPagaCliente, montoDeducido, vuelto);
                            break;
                        case 5:
                            //EliminarPagos();
                            break;
                        case 6:
                            SubmenuReportes();
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
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("Ingrese la cedula: ");
                        cedula[i] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre: ");
                        nombre[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el primer apellido: ");
                        apellido1[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el segundo apellido: ");
                        apellido2[i] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Ingrese el numero de factura: ");
                        int numFacturaInput = int.Parse(Console.ReadLine());
                        if (Array.IndexOf(numeroFactura, numFacturaInput) != -1)
                        {
                            Console.WriteLine("El número de factura ya ha sido ingresado. Ingrese otro número de factura.");
                            continue;
                        }
                        numeroFactura[i] = numFacturaInput;
                        Console.Clear();


                        do
                        {

                            Console.WriteLine("Ingrese el tipo de servicio:   [1-Electricidad  2-Telefono   3-Agua]");
                            tipoServicio[i] = int.Parse(Console.ReadLine());
                            // Validar si el número está dentro del rango
                            if (tipoServicio[i] < 1 || tipoServicio[i] > 3)
                            {
                                Console.WriteLine("El número ingresado está fuera del rango. Por favor, ingrese un número entre 1 y 3.");
                                Console.WriteLine("");

                                Console.WriteLine("Ingrese el tipo de servicio:   [1-Electricidad  2-Telefono   3-Agua]");
                                tipoServicio[i] = int.Parse(Console.ReadLine());
                            }
                        } while (tipoServicio[i] < 1 || tipoServicio[i] > 3);

                        Console.WriteLine($"El tipo de servicio ingresado es: {tipoServicio[i]}");

                        Console.Clear();
                        Console.WriteLine("Ingrese el monto a pagar:");
                        if (!double.TryParse(Console.ReadLine(), out montoPagar[i]) || montoPagar[i] <= 0)
                        {
                            Console.WriteLine("Monto a pagar no válido. Ingrese un número válido mayor que cero.");
                            continue;
                        }
                        Console.Clear();
                        Console.WriteLine("Ingrese el monto entregado:");
                        if (!double.TryParse(Console.ReadLine(), out montoPagaCliente[i]) || montoPagaCliente[i] < montoPagar[i])
                        {
                            Console.WriteLine("Monto entregado no válido. Debe ser un número válido y mayor o igual al monto a pagar.");
                            continue;
                        }

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

                        Console.ReadKey();
                        Console.Clear();
                    }
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
                    Console.WriteLine($"Numero de pago: {randomNumber}");
                    numeroPago[i] = randomNumber;
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

            void consultarPagos(int[] cedula, int[] numeroPago, int[] tipoServicio, String[] nombre, String[] apellido1, String[] apellido2, double[] montoPagar, double[] montoComision, double[] montoPagaCliente, double[] montoDeducido, double[] vuelto)
            {
                bool encontrado = false;
                Console.WriteLine("Numero de pago: ");
                int numbPago = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                for (int i = 0; i < numeroPago.Length; i++)
                {
                    Console.WriteLine($"Numero de pago: {numeroPago[i]}");
                    if (numbPago.Equals(numeroPago[i]))
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Consultar Datos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numeroPago[i]}");
                        Console.WriteLine("                                                                                                                                ");
                        Console.WriteLine($"Cedula:             {cedula[i]}                                          Nombre:         {nombre[i]}");
                        Console.WriteLine($"Apellido:           {apellido1[i]}                                           Apellido 2:     {apellido2[i]}");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Tipo de Servicio    {tipoServicio[i]}                        [1-Electricidad  2-Telefono   3-Agua]");
                        Console.WriteLine(" ");
                        Console.WriteLine($"Numero de Factura       123456                                     Monto a Pagar          {montoPagar[i]}");
                        Console.WriteLine($"Comision autorizada    {montoComision[i]}                          Paga con                 {montoPagaCliente[i]}");
                        Console.WriteLine($"Monto deducible       {montoDeducido[i]}                           Vuelto                   {montoPagaCliente[i] - montoPagar[i]}");
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

            void modificarPagos(int[] cedula, int[] numeroPago, int[] tipoServicio, String[] nombre, String[] apellido1, String[] apellido2, double[] montoPagar, double[] montoComision, double[] montoPagaCliente, double[] montoDeducido, double[] vuelto)
            {
                bool encontrado = false;
                Console.WriteLine("Numero de pago: ");
                int numbPago = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                char opcionModificar;
                // String[] guardarElementosString = new String[3];
                // int[] guardaElementosInt = new int[4];
                // double[] guardaElementosDouble = new double[4];



                for (int i = 0; i < numeroPago.Length; i++)
                {
                    Console.WriteLine($"Numero de pago: {numeroPago[i]}");
                    if (numbPago.Equals(numeroPago[i]))
                    {

                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Modificar Pagos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numeroPago[i]}");
                        Console.WriteLine("                                                                                                                                ");
                        Console.WriteLine($"C-Cedula:             {cedula[i]}                                          D-Nombre:         {nombre[i]}");
                        Console.WriteLine($"E-Apellido:           {apellido1[i]}                                           F-Apellido 2:     {apellido2[i]}");
                        Console.WriteLine(" ");
                        Console.WriteLine($"G-Tipo de Servicio    {tipoServicio[i]}                        [1-Electricidad  2-Telefono   3-Agua]");
                        Console.WriteLine(" ");
                        Console.WriteLine($"H-Numero de Factura       12345                                  Monto a Pagar          {montoPagar[i]}");
                        Console.WriteLine($"Comision autorizada    {montoComision[i]}                          I-Paga con                 {montoPagaCliente[i]}");
                        Console.WriteLine($"Monto deducible       {montoDeducido[i]}                           Vuelto                   {montoPagaCliente[i] - montoPagar[i]}");

                        // guardarElementosString[0] = nombre[i];
                        // guardarElementosString[1] = apellido1[i];
                        // guardarElementosString[2] = apellido2[i];
                        // guardarElementosString[4] = numeroFactura[i];

                        // guardaElementosInt[0] = numeroPago[i];
                        // guardaElementosInt[1] = cedula[i];
                        // guardaElementosInt[2] = tipoServicio[i];
                        // guardaElementosInt[3] = numeroPago[i];

                        // guardaElementosDouble[0] = montoPagaCliente[i];



                        // for (int j = 0; j < guardaElementos.Length; j++)
                        // {
                        //     guardaElementos[i] ==
                        // }
                        Console.Write("Seleccione opcion a modificar: ");
                        char.TryParse(Console.ReadLine(), out opcionModificar);
                        Console.Write("Nuevo Dato: ");
                        encontrado = true;


                        switch (opcionModificar)
                        {
                            case 'C':
                                Console.WriteLine("Ingrese la cedula: ");
                                cedula[i] = int.Parse(Console.ReadLine());
                                break;
                            default:
                                break;
                        }

                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Modificar Pagos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numeroPago[i]}");
                        Console.WriteLine("                                                                                                                                ");
                        Console.WriteLine($"C-Cedula:             {cedula[i]}                                          D-Nombre:         {nombre[i]}");
                        Console.WriteLine($"E-Apellido:           {apellido1[i]}                                           F-Apellido 2:     {apellido2[i]}");
                        Console.WriteLine(" ");
                        Console.WriteLine($"G-Tipo de Servicio    {tipoServicio[i]}                        [1-Electricidad  2-Telefono   3-Agua]");
                        Console.WriteLine(" ");
                        Console.WriteLine($"H-Numero de Factura       12345                                  Monto a Pagar          {montoPagar[i]}");
                        Console.WriteLine($"Comision autorizada    {montoComision[i]}                          I-Paga con                 {montoPagaCliente[i]}");
                        Console.WriteLine($"Monto deducible       {montoDeducido[i]}                           Vuelto                   {montoPagaCliente[i] - montoPagar[i]}");
                    }

                    if (encontrado == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                        Console.WriteLine("                  Tienda la Favorita  -  Modificar Pagos");
                        Console.WriteLine("      ");
                        Console.WriteLine($"Numero de pago: {numbPago}");
                        Console.WriteLine("                 Pago no se encuentra Registrado");

                        Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                        Console.ReadKey();
                        Console.WriteLine("\n");

                    }
                }
            }

            void SubmenuReportes()
            {
                int opcionReporte = 0;

                do
                {
                    Console.WriteLine("\nSubmenú de Reportes");
                    Console.WriteLine("1. Ver todos los Pagos");
                    Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                    Console.WriteLine("3. Ver Pagos por código de caja");
                    Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                    Console.WriteLine("5. Regresar Menú Principal");
                    Console.Write("Seleccione una opción: ");
                    opcionReporte = Convert.ToInt32(Console.ReadLine());

                    switch (opcionReporte)
                    {
                        case 1:
                            // Lógica para mostrar reporte de todos los pagos realizados
                            Console.WriteLine("Mostrando reporte de todos los pagos realizados:");
                            for (int i = 0; i < tamano; i++)
                            {
                                Console.WriteLine($"Pago {i + 1}: Cedula: {cedula[i]}, Nombre: {nombre[i]}, Apellido: {apellido1[i]}, Tipo de Servicio: {nombreServicio[tipoServicio[i]]}, Monto a Pagar: {montoPagar[i]}");
                            }
                            break;
                        case 2:
                            // Lógica para mostrar reporte de pagos por tipo de servicio
                            Console.WriteLine("Mostrando reporte de pagos por tipo de Servicio:");
                            Console.WriteLine("Seleccione el tipo de servicio que desea ver en el reporte:");
                            Console.WriteLine("1. Electricidad");
                            Console.WriteLine("2. Teléfono");
                            Console.WriteLine("3. Agua");
                            int tipoSeleccionado = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"Mostrando reporte de pagos para {nombreServicio[tipoSeleccionado - 1]}:");
                            for (int i = 0; i < tamano; i++)
                            {
                                if (tipoServicio[i] == tipoSeleccionado)
                                {
                                    Console.WriteLine($"Pago {i + 1}: Cedula: {cedula[i]}, Nombre: {nombre[i]}, Apellido: {apellido1[i]}, Monto a Pagar: {montoPagar[i]}");
                                }
                            }
                            break;
                        case 3:
                            // Lógica para mostrar reporte de pagos por código de caja
                            Console.WriteLine("Mostrando reporte de pagos por código de caja:");
                            Console.WriteLine("Seleccione el código de caja que desea ver en el reporte:");
                            // Suponiendo que los códigos de caja van del 1 al 5
                            int codigoSeleccionado = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"Mostrando reporte de pagos para el código de caja {codigoSeleccionado}:");
                            for (int i = 0; i < tamano; i++)
                            {
                                if (numeroCaja[i] == codigoSeleccionado)
                                {
                                    Console.WriteLine($"Pago {i + 1}: Cedula: {cedula[i]}, Nombre: {nombre[i]}, Apellido: {apellido1[i]}, Monto a Pagar: {montoPagar[i]}");
                                }
                            }
                            break;
                        case 4:
                            // Lógica para mostrar reporte de dinero comisionado por servicios
                            Console.WriteLine("Mostrando resumen del dinero comisionado por servicios:");
                            double totalElectricidad = 0;
                            double totalTelefono = 0;
                            double totalAgua = 0;

                            for (int i = 0; i < tamano; i++)
                            {
                                switch (tipoServicio[i])
                                {
                                    case 1:
                                        totalElectricidad += montoComision[i];
                                        break;
                                    case 2:
                                        totalTelefono += montoComision[i];
                                        break;
                                    case 3:
                                        totalAgua += montoComision[i];
                                        break;
                                }
                            }

                            Console.WriteLine($"Total comisionado por Electricidad: {totalElectricidad}");
                            Console.WriteLine($"Total comisionado por Teléfono: {totalTelefono}");
                            Console.WriteLine($"Total comisionado por Agua: {totalAgua}");
                            break;
                        case 5:
                            Console.WriteLine("Regresando al Menú Principal...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                } while (opcionReporte != 5);
            }


        }
    }
}





