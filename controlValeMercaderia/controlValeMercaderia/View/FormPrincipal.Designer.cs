namespace controlValeMercaderia
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDV = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputRUT = new System.Windows.Forms.TextBox();
            this.imageBoxQR = new System.Windows.Forms.PictureBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.configurarCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarCorreoDePruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.generadorMasivoDeValesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarPorCorreoMasivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarPorCentroDeCostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelCentroCosto = new System.Windows.Forms.Label();
            this.labelTramo = new System.Windows.Forms.Label();
            this.configurarServidorSMTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxQR)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "RUT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "- SIN PUNTO - SIN GUION - SIN DIGITO VERIFICADOR -";
            // 
            // labelDV
            // 
            this.labelDV.AutoSize = true;
            this.labelDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDV.Location = new System.Drawing.Point(223, 79);
            this.labelDV.Name = "labelDV";
            this.labelDV.Size = new System.Drawing.Size(20, 28);
            this.labelDV.TabIndex = 3;
            this.labelDV.Text = " ";
            this.labelDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(265, 80);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "BUSCAR TRABAJADOR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputRUT
            // 
            this.inputRUT.Location = new System.Drawing.Point(66, 83);
            this.inputRUT.MaxLength = 8;
            this.inputRUT.Name = "inputRUT";
            this.inputRUT.Size = new System.Drawing.Size(136, 20);
            this.inputRUT.TabIndex = 7;
            this.inputRUT.TextChanged += new System.EventHandler(this.inputRUT_TextChanged);
            // 
            // imageBoxQR
            // 
            this.imageBoxQR.Location = new System.Drawing.Point(507, 29);
            this.imageBoxQR.Name = "imageBoxQR";
            this.imageBoxQR.Size = new System.Drawing.Size(281, 232);
            this.imageBoxQR.TabIndex = 8;
            this.imageBoxQR.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(482, 277);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(119, 43);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "GUARDAR\r\nVALE";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(651, 277);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(111, 43);
            this.btnSendMail.TabIndex = 10;
            this.btnSendMail.Text = "ENVIAR VALE\r\nPOR CORREO";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarCorreoToolStripMenuItem,
            this.configurarServidorSMTPToolStripMenuItem,
            this.enviarCorreoDePruebaToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(56, 22);
            this.toolStripDropDownButton2.Text = "Correo";
            // 
            // configurarCorreoToolStripMenuItem
            // 
            this.configurarCorreoToolStripMenuItem.Name = "configurarCorreoToolStripMenuItem";
            this.configurarCorreoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.configurarCorreoToolStripMenuItem.Text = "Configurar correo";
            this.configurarCorreoToolStripMenuItem.Click += new System.EventHandler(this.configurarCorreoToolStripMenuItem_Click);
            // 
            // enviarCorreoDePruebaToolStripMenuItem
            // 
            this.enviarCorreoDePruebaToolStripMenuItem.Name = "enviarCorreoDePruebaToolStripMenuItem";
            this.enviarCorreoDePruebaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.enviarCorreoDePruebaToolStripMenuItem.Text = "Enviar correo de prueba";
            this.enviarCorreoDePruebaToolStripMenuItem.Click += new System.EventHandler(this.enviarCorreoDePruebaToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generadorMasivoDeValesToolStripMenuItem,
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton1.Text = "Vale Mercaderia";
            // 
            // generadorMasivoDeValesToolStripMenuItem
            // 
            this.generadorMasivoDeValesToolStripMenuItem.Name = "generadorMasivoDeValesToolStripMenuItem";
            this.generadorMasivoDeValesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.generadorMasivoDeValesToolStripMenuItem.Text = "Generar vales de mercadería";
            this.generadorMasivoDeValesToolStripMenuItem.Click += new System.EventHandler(this.generadorMasivoDeValesToolStripMenuItem_Click);
            // 
            // enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem
            // 
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarPorCorreoMasivoToolStripMenuItem,
            this.enviarPorCentroDeCostoToolStripMenuItem});
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem.Name = "enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem";
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem.Text = "Enviar vales de mercadería";
            // 
            // enviarPorCorreoMasivoToolStripMenuItem
            // 
            this.enviarPorCorreoMasivoToolStripMenuItem.Name = "enviarPorCorreoMasivoToolStripMenuItem";
            this.enviarPorCorreoMasivoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.enviarPorCorreoMasivoToolStripMenuItem.Text = "Enviar por correo masivo";
            this.enviarPorCorreoMasivoToolStripMenuItem.Click += new System.EventHandler(this.enviarPorCorreoMasivoToolStripMenuItem_Click);
            // 
            // enviarPorCentroDeCostoToolStripMenuItem
            // 
            this.enviarPorCentroDeCostoToolStripMenuItem.Name = "enviarPorCentroDeCostoToolStripMenuItem";
            this.enviarPorCentroDeCostoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.enviarPorCentroDeCostoToolStripMenuItem.Text = "Enviar por centro de costo";
            this.enviarPorCentroDeCostoToolStripMenuItem.Click += new System.EventHandler(this.enviarPorCentroDeCostoToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 44);
            this.label7.TabIndex = 14;
            this.label7.Text = "CENTRO\r\nCOSTO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(385, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "TRAMO";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(107, 153);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(15, 22);
            this.labelNombre.TabIndex = 16;
            this.labelNombre.Text = " ";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(107, 196);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(15, 22);
            this.labelApellido.TabIndex = 17;
            this.labelApellido.Text = " ";
            // 
            // labelCentroCosto
            // 
            this.labelCentroCosto.AutoSize = true;
            this.labelCentroCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCentroCosto.Location = new System.Drawing.Point(119, 254);
            this.labelCentroCosto.Name = "labelCentroCosto";
            this.labelCentroCosto.Size = new System.Drawing.Size(15, 22);
            this.labelCentroCosto.TabIndex = 18;
            this.labelCentroCosto.Text = " ";
            // 
            // labelTramo
            // 
            this.labelTramo.AutoSize = true;
            this.labelTramo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTramo.Location = new System.Drawing.Point(406, 187);
            this.labelTramo.Name = "labelTramo";
            this.labelTramo.Size = new System.Drawing.Size(15, 22);
            this.labelTramo.TabIndex = 19;
            this.labelTramo.Text = " ";
            // 
            // configurarServidorSMTPToolStripMenuItem
            // 
            this.configurarServidorSMTPToolStripMenuItem.Name = "configurarServidorSMTPToolStripMenuItem";
            this.configurarServidorSMTPToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.configurarServidorSMTPToolStripMenuItem.Text = "Configurar servidor SMTP";
            this.configurarServidorSMTPToolStripMenuItem.Click += new System.EventHandler(this.configurarServidorSMTPToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 333);
            this.Controls.Add(this.labelTramo);
            this.Controls.Add(this.labelCentroCosto);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.imageBoxQR);
            this.Controls.Add(this.inputRUT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.labelDV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "Control Vale Mercaderia";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxQR)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDV;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputRUT;
        private System.Windows.Forms.PictureBox imageBoxQR;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelCentroCosto;
        private System.Windows.Forms.Label labelTramo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem configurarCorreoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarCorreoDePruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem generadorMasivoDeValesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarValeDeMercaderíaPorCorreoMasivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarPorCorreoMasivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarPorCentroDeCostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarServidorSMTPToolStripMenuItem;
    }
}

