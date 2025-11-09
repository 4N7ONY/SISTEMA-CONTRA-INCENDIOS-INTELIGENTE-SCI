using SECURITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HISTORIAL;


namespace PROYECTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool acceso = User.IniciarSesion();
            if (!acceso) return;

            Random random = new Random();
            int opcion;
            int s1, s2, s3, s4;
            int h1, h2, h3, h4;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.WriteLine("       SISTEMA CONTRA INCENDIOS INTELIGENTE - SCI          ");
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.ResetColor();
                Console.WriteLine("[1] Mostrar zonas de sensores");
                Console.WriteLine("[2] Mostrar Leyenda de estado de Temperaturas");
                Console.WriteLine("[3] Ejecutar monitoreo de temperatura");
                Console.WriteLine("[4] Restablecer sistema");
                Console.WriteLine("[5] Ver historial");
                Console.WriteLine("[0] Salir");
                Console.Write("\nSeleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());


                switch (opcion)
                {
                    case 1: UbicacionSensores(); break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n═════════════════════════════════════════");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("      LEYENDA DE ESTADO DE ZONAS    ");
                        Console.ResetColor();
                        Console.WriteLine("═════════════════════════════════════════\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Verde  → Temperatura estable (0°C - 180°C)");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Rojo   → Temperatura crítica (181°C o más)");
                        Console.ResetColor();
                        Console.WriteLine("\n═════════════════════════════════════════");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Verde  → Nivel de humo seguro (0% - 15%)");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" Amarillo   → Alto nivel de humo (15% o más)");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.WriteLine("═════════════════════════════════════════\n");
                        Console.WriteLine("\nPresione ENTER para volver al menú...");
                        Console.ReadLine(); break;

                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=== MONITOREO EN TIEMPO REAL ===");
                        Console.WriteLine("Presione ENTER para detener el monitoreo...\n");
                        Console.ResetColor();

                        s1 = s2 = s3 = s4 = 25;
                        h1 = h2 = h3 = h4 = 0;

                        while (!Console.KeyAvailable)
                        {
                            // incrementar valores aleatoriamente
                            s1 += random.Next(1, 40);
                            s2 += random.Next(1, 40);
                            s3 += random.Next(1, 40);
                            s4 += random.Next(1, 40);

                            h1 += random.Next(0, 3);
                            h2 += random.Next(0, 3);
                            h3 += random.Next(0, 3);
                            h4 += random.Next(0, 3);

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("=== MONITOREO EN TIEMPO REAL ===");
                            Console.WriteLine("Presione ENTER para detener el monitoreo...\n");
                            Console.ResetColor();

                            string zona1 = "Zona 1 - Generador";
                            MostrarZona(zona1, s1, h1);
                            HistorialData.AgregarDato(zona1, s1, h1);
                            string zona2 = "Zona 2 - Sala de control";
                            MostrarZona(zona2, s2, h2);
                            HistorialData.AgregarDato(zona2, s2, h2);
                            string zona3 = "Zona 3 - Almacén combustible";
                            MostrarZona(zona3, s3, h3);
                            HistorialData.AgregarDato(zona3, s3, h3);
                            string zona4 = "Zona 4 - Transformadores";
                            MostrarZona(zona4, s4, h4);
                            HistorialData.AgregarDato(zona4, s4, h4);
                            Console.WriteLine("\n═════════════════════════════════════════");

                            if (s1 > 180 || s2 > 180 || s3 > 180 || s4 > 180)
                            { EmergenciaFuego(s1, s2, s3, s4, h1, h2, h3, h4); }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Sistema estable. Todas las zonas seguras.");
                                Console.ResetColor();
                            }
                            Console.WriteLine("═════════════════════════════════════════");
                            Thread.Sleep(6000);
                        }
                        while (Console.KeyAvailable)
                            Console.ReadKey(true);

                        Console.WriteLine("\nMonitoreo detenido. Presione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Restableciendo sistema...");

                        Thread.Sleep(1200);
                        Console.WriteLine("Sistema restablecido con éxito.");
                        Console.ResetColor();
                        Thread.Sleep(800);
                        break;

                    case 5: HistorialData.MostrarHistorial(); break;

                    case 0:
                        Console.WriteLine("\nCerrando el sistema...");
                        Thread.Sleep(800);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        break;
                }

            } while (opcion != 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nGracias por confiar en SCI");
            Console.ResetColor();
        }

        static void UbicacionSensores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== UBICACIÓN SENSORES ===\n");
            Console.ResetColor();

            Console.WriteLine("             CENTRO DE MONITOREO             ");
            Console.WriteLine("─────────────────────────────────────────────");

            Console.WriteLine("\n Zona 4 - Área de transformadores");
            Console.WriteLine(" ┌─────────────────────────────────────────┐");
            Console.WriteLine(" │  Sensor D: Transformadores              │");
            Console.WriteLine(" │  Estado: Operativo                      │");
            Console.WriteLine(" └─────────────────────────────────────────┘");

            Console.WriteLine("\n Zona 3 - Almacén de combustible");
            Console.WriteLine(" ┌─────────────────────────────────────────┐");
            Console.WriteLine(" │  Sensor C: Combustible                  │");
            Console.WriteLine(" │  Estado: Operativo                      │");
            Console.WriteLine(" └─────────────────────────────────────────┘");

            Console.WriteLine("\n Zona 2 - Sala de control");
            Console.WriteLine(" ┌─────────────────────────────────────────┐");
            Console.WriteLine(" │  Sensor B: Sala de control              │");
            Console.WriteLine(" │  Estado: Operativo                      │");
            Console.WriteLine(" └─────────────────────────────────────────┘");

            Console.WriteLine("\n Zona 1 - Generador principal");
            Console.WriteLine(" ┌─────────────────────────────────────────┐");
            Console.WriteLine(" │  Sensor A: Generador                    │");
            Console.WriteLine(" │  Estado: Operativo                      │");
            Console.WriteLine(" └─────────────────────────────────────────┘");

            Console.WriteLine("\n─────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Todos los sensores activos y reportando correctamente.");
            Console.ResetColor();

            Console.WriteLine("\nPresione ENTER para volver al menú...");
            Console.ReadLine();
        }

        static void EmergenciaFuego(double s1, double s2, double s3, double s4, int h1, int h2, int h3, int h4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ¡EMERGENCIA DETECTADA! ");
            Console.ResetColor();
            MostrarZonasCriticas(s1, s2, s3, s4, h1, h2, h3, h4);
            SonidoAlarma();
        }

        static void MostrarZonasCriticas(double s1, double s2, double s3, double s4, int h1, int h2, int h3, int h4)
        {
            if (s1 > 180) Console.WriteLine("Zona 1 (Generador principal) crítica");
            if (s2 > 180) Console.WriteLine("Zona 2 (Sala de control) crítica");
            if (s3 > 180) Console.WriteLine("Zona 3 (Almacén combustible) crítica");
            if (s4 > 180) Console.WriteLine("Zona 4 (Transformadores) crítica");
        }
        static void SonidoAlarma()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\nLuces estroboscópicas: ACTIVADAS ");
            Console.WriteLine("Rociadores de agua: ACTIVADOS ");
            Console.WriteLine("Alarma: Activada");
            Thread.Sleep(1000);
            Console.WriteLine("Evacuar Zona!!!");
            Console.ResetColor();
            for (int i = 0; i < 1; i++)
            {
                Console.Beep(1000, 5000);
                Thread.Sleep(250);
                Console.Beep(1500, 2500);
            }
        }
        static void EstadoSistema(bool alarmaActiva)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== ESTADO DEL SISTEMA ===\n");
            Console.ResetColor();
            if (alarmaActiva)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALARMA: Estado Bueno ");
                Console.WriteLine("Luces estroboscópicas: Estado Bueno ");
                Console.WriteLine("Rociadores de agua: Estado Bueno ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sistema operativo y sin alertas.");
                Console.WriteLine("Luces de emergencia: APAGADAS");
                Console.ResetColor();
            }
            Console.WriteLine("\nPresione ENTER para volver...");
            Console.ReadLine();
        }
        static void MostrarTemperaturaZona(string zona, double temp)
        {
            if (temp <= 180) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(zona + ": " + temp + "°C");
            Console.ResetColor();
        }

        static void MostrarZona(string nombreZona, double temperatura, int humo)
        {
            Console.Write(nombreZona + ": ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Temperatura " + temperatura + "°C  ");
            Console.ResetColor();

            // Mostrar Temperatura
            if (temperatura > 180)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Alta temperatura  ");
                Console.ResetColor();
                // Mostrar nivel de humo
                Console.Write("| Humo: " + humo + "% ");
                if (humo >= 15)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" Alto nivel de humo");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Nivel de humo seguro");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Temperatura estable  ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}