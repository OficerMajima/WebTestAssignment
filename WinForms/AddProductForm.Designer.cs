namespace WinForms
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            ReturneButton = new Button();
            comboBox1 = new ComboBox();
            productBindingSource = new BindingSource(components);
            productBindingSource1 = new BindingSource(components);
            label1 = new Label();
            PriceLabel = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(0, 266);
            button1.Name = "button1";
            button1.Size = new Size(478, 60);
            button1.TabIndex = 0;
            button1.Text = "Add Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ReturneButton
            // 
            ReturneButton.Dock = DockStyle.Bottom;
            ReturneButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ReturneButton.Location = new Point(0, 206);
            ReturneButton.Name = "ReturneButton";
            ReturneButton.Size = new Size(478, 60);
            ReturneButton.TabIndex = 3;
            ReturneButton.Text = "Proceed to Cart";
            ReturneButton.UseVisualStyleBackColor = true;
            ReturneButton.Click += ReturneButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.DataSource = productBindingSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 50);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 45);
            comboBox1.TabIndex = 4;
            comboBox1.ValueMember = "Price";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(ModelsLibrary.Models.Product);
            // 
            // productBindingSource1
            // 
            productBindingSource1.DataSource = typeof(ModelsLibrary.Models.Product);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(198, 53);
            label1.Name = "label1";
            label1.Size = new Size(84, 38);
            label1.TabIndex = 5;
            label1.Text = "Price:";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PriceLabel.Location = new Point(288, 15);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(23, 38);
            PriceLabel.TabIndex = 6;
            PriceLabel.Text = ".";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(388, 38);
            label2.TabIndex = 7;
            label2.Text = "Выберите продукт из списка:";
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 326);
            Controls.Add(label2);
            Controls.Add(PriceLabel);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(ReturneButton);
            Controls.Add(button1);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button ReturneButton;
        private ComboBox comboBox1;
        private BindingSource productBindingSource;
        private BindingSource productBindingSource1;
        private Label label1;
        private Label PriceLabel;
        private Label label2;
    }
}