using controlValeMercaderia.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace controlValeMercaderia.View
{
    public partial class FormTipoVale : Form
    {
        private List<TipoVale> tipoValeList;
        public FormTipoVale()
        {
            InitializeComponent();
            btnAceptar.Enabled = false;
            cargarCB();
        }
        private void cargarCB()
        {
            TipoValeConnectionDataBase tipoValeCon = new TipoValeConnectionDataBase();
            tipoValeList = tipoValeCon.getAllTipoVale();
            llenarCB();
        }
        private void llenarCB()
        {
            if(tipoValeList != null)
            {
                cbTipoVale.Items.Clear();
                foreach (TipoVale tv in tipoValeList)
                {
                    cbTipoVale.Items.Add(tv.nombre);
                }
                btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(cbTipoVale.SelectedItem != null)
            {
                massiveCreation();
            }
        }

        private void massiveCreation()
        {
            foreach(TipoVale tv in tipoValeList)
            {
                if (cbTipoVale.SelectedItem.ToString().Trim() == tv.nombre)
                {
                    ValeMercaderiaMassiveCreation masiveCreation = new ValeMercaderiaMassiveCreation();
                    masiveCreation.massiveCreation(tv.id);
                    MessageBox.Show("Tarea finalizada.");
                }
            }
        }
    }
}
