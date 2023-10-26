using controlValeMercaderia.Controller;
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
    public partial class FormAddEmail : Form
    {
        public FormAddEmail()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            validateInputEmailDataSettings();
        }
        private void validateInputEmailDataSettings()
        {
            if(string.IsNullOrEmpty(inputEmail.Text.Trim()) || string.IsNullOrEmpty(inputPassword.Text.Trim()))
            {
                MessageBox.Show("CAMPO 'CORREO ELECTRONICO' -> OBLIGATORIO\nCAMPO 'CONTRASEÑA' -> OBLIGATORIO");
                return;
            }
            validateEmailDataSettings();
        }
        private void validateEmailDataSettings()
        {
            ValidateEmailDataSettings veds = new ValidateEmailDataSettings(inputEmail.Text.Trim(),inputPassword.Text.Trim(),(string.IsNullOrEmpty(inputAlias.Text.Trim())?"":inputAlias.Text.Trim()));
            bool b = veds.validateData();
            if(b)
            {
                this.Close();
            }
            
        }
    }
}
