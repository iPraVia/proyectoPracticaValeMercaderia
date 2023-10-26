using controlValeMercaderia.Controller;
using controlValeMercaderia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlValeMercaderia.View
{
    public partial class FormAddSMTP : Form
    {
        Connection_SMTP con_SMTP;
        public FormAddSMTP()
        {
            InitializeComponent();

            con_SMTP = new Connection_SMTP();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validateInputSMTPDataSettings();
        }
        private void validateInputSMTPDataSettings()
        {
            if (string.IsNullOrEmpty(tbSMTPHOST.Text.Trim()) || string.IsNullOrEmpty(tbSMTPPORT.Text.Trim()))
            {
                MessageBox.Show("CAMPO 'SMTP HOST' -> OBLIGATORIO\nCAMPO 'SMTP PORT' -> OBLIGATORIO");
                return;
            }
            if(isNumber()) validateSMTPDataSettings();
        }
        private bool isNumber()
        {
            try
            {
                int number = int.Parse(tbSMTPPORT.Text.Trim());
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("El SMTP PORT debe ser un valor numerico");
                return false;
            }
        }
        private void validateSMTPDataSettings()
        {
            if (con_SMTP.existsDataSMTP())
            {
                MessageBoxButtons btn = MessageBoxButtons.YesNo;
                var response = MessageBox.Show("Se encontraron datos almacenados.\n¿Desea sobreescribirlos?", "Alerta", btn);
                switch (response.ToString())
                {
                    case "Yes":
                        saveSMTPDataSettings();
                        break;
                    case "No":
                        break;
                }
            }
        }
        private void saveSMTPDataSettings()
        {
            if (con_SMTP.updateDataSMTP(tbSMTPHOST.Text, convertStringToNumber()))
            {
                MessageBox.Show("Datos Almacenados");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de conexion");
                tbSMTPHOST.Text = string.Empty;
                tbSMTPPORT.Text = string.Empty;
            }
        }
        private int convertStringToNumber()
        {
            if (isNumber()) return int.Parse(tbSMTPPORT.Text.Trim());
            else return 0;
        }
    }
}
