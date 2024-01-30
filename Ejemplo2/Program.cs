using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejemplo2
{
    internal class Program
    {

        /* Se crea un hilo que ejecuta la funcion CalcularSuma, luego el
        hilo principal espera que el hilo de calculo termine su ejecucion
        Erik Cruz 1-18-0759*/

        static long result = 0;
        static void Main(string[] args)
        {
            int N = 5;
            Thread thread = new Thread(() => CalcularSum(N));
            thread.Start();
            thread.Join();
            Console.WriteLine("Suma de los primeros" + N + "numeros: " + result);
            Console.WriteLine("Pulse ENTER para finalizar...");
            while (!Console.ReadKey().Key.Equals(ConsoleKey.Enter))
                Console.Write("\b \b");
        }

        static void CalcularSum(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                result += i;
            }
        }
    }
}
