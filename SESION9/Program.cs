using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SESION9
{
    internal class Program
    {
        static float caja = 0.0f;
        static float vLimpieza = 0;
        static float vAbarrotes = 0;
        static float vGolosinas = 0;
        static float vElectronicos = 0;
        static float devLimpieza = 0;
        static float devAbarrotes = 0;
        static float devGolosinas = 0;
        static float devElectronicos = 0;
        static void Main(string[] args)
        {
            Pantallap();
            Console.ReadKey();
        }

        static void Pantallap()
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("TIENDA DE DON LUCAS");
            Console.WriteLine("======================================" +
                "\n1: Registrar Venta" +
                "\n2: Registrar Devolución" +
                "\n3: Cerrar Caja");
            Console.WriteLine("======================================");



            int opciones = valor("Ingrese una opción: ");

            switch (opciones)
            {
                case 1:
                    Console.Clear();
                    RegistrarVenta();
                    break;

                case 2:
                    Console.Clear();
                    RegistrarDevoluciones();
                    break;

                case 3:
                    Console.Clear();
                    Mostrarcaja();
                    break;

                default:
                    Console.WriteLine("Escoja una opción");
                    break;
            }
            Console.Clear();
        }

        static void RegistrarVenta()
        {

            Console.WriteLine("======================================");
            Console.WriteLine("Registrar Venta de: ");
            Console.WriteLine("======================================" +
                "\n1: Limpieza" +
                "\n2: Abarrotes" +
                "\n3: Golosinas" +
                "\n4: Electrónicos" +
                "\n5: <- Regresar");
            Console.WriteLine("======================================");

            int registrarV = valor("Ingrese una opción: ");
            switch (registrarV)
            {
                case 1:
                    RegistrarVentaPro("Limpieza", ref vLimpieza);
                    break;

                case 2:
                    RegistrarVentaPro("Abarrotes", ref vAbarrotes);
                    break;

                case 3:
                    RegistrarVentaPro("Golosinas", ref vGolosinas);
                    break;

                case 4:
                    RegistrarVentaPro("Electronicos", ref vElectronicos);
                    break;

                case 5:
                    Console.Write("Regresando al menú principal");
                    Pantallap();
                    break;
            }
        }
        static void RegistrarVentaPro(string tipoProducto, ref float vendidos)
        {
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Registrar venta de " + tipoProducto);
            Console.WriteLine("=======================");
            float cantidadV = valorValidar("ingrese cantidad (unidades) : ");
            float precioV = valorValidar("Ingrese precio : S/ ");
            vendidos += cantidadV;
            float totalV = cantidadV * precioV;
            caja += totalV;
            Console.WriteLine("=======================");
            Console.WriteLine("Se han ingresado " + cantidadV + " unidades de " + tipoProducto);
            Console.WriteLine($"Se han ingresado S/ {(cantidadV * precioV):f2} en caja");
            Console.WriteLine("=======================");
            Console.WriteLine("1: Registrar más productos de esta categoría");
            Console.WriteLine("2: <- Regresar al menú principal");
            Console.WriteLine("=======================");
            int opcion = valor("Ingrese una opción: ");
            if (opcion == 1)
            {
                Console.Clear();
                RegistrarVentaPro(tipoProducto, ref vendidos);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                Pantallap();
            }
            else
            {
                Console.WriteLine("Opción no válida. Regresando al menú principal.");
                Pantallap();
            }
        }
        static void RegistrarDevoluciones()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Registrar Devoluciones de: ");
            Console.WriteLine("======================================" +
                "\n1: Limpieza" +
                "\n2: Abarrotes" +
                "\n3: Golosinas" +
                "\n4: Electrónicos" +
                "\n5: <- Regresar");
            Console.WriteLine("======================================");
            int registrarV = valor("Ingrese una opcion : ");
            switch (registrarV)
            {
                case 1:
                    RegistrarDevolucionPro("Limpieza", ref devLimpieza);
                    break;
                case 2:
                    RegistrarDevolucionPro("Abarrotes", ref devAbarrotes);
                    break;
                case 3:
                    RegistrarDevolucionPro("Golosinas", ref devGolosinas);
                    break;
                case 4:
                    RegistrarDevolucionPro("Electronicos", ref devElectronicos);
                    break;
                case 5:
                    Console.Write("Regresando al menú principal");
                    Pantallap();
                    break;
            }
        }
        static void RegistrarDevolucionPro(string tipoProductoDevolucion, ref float devueltos)
        {
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Registrar venta de " + tipoProductoDevolucion);
            Console.WriteLine("=======================");
            float cantidadV = valorValidar("ingrese cantidad (unidades) : ");
            float precioV = valorValidar("Ingrese precio : S/ ");
            devueltos += cantidadV;
            float totalDev = cantidadV * precioV;
            caja -= totalDev;
            Console.WriteLine("=======================");
            Console.WriteLine("Se han regresado " + cantidadV + " unidades de " + tipoProductoDevolucion);
            Console.WriteLine($"Se han ingresado S/ {(cantidadV * precioV):f2} en caja");
            Console.WriteLine("=======================");
            Console.WriteLine("1: Registrar más productos de esta categoría");
            Console.WriteLine("2: <- Regresar al menú principal");
            Console.WriteLine("=======================");
            int opcion = valor("Ingrese una opción: ");
            if (opcion == 1)
            {
                Console.Clear();
                RegistrarVentaPro(tipoProductoDevolucion, ref devueltos);
            }
            else if (opcion == 2)
            {
                Console.Clear();
                Pantallap(); ;
            }
            else
            {
                Console.Write("Opción no válida. Regresando al menú principal.");
                Pantallap();
            }
        }
        static void Mostrarcaja()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Cerrando Caja");
            Console.WriteLine("=======================");
            Console.WriteLine("Totales");
            Console.WriteLine("=======================");

            MostrarcajaPorRubro("Limpieza", vLimpieza, devLimpieza);
            MostrarcajaPorRubro("Abarrotes", vAbarrotes, devAbarrotes);
            MostrarcajaPorRubro("Golosinas", vGolosinas, devGolosinas);
            MostrarcajaPorRubro("Electronicos", vElectronicos, devElectronicos);

            Console.WriteLine($"Queda en caja S/{caja:f2}");
            Console.ReadKey();
        }
        static void MostrarcajaPorRubro(string rubro, float vendidos, float devueltos)
        {
            float total = vendidos - devueltos;

            Console.WriteLine($"\t\t| {vendidos} vendidos");
            Console.WriteLine($"{rubro} \t| {devueltos} devueltos");
            Console.WriteLine($"\t\t| {total} en total");
            Console.WriteLine($"\t\t| S/ {(total):f2} en caja");
            Console.WriteLine("=======================");
        }
        public static int valor(string pretext)
        {
            Console.Write(pretext);
            string val = Console.ReadLine();
            return int.Parse(val);
        }
        public static float valorValidar(string pretext2)
        {
            Console.Write(pretext2);
            string vale = Console.ReadLine();
            return float.Parse(vale);
        }
        public static void escribir(string texto)
        {
            Console.WriteLine(texto);

        }
    }
}
