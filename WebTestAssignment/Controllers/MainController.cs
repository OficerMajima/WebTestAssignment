using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models;
using WebTestAssignment.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebTestAssignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public DBService dBService;
        public MainController(DBService dBService)
        {
            this.dBService = dBService;
        }

        /// <summary>
        /// Сверяет логин с базой.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("UserLogin")]
        public async Task<IActionResult> GetLogin(User user)
        {
            User user1;
            try
            {
                user1 = await dBService.GetLogin(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user1);
        }

        /// <summary>
        /// Получает заказы пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("UserOrders")]
        public async Task<IActionResult> GetUserOrders(User user)
        {
            IEnumerable<UserOrder> userOrders;
            try
            {
                userOrders = await dBService.GetUserOrders(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(userOrders);
        }

        /// <summary>
        /// Получает продукты из базы.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            IEnumerable<Product> products;
            try
            {
                products = await dBService.GetProducts();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(products);
        }

        /// <summary>
        /// Добавляет заказ в базу данных.
        /// </summary>
        /// <param name="userOrder"></param>
        /// <returns></returns>
        [HttpPut("InsertOrder")]
        public async Task<IActionResult> InsertOrder(UserOrder userOrder)
        {
            try
            {
                await dBService.InsertOrders(userOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}