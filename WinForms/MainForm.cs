using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получает информацию о заказах тз базы по нажатию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5175/api/Main/");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "UserOrders");
                client.DefaultRequestHeaders.Clear();

                requestMessage.Content = new StringContent(JsonSerializer.Serialize(Program.user1));
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                try
                {
                    response.EnsureSuccessStatusCode();
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
                string responseString = await response.Content.ReadAsStringAsync();
                Program.userOrders = JsonSerializer.Deserialize<List<UserOrder>>(responseString);

                dataGridView1.DataSource = Program.userOrders;
            }
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm form = new OrderForm();
            form.Show();
        }
    }
}
