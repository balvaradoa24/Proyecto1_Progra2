
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Proyecto1
{
    class Proyecto1
    {
        static void Main(string[] args)
        {

            int tamano = 1;
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

                    if (opcion < 1 || opcion > 7)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("=================================================");
                        Console.WriteLine("Por favor ingrese un valor: 1, 2, 3, 4, 5, 6 o 7");
                        Console.WriteLine(Environment.NewLine);
                    }

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
                            eliminarPagos(numeroPago);
                            break;
                        case 6:
                            submenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo...");
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
                    try
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            int cedulaNumero;
                            Console.WriteLine("Ingrese la cédula: ");
                            while (true)
                            {
                                if (!int.TryParse(Console.ReadLine(), out cedulaNumero) || cedulaNumero < 0)
                                {
                                    Console.WriteLine("No es un número válido, ingrese un número mayor o igual a 0");
                                    Console.WriteLine("Ingrese la cédula: ");
                                }
                                else
                                {
                                    cedula[i] = cedulaNumero;
                                    break;
                                }
                            }
                            Console.Clear();

                            Console.WriteLine("Ingrese el nombre: ");
                            nombre[i] = Console.ReadLine();

                            while (true)
                            {
                                if (Regex.IsMatch(nombre[i], @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine(nombre[i]);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error: El nombre no puede contener números ni caracteres especiales");
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nombre: ");
                                    nombre[i] = Console.ReadLine();
                                    break;
                                }
                            }

                            Console.Clear();

                            Console.WriteLine("Ingrese el primer apellido: ");
                            apellido1[i] = Console.ReadLine();

                            while (true)
                            {
                                if (Regex.IsMatch(apellido1[i], @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine(apellido1[i]);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error: El apellido no puede contener números ni caracteres especiales");
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el apellido 1 nuevamente: ");
                                    apellido1[i] = Console.ReadLine();
                                    break;
                                }
                            }

                            Console.Clear();

                            Console.WriteLine("Ingrese el segundo apellido: ");
                            apellido2[i] = Console.ReadLine();

                            while (true)
                            {
                                if (Regex.IsMatch(apellido2[i], @"^[a-zA-Z]+$"))
                                {
                                    Console.WriteLine(apellido2[i]);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Error: El apellido no puede contener números ni caracteres especiales");
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el apellido 2 nuevamente: ");
                                    apellido2[i] = Console.ReadLine();
                                    break;
                                }
                            }

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

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ocurrió un error por favor verifique e intente de nuevo: " + e.Message);
                    }

                    Console.WriteLine("\n¿Desea Continuar S/N?");
                    continuar = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");

                    // Console.ReadKey();
                    // Console.Clear();
                }
            }

            void realizarPago()
            {
                ingresoDatos();

                Console.WriteLine(" ");
                Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                Console.WriteLine("                  Tienda la Favorita  -  Ingreso de Datos");
                Console.WriteLine("                                     ");

                Random aleatorio = new Random();
                var randomNumber = aleatorio.Next(0, 10);


                for (int i = 0; i < tamano; i++)
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
                    Console.WriteLine($"Comision autorizada    {montoComision[i]}                                       Paga con                 {montoPagaCliente[i]}");
                    Console.WriteLine($"Monto deducible       {montoDeducido[i]}                                       Vuelto                   {montoPagaCliente[i] - montoPagar[i]}");


                    Console.WriteLine(" ");
                }
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
                        Console.WriteLine($"Fecha:              {fecha.ToShortDateString()}                                      Hora:           {hora.ToShortTimeString()}");
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

                for (int i = 0; i < tamano; i++)
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
                            case 'E':
                                Console.WriteLine("Ingrese el primer apellido: ");
                                apellido1[i] = Console.ReadLine();
                                break;
                            case 'D':
                                Console.WriteLine("Ingrese el nombre: ");
                                nombre[i] = Console.ReadLine();
                                break;
                            case 'F':
                                Console.WriteLine("Ingrese el primer apellido2: ");
                                apellido2[i] = Console.ReadLine();
                                break;
                            case 'G':
                                Console.WriteLine("Ingrese el tipo de servicio:   [1-Electricidad  2-Telefono   3-Agua]");
                                tipoServicio[i] = int.Parse(Console.ReadLine());
                                break;
                            case 'H':
                                Console.WriteLine("Ingrese el número de factura: ");
                                numeroFactura[i] = double.Parse(Console.ReadLine());
                                break;
                            case 'I':
                                Console.WriteLine("Ingrese el monto entregado: ");
                                montoPagaCliente[i] = double.Parse(Console.ReadLine());
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

            void eliminarPagos(int[] numeroPago)
            {
                bool encontrado = false;
                char continuar = 's';
                Console.WriteLine("Ingrese el nùmero de pago a eliminar: ");
                int numbPago = int.Parse(Console.ReadLine());
                int indiceEliminar = Array.IndexOf(numeroPago, numbPago);


                for (int i = 0; i < numeroPago.Length; i++)
                {
                    if (numbPago.Equals(numeroPago[i]))
                    {
                        Console.WriteLine("\n¿Está seguro de eliminar el dato S/N?");
                        continuar = Console.ReadKey().KeyChar;
                        Console.WriteLine("\n");
                        encontrado = true;
                        if (indiceEliminar != -1)
                        {
                            int[] nuevoVector = new int[numeroPago.Length - 1];
                            int j = 0;
                            for (int e = 0; e < numeroPago.Length; e++)
                            {
                                if (e != indiceEliminar)
                                {
                                    nuevoVector[j++] = numeroPago[i];
                                }
                                Console.WriteLine("La informaciòn ya fue eliminada");
                            }
                        }
                    }
                    else
                    {
                        encontrado = false;
                        Console.WriteLine("La informaciòn no fue eliminada");
                    }
                }
            }

            void submenuReportes()
            {
                int opcionReporte = 0;

                do
                {
                    Console.WriteLine("\nSubmenú de Reportes");
                    Console.WriteLine("1. Reporte de todos los Pagos");
                    Console.WriteLine("2. Reporte de pagos por tipo de Servicio");
                    Console.WriteLine("3. Reporte de dinero comisionado por servicios");
                    Console.WriteLine("4. Reporte de pagos por código de caja");
                    Console.WriteLine("5. Regresar Menú Principal");
                    Console.Write("Seleccione una opción: ");
                    opcionReporte = Convert.ToInt32(Console.ReadLine());

                    if (opcionReporte < 1 || opcionReporte > 5)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("=================================================");
                        Console.WriteLine("Por favor ingrese un valor: 1, 2, 3, 4, 5, 6 o 7");
                        Console.WriteLine(Environment.NewLine);
                    }

                    switch (opcionReporte)
                    {
                        case 1:
                            Console.WriteLine("Mostrando reporte de todos los pagos realizados:");
                            for (int i = 0; i < tamano; i++)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                                Console.WriteLine("                  Tienda la Favorita  -  Reporte Todos los Pagos");
                                Console.WriteLine("      ");
                                Console.WriteLine("#Pago  Fecha/Hora Pago  Cedula   Nombre Apellido1 Apellido2 Monto a Pagar:");
                                Console.WriteLine("==============================================================================================================================================================================");
                                Console.WriteLine($"Pago {i + 1}: {fecha.ToShortDateString()}  {hora.ToShortTimeString()} {cedula[i]},   {nombre[i]},       {apellido1[i]},         {apellido1[i]},   {montoPagar[i]}");
                                Console.WriteLine("==============================================================================================================================================================================");
                                Console.WriteLine("Total de Registros:                                      Monto Total: ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("      ");
                                Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                                Console.ReadKey();
                                Console.WriteLine("\n");

                            }
                            break;
                        case 2:
                            Console.WriteLine(" ");
                            Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                            Console.WriteLine("                  Tienda la Favorita  -  Reporte Todos los Pagos Por Tipo de Servicio");
                            Console.WriteLine("==============================================================================================================================================================================");
                            Console.WriteLine("Seleccione el tipo de servicio que desea ver en el reporte:                [1]Electricidad  [2]Teléfono   [3]Agua");
                            Console.WriteLine("==============================================================================================================================================================================");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            int tipoSeleccionado = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                            Console.ReadKey();
                            Console.WriteLine("\n");

                            Console.WriteLine(" ");
                            Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                            Console.WriteLine("                  Tienda la Favorita  -  Reporte Todos los Pagos Por Tipo de Servicio");
                            Console.WriteLine($"{nombreServicio[tipoSeleccionado - 1]}:");
                            for (int i = 0; i < tamano; i++)
                            {
                                if (tipoServicio[i] == tipoSeleccionado)
                                {
                                    Console.WriteLine("#Pago  Fecha/Hora Pago  Cedula   Nombre Apellido1 Apellido2 Monto a Pagar:");
                                    Console.WriteLine("==============================================================================================================================================================================");
                                    Console.WriteLine($"Pago {i + 1}: {fecha.ToShortDateString()}  {hora.ToShortTimeString()} {cedula[i]},   {nombre[i]},       {apellido1[i]},         {apellido1[i]},   {montoPagar[i]}");
                                    Console.WriteLine("==============================================================================================================================================================================");
                                    Console.WriteLine("Total de Registros:                                      Monto Total: ");
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                            Console.ReadKey();
                            Console.WriteLine("\n");
                            break;
                        case 3:
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
                            Console.WriteLine("Reporte Dinero Comisionado - Desglose por Tipo de Servicio");
                            Console.WriteLine("=============================================================");
                            Console.WriteLine("ITEM                  CANT.Transacciones               Total Comisionado");
                            Console.WriteLine("1-Electricidad            5                                   5600     ");
                            Console.WriteLine("2-Telefono                2                                   9800     ");
                            Console.WriteLine("3-Agua                    3                                   4800     ");

                            Console.WriteLine("=============================================================");
                            Console.WriteLine($"Total:                   10                              {totalElectricidad + totalTelefono + totalAgua}");
                            break;
                        case 4:
                            Console.WriteLine(" ");
                            Console.WriteLine("                  Sistema de Pago de Servicios Publicos");
                            Console.WriteLine("                  Tienda la Favorita  -  Reporte Todos los Pagos Por Codigo de Cajero");
                            Console.WriteLine("==============================================================================================================================================================================");
                            Console.WriteLine("Seleccione el codigo de Cajero:                [1]Caja#1  [2]Caja#2   [3]Caja#3");
                            Console.WriteLine("==============================================================================================================================================================================");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            int codigoSeleccionado = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                            Console.ReadKey();
                            Console.WriteLine("\n");

                            Console.WriteLine($"{codigoSeleccionado}:");
                            for (int i = 0; i < tamano; i++)
                            {
                                if (numeroCaja[i] == codigoSeleccionado)
                                {
                                    Console.WriteLine("#Pago  Fecha/Hora Pago  Cedula   Nombre Apellido1 Apellido2 Monto a Pagar:");
                                    Console.WriteLine("==============================================================================================================================================================================");
                                    Console.WriteLine($"Pago {i + 1}: {fecha.ToShortDateString()}  {hora.ToShortTimeString()} {cedula[i]},   {nombre[i]},       {apellido1[i]},         {apellido1[i]},   {montoPagar[i]}");
                                    Console.WriteLine("==============================================================================================================================================================================");
                                    Console.WriteLine("Total de Registros:                                      Monto Total: ");
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                 Presione cualquier Tecla para ver Registro");
                            Console.ReadKey();
                            Console.WriteLine("\n");
                            break;
                        case 5:
                            Console.WriteLine("Regresando al Menú Principal...");
                            break;
                    }
                } while (opcionReporte != 5);
            }
        }
    }
}





