using controlValeMercaderia.Controller;
using controlValeMercaderia.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace controlValeMercaderia.View
{
    public partial class FormSendMailByCostCenter : Form
    {
        private List<CentroCosto> centroCostos;
        public FormSendMailByCostCenter()
        {
            InitializeComponent();

            btnEnviar.Enabled = false;

            getCentroCostos();
        }

        private void getCentroCostos()
        {
            CentroCostoConnectionWithDataBase ccCon = new CentroCostoConnectionWithDataBase();
            centroCostos = ccCon.getAllCentroCosto();
            FillComboBox();
        }
        private void FillComboBox()
        {
            if (centroCostos != null)
            {
                cbCentroCosto.Items.Clear();
                foreach(CentroCosto centroCosto in centroCostos)
                {
                    cbCentroCosto.Items.Add(centroCosto.nombre);
                }
                btnEnviar.Enabled = true;
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(cbCentroCosto.SelectedItem != null)
            {
                sendByCentroCosto();
            }
        }
        private void sendByCentroCosto()
        {
            foreach(CentroCosto cc in centroCostos)
            {
                if(cbCentroCosto.SelectedItem.ToString().Trim() == cc.nombre.ToString())
                {
                    send(cc.id);
                }
            }
        }
        private void send(int id)
        {
            TrabajadorConnectionWithDataBase conTrabajador = new TrabajadorConnectionWithDataBase();
            ValeMercaderiConnectionWithDatBase conVale = new ValeMercaderiConnectionWithDatBase();
            PDFCreator pdf = new PDFCreator();
            List<Trabajador> lista = conTrabajador.getTrabajadorByCentroCsto(id);

            foreach(Trabajador trabajador in lista)
            {
                ValeMercaderia vale = conVale.getOneVale(trabajador.rut);
                if (vale.activo)
                {
                    pdf.createPDFWithHTML(trabajador, vale,false);
                }
            }
        }
    }
}
