using controlValeMercaderia.Models;
using System.Windows.Forms;

namespace controlValeMercaderia.Controller
{
    internal class ValidateEmailDataSettings
    {
        private string email;
        private string password;
        private string alias;

        private Connection_SMTP con_smtp;
        private SMTP smtp;

        public ValidateEmailDataSettings(string email, string password, string alias)
        {
            this.email = email;
            this.password = password;
            this.alias = alias;

            con_smtp = new Connection_SMTP();
        }
        public bool validateData()
        {
            smtp = con_smtp.getDataEmail();

            if(string.IsNullOrEmpty(smtp.email))
            {
                return saveEmailDataSettings();
            }
            else
            {
                MessageBoxButtons btn = MessageBoxButtons.YesNo;
                var response = MessageBox.Show("Se encontraron datos almacenados.\n¿Desea sobreescribirlos?","Alerta",btn);
                switch (response.ToString())
                {
                    case "Yes":
                        return saveEmailDataSettings();
                    case "No":
                        return true;
                }
            }
            return false;
        }
        private bool saveEmailDataSettings()
        {
            if(con_smtp.updateDataEmail(email, password, alias))
            {
                return true;
            }
            return false;
        }
    }
}
