using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace controlValeMercaderia.Models
{
    internal class Trabajador
    {
        public string nombre;
        public string apellido_paterno;
        public string apellido_materno;
        public string rut;
        public DateTime fecha_ingreso;
        public string centro_costo;
        public Bitmap QRCode;
        public string tramo;
        public string email;

        public Trabajador(){}
        public void getTramo()
        {
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(fecha_ingreso);
            int dias = (int)diff.TotalDays;

            tramo = asignTramo(dias);
        }
        private string asignTramo(int dias)
        {
            string tramo = "";
            //TRAMO 7 => 1DIA A 3MESES => $19.500
            if (dias > 0 && dias < 91)
            {
                tramo = "T7";
            }
            //TRAMO 6 => 4MESES A 11MESES => $29.000
            else if (dias > 90 && dias < 365)
            {
                tramo = "T6";
            }
            //TRAMO 5 => 1AÑO A 2MESES Y 11MESES => $42.000
            else if (dias > 364 && dias < 1095)
            {
                tramo = "T5";
            }
            //TRAMO 4 => 3AÑOS A 5AÑOS Y 11MESES => $46.000
            else if (dias > 1094 && dias < 2190)
            {
                tramo = "T4";
            }
            //TRAMO 3 => 6AÑOS A 9AÑOS Y 11MESES => $52.000
            else if (dias > 2189 && dias < 3650)
            {
                tramo = "T3";
            }
            //TRAMO 2 => 10AÑOS A 14AÑOS Y 11MESES => $55.000
            else if (dias > 3649 && dias < 5475)
            {
                tramo = "T2";
            }
            //TRAMO 1 => 15AÑOS Y MAS => $60.000
            else if (dias > 5474)
            {
                tramo = "T1";
            }
            return tramo;
        }
    }
    internal class TrabajadorConnectionWithDataBase
    {
        public TrabajadorConnectionWithDataBase(){}
        public Trabajador getOneTrabajador(string rut)
        {
            Trabajador trabajador = new Trabajador();
            try
            {   
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getOneTrabajador", conexion);
                    cmd.Parameters.AddWithValue("RUT", rut);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            trabajador.nombre = dr["nombre"].ToString();
                            trabajador.apellido_paterno = dr["apellido_paterno"].ToString();
                            trabajador.rut = dr["rut"].ToString().Trim();
                            trabajador.fecha_ingreso = (DateTime)dr["fecha_ingreso"];
                            trabajador.centro_costo = dr["centro_costo"].ToString();
                            trabajador.apellido_materno = dr["apellido_materno"].ToString() ?? "";
                            trabajador.email = dr["email"].ToString() ?? "";
                            trabajador.QRCode = createImageQR(trabajador.rut);

                            trabajador.getTramo();
                        }
                    }
                }
            }catch(SqlException e)
            {
                Console.WriteLine($"getOneTrabajador\n{e}");
            }
            return trabajador;
        }
        public List<Trabajador> getAllTrabajador()
        {
            List<Trabajador> lista = new List<Trabajador>();
            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getAllTrabajador", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Trabajador trabajador = createTrabajador(dr);
                            lista.Add(trabajador);
                        }
                    }

                }
            }catch(SqlException e)
            {
                Console.WriteLine($"Error de conexion\n=>{e.ToString()}");
            }
            return lista;
        }
        public List<Trabajador> getTrabajadorByCentroCsto(int id)
        {
            List<Trabajador> lista = new List<Trabajador>();

            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getTrabajadorByCentroCosto",conexion);
                    cmd.Parameters.AddWithValue("id_centro_costo", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Trabajador trabajador = createTrabajador(dr);
                            lista.Add(trabajador);
                        }
                    }
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine($"getTrabajadorByCentroCsto()\n{e.ToString()}");
            }

            return lista;
        }
        private Trabajador createTrabajador(SqlDataReader dr)
        {
            Trabajador trabajador = new Trabajador();

            trabajador.nombre = dr["nombre"].ToString().Trim();
            trabajador.apellido_paterno = dr["apellido_paterno"].ToString().Trim();
            trabajador.rut = dr["rut"].ToString().Trim();
            trabajador.fecha_ingreso = (DateTime)dr["fecha_ingreso"];
            trabajador.centro_costo = dr["centro_costo"].ToString().Trim();
            trabajador.apellido_materno = dr["apellido_materno"].ToString().Trim() ?? string.Empty;
            trabajador.email = dr["email"].ToString().Trim() ?? string.Empty;
            trabajador.QRCode = createImageQR(trabajador.rut);
            trabajador.getTramo();

            return trabajador;
        }
        private Bitmap createImageQR(string inputText)
        {
            var barcodeWriter = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 233,
                    Height = 233,
                    Margin = 1
                }
            };

            Bitmap qrImage = barcodeWriter.Write(inputText);
            return qrImage;
        }
    }
}
