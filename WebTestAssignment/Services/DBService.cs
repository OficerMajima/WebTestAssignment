using Dapper;
using ModelsLibrary.Models;
namespace WebTestAssignment.Services
{
    /// <summary>
    /// Сервис выполняющий запросы в базу.
    /// </summary>
    public class DBService
    {
        public ConnectDB connectDb;

        public DBService(ConnectDB connectDb)
        {
            this.connectDb = connectDb;
        }

        /// <summary>
        /// Сверяет логин с базой.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> GetLogin(User user) 
        {
            string query = "SELECT * FROM [dbo].[UserTable] WHERE Login = @Login";

            using (var db = connectDb.sqlConnection)
            {
                db.Open();
                return await db.QueryFirstAsync<User>(query, new { Login = user.Login });
            }
        }

        /// <summary>
        /// Получает список заказов пользователя по ID.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserOrder>> GetUserOrders(User user)
        {
            string query = "SELECT * FROM [dbo].[UserOrders] WHERE UserID = @UserID";

            using (var db = connectDb.sqlConnection)
            {
                db.Open();
                return await db.QueryAsync<UserOrder>(query, new { UserID = user.ID });
            }
        }

        /// <summary>
        /// Получает список продуктов из базы.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {

            string query = "SELECT * FROM [dbo].[ProductTable]";

            using (var db = connectDb.sqlConnection)
            {
                db.Open();
                return await db.QueryAsync<Product>(query);
            }
        }

        /// <summary>
        /// Добавляет заказ в базу.
        /// </summary>
        /// <param name="userOrder"></param>
        /// <returns></returns>
        public async Task InsertOrders(UserOrder userOrder)
        {
            string query = "INSERT INTO [dbo].[UserOrders] (OrderDate, Price, UserID) VALUES (@OrderDate, @Price, @UserID)";

            using (var db = connectDb.sqlConnection)
            {
                db.Open();
                await db.ExecuteAsync(query, new {OrderDate = userOrder.OrderDate, Price = userOrder.Price, UserID = userOrder.UserID });
            }
        }
    }
}