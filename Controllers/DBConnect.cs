using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WEB_SERVICE_TEMPLATE.Controllers
{
    public class DBConnect
    {
        // Windows Authentication (Integrated Security)
        static readonly string connectionString = "Server=localhost;Database=MyDatabase;Integrated Security=true;TrustServerCertificate=true;";
        
        public static void AddData(string name, string email, string message)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string query = "INSERT INTO YourTable (Name, Email, Message) VALUES (@name, @email, @message)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@message", message);
                        
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Dados inseridos com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir dados: {ex.Message}");
            }
        }

        public static DataTable GetData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string query = "SELECT * FROM dbo.Clientes";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar dados: {ex.Message}");
            }
            return dt;
        }
    }
}
