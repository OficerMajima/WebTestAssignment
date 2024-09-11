using ModelsLibrary.Models;

namespace WinForms
{
    internal static class Program
    {
        /// <summary>
        /// Переменная содержащая информацию о текущем пользователе.
        /// </summary>
        public static User user1 = new User();
        /// <summary>
        /// Переменная содержащая информацию о текущем заказе.
        /// </summary>
        public static UserOrder currentOrder = new UserOrder();
        /// <summary>
        ///  Коллекция для хранения заказов пользователя.
        /// </summary>
        public static List<UserOrder> userOrders = new List<UserOrder>();
        /// <summary>
        /// Коллекция для хранения продуктов из базы.
        /// </summary>
        public static List<Product> products = new List<Product>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}