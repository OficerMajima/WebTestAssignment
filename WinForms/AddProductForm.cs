using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AddProductForm : Form
    {
        Product currentProduct;
        public AddProductForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Program.products;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        /// <summary>
        /// Определяет выбранный товар в списке и выводит его цену.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentProduct = comboBox1.SelectedItem as Product;
            string selectedState = currentProduct.Price.ToString();
            PriceLabel.Text = selectedState;
        }

        /// <summary>
        /// Возвращает в прошлое окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturneButton_Click(object sender, EventArgs e)
        {
            this.Close();
            OrderForm form = new OrderForm();
            form.Show();
        }

        /// <summary>
        /// Добавляет стоимость товара в заказ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Program.currentOrder.Price += currentProduct.Price;
        }
    }
}
