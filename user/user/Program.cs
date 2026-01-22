using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
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
            cmd.Parameters.AddWithValue("@regtime", DateTime.Now);

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        public static void ReadData()
        {
            Conn.Open();

            string sql = "SELECT * FROM data";

            MySqlCommand cmd = new MySqlCommand(sql, Conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"" +
                    $"{dr.GetInt32(0)} " +
                    $"{dr.GetString(1)} " +
                    $"{dr.GetString(2)} " +
                    $"{dr.GetString(3)} " +
                    $"{dr.GetDateTime(5)}");
            }
            Conn.Close();
        }
        public static void DeleteUser(int id)
        {
            Conn.Open();

            string sql = "DELETE FROM data WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Conn.Close() ;
        }
        public static void UpdateUser(int id, string name, string email, string password)
        {
            Conn.Open();

            string sql = "UPDATE `data` SET `Name`= @name,`Email`= @email,`Password`= @pass WHERE `Id` = @id";

            MySqlCommand cmd = new MySqlCommand(sql, Conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Válassz menüpontot");
            Console.WriteLine("1. Lekérdezés");
            Console.WriteLine("2. Beszúrás");
            Console.WriteLine("3. Módosítás");
            Console.WriteLine("4. Törlés");
            byte menu;

            do
            {
                menu = byte.Parse(Console.ReadLine());
            } while (menu < 1 || menu > 4);

            switch (menu)
            {
                case 1:
                    {
                        Console.WriteLine("\n");
                        ReadData();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Kérem a nevet:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kérem az emailt:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Kérem a jelszót:");
                        string password = Console.ReadLine();

                        Insertdata(name, email, password);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Kérem az azonosítót:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Kérem a nevet:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kérem az emailt:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Kérem a jelszót:");
                        string password = Console.ReadLine();

                        UpdateUser(id, name, email, password);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Kérem a törlendő user Id-jét");
                        int id = int.Parse(Console.ReadLine());
                        DeleteUser(id);
                        break;
                    }
            }


            
        }
    }
}
