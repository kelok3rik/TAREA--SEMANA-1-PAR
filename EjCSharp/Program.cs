using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjCSharp
{
    internal class Program
    {
        /* 
        conjuntos de números enteros y utiliza Tasks para calcular la suma de cada conjunto en paralelo,
        aprovechando la capacidad de procesamiento paralelo de la CPU. */
        // Erik Cruz 1-18-0759
        static void Main(string[] args)
        {

           
            int[] array1 = { 1, 2, 3, 4, 5, 7, 20, };
            int[] array2 = { 6, 7, 8, 9, 10 };

     
            Task<int> tarea1 = Task.Run(() => SumarArray(array1));
            Task<int> tarea2 = Task.Run(() => SumarArray(array2));

            // Esperamos a que ambas tareas terminen
            Task.WhenAll(tarea1, tarea2).Wait();

            int sumaArray1 = tarea1.Result;
            int sumaArray2 = tarea2.Result;

            Console.WriteLine("Suma del conjunto 1:"+ sumaArray1);
            Console.WriteLine("Suma del conjunto 2:"+ sumaArray2);
            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.Read();
        }

        static int SumarArray(int[] conjunto)
        {
            int suma = 0;
            foreach (int numero in conjunto)
            {
                suma += numero;
            }
            return suma;
        }


    }
}
