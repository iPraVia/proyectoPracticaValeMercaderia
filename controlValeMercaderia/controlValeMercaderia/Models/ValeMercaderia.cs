using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using Humanizer;
using System.Drawing;
using System.Security.Cryptography;

namespace controlValeMercaderia.Models
{
    internal class ValeMercaderia
    {
        public int id;
        public string  id_trabajador;
        public DateTime fecha_emision;
        public DateTime fecha_vencimiento;
        public DateTime fecha_canje;
        public bool activo;
        public int n_cuenta;
        public int monto;
        public int tipo_vale;
        public Bitmap barcode;

        public ValeMercaderia()
        {}

        public void asignBarcode()
        {
            var barcodeWriter = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 111,
                    Height = 33,
                    Margin = 0
                }
            };
                
            barcode = barcodeWriter.Write(id.ToString());
        }
        public string getMontoEnLetras()
        {
            return monto.ToWords();
        }
        public string getMontoFormateado()
        {
            CultureInfo ci = new CultureInfo("en-us");
            string texto = monto.ToString("C", ci);
            return texto.Remove(texto.Length -3);
        }
    }
    internal class ValeMercaderiConnectionWithDatBase
    {
        public ValeMercaderiConnectionWithDatBase()
        {

        }
        public ValeMercaderia getOneVale(string id_trabajador)
        {
            ValeMercaderia vale = new ValeMercaderia();
            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getOneValeMercaderia", conexion);
                    cmd.Parameters.AddWithValue("id_trabajador", id_trabajador);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            vale.id = (int)dr["id"];
                            vale.id_trabajador = dr["id_trabajador"].ToString().Trim();
                            vale.fecha_emision = (DateTime)dr["fecha_emision"];
                            vale.fecha_vencimiento = (DateTime)dr["fecha_vencimiento"];
                            vale.fecha_canje = (string.IsNullOrEmpty(dr["fecha_canje"].ToString())) ? vale.fecha_vencimiento : (DateTime)dr["fecha_canje"];
                            vale.activo = (((byte)dr["estado"]) == 1) ? true : false;
                            vale.n_cuenta = (int)dr["n_cuenta"];
                            vale.monto = (int)dr["monto"];
                            vale.tipo_vale = (int)dr["id_tipo_vale"];
                            vale.asignBarcode();
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"getVale()\n{e}");
            }
            return vale;
        }
        public bool saveValeMercaderia(ValeMercaderia vale)
        {
            bool resp;
            try
            {
                using(var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_createValeMercaderia", conexion);
                    cmd.Parameters.AddWithValue("id_trabajador",vale.id_trabajador);
                    cmd.Parameters.AddWithValue("fecha_emision",vale.fecha_emision);
                    cmd.Parameters.AddWithValue("fecha_vencimiento",vale.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("estado",vale.activo);
                    cmd.Parameters.AddWithValue("n_cuenta",700011);
                    cmd.Parameters.AddWithValue("monto",vale.monto);
                    cmd.Parameters.AddWithValue("id_tipo_vale",vale.tipo_vale);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resp = true;
                }

            }catch(SqlException e)
            {
                Console.WriteLine($"saveValeMercaderia() => {e.ToString()}");
                resp = false;
            }
            return resp;
        }
    }
    internal class ValeMercaderiaMassiveCreation
    {
        private DateTime date;
        private int id_tipoVale;
        public ValeMercaderiaMassiveCreation()
        {
            date = DateTime.Now;
        }
        public void massiveCreation(int id_tipoVale)
        {
            this.id_tipoVale = id_tipoVale;
            try
            {
                ValeMercaderiConnectionWithDatBase valeCon = new ValeMercaderiConnectionWithDatBase();
                TrabajadorConnectionWithDataBase worker = new TrabajadorConnectionWithDataBase();
                List<Trabajador> listaWorker = worker.getAllTrabajador();

                foreach (Trabajador trabajador in listaWorker)
                {
                    ValeMercaderia vale = valeCon.getOneVale(trabajador.rut);
                    if (string.IsNullOrEmpty(vale.id_trabajador))
                    {
                        createValeMercaderia(trabajador);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"massiveCreation\n{e}");
            }
        }
        private void createValeMercaderia(Trabajador trabajador)
        {
            ValeMercaderia vale = new ValeMercaderia();

            vale.id_trabajador = trabajador.rut;
            vale.fecha_emision = asignFechaEmision();
            vale.fecha_vencimiento = vale.fecha_emision.AddDays(60);
            vale.activo = true;
            vale.monto = getMonto(trabajador.tramo);
            vale.tipo_vale = id_tipoVale;

            ValeMercaderiConnectionWithDatBase valeDataBase = new ValeMercaderiConnectionWithDatBase();
            valeDataBase.saveValeMercaderia(vale);
        }
        private DateTime asignFechaEmision()
        {
            DateTime d = new DateTime();
            switch (id_tipoVale)
            {
                case 1:
                    string f2 = $"12/1/{date.Year} 9:32:59 AM";
                    d = DateTime.Parse(f2,CultureInfo.InvariantCulture);
                    break;
                case 2:
                    string f1 = $"09/01/{date.Year} 9:32:59 AM";
                    d = DateTime.Parse(f1,CultureInfo.InvariantCulture);
                    Console.WriteLine(d.Month);
                    break;
            }
            return d;
        }
        private int getMonto(string tramo)
        {
            int monto = 0;
            switch (tramo)
            {
                case "T7":
                    monto = 19500;
                    break;
                case "T6":
                    monto = 29000;
                    break;
                case "T5":
                    monto = 42000;
                    break;
                case "T4":
                    monto = 46000;
                    break;
                case "T3":
                    monto = 52000;
                    break;
                case "T2":
                    monto = 55000;
                    break;
                case "T1":
                    monto = 60000;
                    break;
            }
            return monto;
        }
    }
    internal class ValeMercaderiaMassiveSend
    {
        public ValeMercaderiaMassiveSend() { }

        public void massiveSend()
        {
            TrabajadorConnectionWithDataBase trabCon = new TrabajadorConnectionWithDataBase();
            List<Trabajador> listaTrab = trabCon.getAllTrabajador();
            try
            {
                ValeMercaderiConnectionWithDatBase valeCon = new ValeMercaderiConnectionWithDatBase();
                foreach(Trabajador worker in listaTrab)
                {
                    ValeMercaderia vale = valeCon.getOneVale(worker.rut);
                    if (vale.activo)
                    {
                        PDFCreator pdfCreator = new PDFCreator();
                        pdfCreator.createPDFWithHTML(worker,vale,false);
                    }
                }
                MessageBox.Show("Envio Masivo exitoso");
            }
            catch(Exception e)
            {
                Console.WriteLine($"massiveSend()\n{e}");
            }

        }
    }
}
