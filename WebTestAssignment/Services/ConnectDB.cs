using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;
using Dapper;

namespace WebTestAssignment.Services
{
    /// <summary>
    /// Сервис подключения к базе.
    /// </summary>
    public class ConnectDB
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source = KOMPUTER\MSSQLSERVER01;Initial Catalog = WebProject;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
