using dimak.Controller;
using System;
using System.Threading;
using System.Windows.Forms;

namespace dimak
{
    public partial class Form1 : Form
    {
        private int codigoQR;
        private ValeMercaderiaConnectionDataBase valeCon;
        public Form1()
        {
            InitializeComponent();
        }
        private void validateInputQR()
        {
            if (string.IsNullOrEmpty(inputQR.Text)) return;
            if (isNumber(inputQR.Text.Trim()) == -1) return;
            
            valeCon = new ValeMercaderiaConnectionDataBase();
            codigoQR = int.Parse(inputQR.Text.Trim());

            if (valeCon.isActiveVale(codigoQR))
            {
                MessageBoxButtons btns = MessageBoxButtons.YesNo;
                var resp = MessageBox.Show("VALE DISPONIBLE PARA CANJE\n¿CANJEAR?","Alerta",btns);
                switch (resp.ToString())
                {
                    case "Yes":
                        canjearVale();
                        break;
                    case "No":
                        codigoQR = -1;
                        inputQR.Text = "";
                        return; 
                }
            }
            else
            {
                MessageBox.Show("VALE NO DISPONIBLE PARA CANJE");
                return;
            }
        }

        private int isNumber(string pNum)
        {
            int num = -1;

            try
            {
                num = int.Parse(pNum);
            }
            catch(Exception e)
            {
                Console.WriteLine($"isNumber\n{e}");
            }

            return num;
        }
        private void canjearVale()
        {
            if (valeCon.canjearVale(codigoQR))
            {
                MessageBox.Show("VALE DE MERCADERIA CAJEADO CON EXITO");
            }
            else
            {
                MessageBox.Show("VALE NO DISPONIBLE PARA CANJE");
            }
        }

        private void btnCanjear_Click(object sender, EventArgs e)
        {
            if (inputQR.Text.Trim().Length > 5)
            {
                validateInputQR();
            }
        }
    }
}
