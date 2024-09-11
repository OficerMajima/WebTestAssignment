using ModelsLibrary.Models;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string loginUser { get; set; }

        /// <summary>
        /// По нажатия сверяет ввод пользователя с логином в базе. При успехе запрашивает продукты из базы данных и открывает основное окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginUser = LoginField.Text;
            Program.user1.Login = loginUser;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5175/api/Main/");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "UserLogin");
                client.DefaultRequestHeaders.Clear();

                requestMessage.Content = new StringContent(JsonSerializer.Serialize(Program.user1));
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);

                try
                {
                    response.EnsureSuccessStatusCode();
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();

                    HttpRequestMessage requestProductsMessage = new HttpRequestMessage(HttpMethod.Get, "Products");
                    requestMessage.Content = new StringContent(String.Empty);
                    requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage responseProducts = await client.SendAsync(requestProductsMessage);
                    try
                    {
                        responseProducts.EnsureSuccessStatusCode();
                    }
                    catch
                    {
                        DialogResult = DialogResult.OK;
                        MessageBox.Show("Ошибка",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
                    string responseProductsString = await responseProducts.Content.ReadAsStringAsync();
                    Program.products = JsonSerializer.Deserialize<List<Product>>(responseProductsString);

                    string responseString = await response.Content.ReadAsStringAsync();
                    Program.user1 = JsonSerializer.Deserialize<User>(responseString);
                }
                catch
                {
                    DialogResult = DialogResult.OK;
                    MessageBox.Show("Неверный логин",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
