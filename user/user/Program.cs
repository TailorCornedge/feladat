using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    internal class Program
    {
        public static string ConnectionString = "server=localhost;database=users;user=root;password=";
        public static MySqlConnection Conn = new MySqlConnection(ConnectionString);

        public static void Insertdata(string name, string email, string password)
        {
            Conn.Open();

            string sql = "INSERT INTO `data`(`Name`, `Email`, `Password`) VALUES (@name,@email,@password)";

            MySqlCommand cmd = new MySqlCommand(sql, Conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem a nevet: ");
            string name = Console.ReadLine();
            Console.WriteLine("Kérem az emailt: ");
            string email = Console.ReadLine();
            Console.WriteLine("Kérem a jelszót: ");
            string password = Console.ReadLine();

            Insertdata(name, email, password);
        }
    }
}
