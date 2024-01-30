using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ejemplo3
{
    internal class Program
    {
        /*  consultas a una base de datos MySQL en paralelo utilizando el framework de tareas en C# */
        static async Task Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=3pos3;Uid=root;Pwd=ERIKmama21;";

            // Ejemplo simulado de un evento de click
            await OnButtonClick(connectionString);
            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.Read();
        }

        static async Task OnButtonClick(string connectionString)
        {
            // Se ejecutan dos consultas a la base de datos en paralelo
            var task1 = ExecuteQueryAsync(connectionString, "SELECT * FROM usuarios");
            var task2 = ExecuteQueryAsync(connectionString, "SELECT * FROM productos");

            await Task.WhenAll(task1, task2);

          
        }

        static async Task ExecuteQueryAsync(string connectionString, string query)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"{reader.GetName(i)}: {reader.GetValue(i)}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
