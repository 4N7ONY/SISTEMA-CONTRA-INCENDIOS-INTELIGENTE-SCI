using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HISTORIAL
{
    public struct DatoMonitoreo
    {
        public string Zona;
        public double Temperatura;
        public int Humo;
        public string Estado;
        public DateTime Timestamp;

        public DatoMonitoreo(string zona, double temp, int humo, string estado)
        {
            Zona = zona;
            Temperatura = temp;
            Humo = humo;
            Estado = estado;
            Timestamp = DateTime.Now;
        }
    }

    public static class HistorialData
    {
        private const int MAX_CAPACIDAD = 10;

        private static DatoMonitoreo[] historial = new DatoMonitoreo[MAX_CAPACIDAD];
        private static int indice = 0;

        public static void AgregarDato(string zona, double temp, int humo)
        {
            string estado = DeterminarEstado(temp, humo);
            DatoMonitoreo nuevoDato = new DatoMonitoreo(zona, temp, humo, estado);
            historial[indice % MAX_CAPACIDAD] = nuevoDato;
            indice++;
        }

        public static void MostrarHistorial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            int elementos = Math.Min(indice, MAX_CAPACIDAD);
            Console.WriteLine("=== HISTORIAL DE MONITOREO DE ZONAS (Últimas " + elementos + " entradas) ===");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (elementos == 0)
            { Console.WriteLine("El historial está vacío. Ejecute el monitoreo (Opción 3) primero."); }
            for (int i = 0; i < elementos; i++)
            {
                int indexMostrar = (indice - elementos + i) % MAX_CAPACIDAD;
                DatoMonitoreo dato = historial[indexMostrar];

                if (dato.Zona == null) continue;

                ConsoleColor color;
                if (dato.Estado == "EMERGENCIA")
                    color = ConsoleColor.Red;
                else if (dato.Estado == "ALERTA")
                    color = ConsoleColor.Yellow;
                else
                    color = ConsoleColor.Green;

                Console.ForegroundColor = color;
                Console.WriteLine($"[{dato.Timestamp.ToString("HH:mm:ss")}] {dato.Zona} | Temp: {dato.Temperatura}°C | Humo: {dato.Humo}% | Estado: {dato.Estado}");
                Console.ResetColor();
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }

        private static string DeterminarEstado(double temp, int humo)
        {
            if (temp > 180 || humo >= 15)
                return "EMERGENCIA";
            else if (temp > 170 || humo >= 10)
                return "ALERTA";
            else
                return "SEGURO";
        }
    }
}