using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Todos los metodos son completados.");
            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Parallel.Invoke(
                () => Method1(),
                () => Method2(),
                () => Method3()
            );

            Console.WriteLine("Todos los metodos son completados.");
            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.Read();
        }
    }

    static void Method1()
    {
        Console.WriteLine("Metodo 1 esta corriendo.");
    }

    static void Method2()
    {
        Console.WriteLine("Metodo 2 esta corriendo.");
    }

    static void Method3()
    {
        Console.WriteLine("Metodo 3 esta corriendo.");
    }
}

