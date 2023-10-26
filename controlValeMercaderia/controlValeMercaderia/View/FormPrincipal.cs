using controlValeMercaderia.Controller;
using controlValeMercaderia.View;
using System;
using System.Drawing;
using System.Windows.Forms;
using controlValeMercaderia.Models;


namespace controlValeMercaderia
{
    public partial class FormPrincipal : Form
    {
        private string rut;
        private Trabajador trabajador;
        private ValeMercaderia valeMercaderia;

        public FormPrincipal()
        {
            InitializeComponent();

            rut = string.Empty;

            btnBuscar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSendMail.Enabled = false;
        }
        private void obtenerDV()
        {
            CalcularDigitoVerificador cdv = new CalcularDigitoVerificador(rut);
            labelDV.Text = cdv.getDV();
        }
        private void btnBuscar_Click(object sender, EventArgs e){showDataTrabajador();}
        private void showDataTrabajador()
        {
            TrabajadorConnectionWithDataBase tcwd = new TrabajadorConnectionWithDataBase();
            trabajador = tcwd.getOneTrabajador(rut);

            if (string.IsNullOrEmpty(trabajador.rut))
            {
                MessageBox.Show("Sin coincidencias");
                return;
            }

            asignDataTrabajador();
            asignQR();
            valeIsActive();
        }
        private void asignDataTrabajador()
        {
            labelNombre.Text = trabajador.nombre;
            labelApellido.Text = $"{trabajador.apellido_paterno} {trabajador.apellido_materno}".Trim();
            labelCentroCosto.Text = trabajador.centro_costo;
            labelTramo.Text = trabajador.tramo;
        }
        private void asignQR()
        {
            if (String.IsNullOrEmpty(rut))return;

            imageBoxQR.Image = trabajador.QRCode;
        }  
        private void valeIsActive()
        {
            ValeMercaderiConnectionWithDatBase valeCon = new ValeMercaderiConnectionWithDatBase();
            ValeMercaderia vale = valeCon.getOneVale(rut);

            if (vale.activo)
            {
                btnImprimir.Enabled = true;
                btnSendMail.Enabled = true;
                valeMercaderia = vale;
            }
            else
            {
                MessageBox.Show("Trabajador no posee vales disponibles");
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e) {createDataPDF(true);}
        private void createDataPDF(bool save)
        {
            PDFCreator pc = new PDFCreator();
            pc.createPDFWithHTML(trabajador,valeMercaderia,save);
        }
        private void btnSendMail_Click(object sender, EventArgs e) { createDataPDF(false); }
        private void inputRUT_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (inputRUT.Text.Trim().Length > 6 && int.TryParse(inputRUT.Text.Trim(), out i))
            {
                rut = inputRUT.Text;
                obtenerDV();
                btnBuscar.Enabled = true;
            }
        }
        private void configurarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEmail fae = new FormAddEmail();
            fae.Show();
        }
        private void enviarCorreoDePruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFCreator pDFCreator = new PDFCreator();
            if (pDFCreator.sendTestMail())
            {
                MessageBox.Show("Email enviado con exito");
            }
            else
            {
                MessageBox.Show("Error al enviar el email");
            }
        }
        private void generadorMasivoDeValesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            massiveCreation();

        }
        private void massiveCreation()
        {
            FormTipoVale ftv = new FormTipoVale();
            ftv.Show();
        }
        private void enviarPorCorreoMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            massiveSend();
        }
        private void massiveSend()
        {
            ValeMercaderiaMassiveSend valeSend = new ValeMercaderiaMassiveSend();
            valeSend.massiveSend();
        }
        private void enviarPorCentroDeCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSendMailByCostCenter fsenMail = new FormSendMailByCostCenter();
            fsenMail.Show();
        }

        private void configurarServidorSMTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configurarServidorSMTP();
        }
        private void configurarServidorSMTP()
        {
            FormAddSMTP form = new FormAddSMTP();
            form.Show();
        }
    }
}
