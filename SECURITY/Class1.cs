using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SECURITY
{
    public class User
    {

        private const string usuarioCorrecto = "admin";
        private const string contrasenaCorrecta = "1234";

        public static bool IniciarSesion()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("       SISTEMA CONTRA INCENDIOS INTELIGENTE - SCI          ");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int intentos = 3;
            while (intentos > 0)
            {
                Console.Write("\nIngrese usuario: ");
                string usuario = Console.ReadLine();

                Console.Write("Ingrese contraseña: ");
                string contrasena = LeerContrasena();

                if (usuario == usuarioCorrecto && contrasena == contrasenaCorrecta)
                {


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAcceso concedido. Bienvenido al sistema.");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return true;
                }
                else
                {
                    intentos--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUsuario o contraseña incorrectos. Intentos restantes: " + intentos);
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nAcceso denegado. El sistema se cerrará...");
            Console.ResetColor();
            Thread.Sleep(1000);


            return false;
        }

        private static string LeerContrasena()
        {
            string contrasena = "";
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(true);
                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                {
                    contrasena += tecla.KeyChar;
                    Console.Write("*");
                }
                else if (tecla.Key == ConsoleKey.Backspace && contrasena.Length > 0)
                {
                    contrasena = contrasena.Substring(0, contrasena.Length - 1);
                    Console.Write("\b \b");
                }
            } while (tecla.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return contrasena;
        }
    }
}
