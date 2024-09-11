using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            OrderComposLabel.Text = Program.currentOrder.Price.ToString();
        }

        private Button BuyButton;
        private Button AddProductsButton;
        private Label label1;
        private Label OrderComposLabel;

        private void InitializeComponent()
        {
            BuyButton = new Button();
            AddProductsButton = new Button();
            label1 = new Label();
            OrderComposLabel = new Label();
            SuspendLayout();
            // 
            // BuyButton
            // 
            BuyButton.Dock = DockStyle.Bottom;
            BuyButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BuyButton.Location = new Point(0, 352);
            BuyButton.Name = "BuyButton";
            BuyButton.Size = new Size(485, 111);
            BuyButton.TabIndex = 0;
            BuyButton.Text = "Buy";
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // AddProductsButton
            // 
            AddProductsButton.Dock = DockStyle.Bottom;
            AddProductsButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AddProductsButton.Location = new Point(0, 274);
            AddProductsButton.Name = "AddProductsButton";
            AddProductsButton.Size = new Size(485, 78);
            AddProductsButton.TabIndex = 1;
            AddProductsButton.Text = "AddProducts";
            AddProductsButton.UseVisualStyleBackColor = true;
            AddProductsButton.Click += AddProductsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(336, 41);
            label1.TabIndex = 2;
            label1.Text = "Your order will cost you:";
            // 
            // OrderComposLabel
            // 
            OrderComposLabel.AutoSize = true;
            OrderComposLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OrderComposLabel.Location = new Point(354, 12);
            OrderComposLabel.Name = "OrderComposLabel";
            OrderComposLabel.Size = new Size(23, 38);
            OrderComposLabel.TabIndex = 3;
            OrderComposLabel.Text = ".";
            // 
            // OrderForm
            // 
            ClientSize = new Size(485, 463);
            Controls.Add(OrderComposLabel);
            Controls.Add(label1);
            Controls.Add(AddProductsButton);
            Controls.Add(BuyButton);
            Name = "OrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Открывает окно добавления товаров в заказ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProductForm form = new AddProductForm();
            form.Show();
        }

        /// <summary>
        /// Подтверждает и отправляет заказ в базу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BuyButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                DateTime dateTime = DateTime.Now;
                Program.currentOrder.OrderDate = dateTime.ToString();
                Program.currentOrder.UserID = Program.user1.ID;
                //Program.currentOrder.ID = Program.userOrders.Count + 1;

                client.BaseAddress = new Uri("http://localhost:5175/api/Main/");
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, "InsertOrder");
                client.DefaultRequestHeaders.Clear();

                requestMessage.Content = new StringContent(JsonSerializer.Serialize(Program.currentOrder));
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
            }
            this.Close();
            MainForm form = new MainForm();
            form.Show();
        }
    }
}
