namespace ReservationSystem.Forms.Login
{
    partial class SignupForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lastNameInput = new System.Windows.Forms.TextBox();
            this.ageInput = new System.Windows.Forms.TextBox();
            this.firstNameInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.goToLoginButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SignupButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordSignup = new System.Windows.Forms.TextBox();
            this.usernameSignup = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PeachPuff;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lastNameInput);
            this.panel1.Controls.Add(this.ageInput);
            this.panel1.Controls.Add(this.firstNameInput);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.goToLoginButton);
            this.panel1.Controls.Add(this.SignupButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordSignup);
            this.panel1.Controls.Add(this.usernameSignup);
            this.panel1.Location = new System.Drawing.Point(431, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 448);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(172, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Last Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lastNameInput
            // 
            this.lastNameInput.BackColor = System.Drawing.Color.DimGray;
            this.lastNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameInput.ForeColor = System.Drawing.Color.PeachPuff;
            this.lastNameInput.Location = new System.Drawing.Point(176, 213);
            this.lastNameInput.Name = "lastNameInput";
            this.lastNameInput.Size = new System.Drawing.Size(90, 22);
            this.lastNameInput.TabIndex = 13;
            // 
            // ageInput
            // 
            this.ageInput.BackColor = System.Drawing.Color.DimGray;
            this.ageInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageInput.ForeColor = System.Drawing.Color.PeachPuff;
            this.ageInput.Location = new System.Drawing.Point(277, 213);
            this.ageInput.Name = "ageInput";
            this.ageInput.Size = new System.Drawing.Size(47, 22);
            this.ageInput.TabIndex = 12;
            // 
            // firstNameInput
            // 
            this.firstNameInput.BackColor = System.Drawing.Color.DimGray;
            this.firstNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameInput.ForeColor = System.Drawing.Color.PeachPuff;
            this.firstNameInput.Location = new System.Drawing.Point(80, 213);
            this.firstNameInput.Name = "firstNameInput";
            this.firstNameInput.Size = new System.Drawing.Size(90, 22);
            this.firstNameInput.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(273, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Age";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(77, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "First Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReservationSystem.Properties.Resources.logo_vista;
            this.pictureBox1.Location = new System.Drawing.Point(147, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(146, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 39);
            this.label3.TabIndex = 7;
            this.label3.Text = "Signup";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // goToLoginButton
            // 
            this.goToLoginButton.AutoSize = true;
            this.goToLoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.goToLoginButton.Depth = 0;
            this.goToLoginButton.ForeColor = System.Drawing.Color.DimGray;
            this.goToLoginButton.Location = new System.Drawing.Point(110, 396);
            this.goToLoginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.goToLoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.goToLoginButton.Name = "goToLoginButton";
            this.goToLoginButton.Primary = false;
            this.goToLoginButton.Size = new System.Drawing.Size(187, 36);
            this.goToLoginButton.TabIndex = 6;
            this.goToLoginButton.Text = "Have an Account? Login";
            this.goToLoginButton.UseVisualStyleBackColor = true;
            this.goToLoginButton.Click += new System.EventHandler(this.goToLoginButton_Click);
            // 
            // SignupButton
            // 
            this.SignupButton.BackColor = System.Drawing.Color.DimGray;
            this.SignupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupButton.ForeColor = System.Drawing.Color.PeachPuff;
            this.SignupButton.Location = new System.Drawing.Point(143, 356);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(115, 41);
            this.SignupButton.TabIndex = 5;
            this.SignupButton.Text = "Signup";
            this.SignupButton.UseVisualStyleBackColor = false;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(87, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(87, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // passwordSignup
            // 
            this.passwordSignup.BackColor = System.Drawing.Color.DimGray;
            this.passwordSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordSignup.ForeColor = System.Drawing.Color.PeachPuff;
            this.passwordSignup.Location = new System.Drawing.Point(81, 318);
            this.passwordSignup.Name = "passwordSignup";
            this.passwordSignup.Size = new System.Drawing.Size(243, 22);
            this.passwordSignup.TabIndex = 5;
            // 
            // usernameSignup
            // 
            this.usernameSignup.BackColor = System.Drawing.Color.DimGray;
            this.usernameSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameSignup.ForeColor = System.Drawing.Color.PeachPuff;
            this.usernameSignup.Location = new System.Drawing.Point(81, 266);
            this.usernameSignup.Name = "usernameSignup";
            this.usernameSignup.Size = new System.Drawing.Size(243, 22);
            this.usernameSignup.TabIndex = 5;
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Name = "SignupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialFlatButton goToLoginButton;
        private System.Windows.Forms.Button SignupButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordSignup;
        private System.Windows.Forms.TextBox usernameSignup;
        private System.Windows.Forms.TextBox ageInput;
        private System.Windows.Forms.TextBox firstNameInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lastNameInput;
    }
}