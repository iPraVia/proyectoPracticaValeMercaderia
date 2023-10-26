namespace dimak
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputQR = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnCanjear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // inputQR
            // 
            this.inputQR.Location = new System.Drawing.Point(55, 156);
            this.inputQR.Name = "inputQR";
            this.inputQR.PasswordChar = '*';
            this.inputQR.Size = new System.Drawing.Size(240, 20);
            this.inputQR.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(6, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(505, 132);
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // btnCanjear
            // 
            this.btnCanjear.Location = new System.Drawing.Point(330, 148);
            this.btnCanjear.Name = "btnCanjear";
            this.btnCanjear.Size = new System.Drawing.Size(127, 35);
            this.btnCanjear.TabIndex = 4;
            this.btnCanjear.Text = "CANJEAR";
            this.btnCanjear.UseVisualStyleBackColor = true;
            this.btnCanjear.Click += new System.EventHandler(this.btnCanjear_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(512, 197);
            this.Controls.Add(this.btnCanjear);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.inputQR);
            this.Name = "Form1";
            this.Text = "Canje Vale Mercaderia";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputQR;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnCanjear;
    }
}

