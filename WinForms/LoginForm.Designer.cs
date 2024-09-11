namespace WinForms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginField = new TextBox();
            label = new Label();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // LoginField
            // 
            LoginField.Dock = DockStyle.Bottom;
            LoginField.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LoginField.Location = new Point(0, 180);
            LoginField.Margin = new Padding(3, 4, 3, 4);
            LoginField.Name = "LoginField";
            LoginField.Size = new Size(398, 47);
            LoginField.TabIndex = 3;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.Location = new Point(12, 9);
            label.Name = "label";
            label.Size = new Size(370, 62);
            label.TabIndex = 1;
            label.Text = "Enter your login:";
            label.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonLogin
            // 
            buttonLogin.Dock = DockStyle.Bottom;
            buttonLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLogin.Location = new Point(0, 227);
            buttonLogin.Margin = new Padding(3, 4, 3, 4);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(398, 68);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Enter";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 295);
            Controls.Add(LoginField);
            Controls.Add(buttonLogin);
            Controls.Add(label);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginField;
        private Label label;
        private Button buttonLogin;
    }
}
