using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlValeMercaderia.Models
{
    internal class Empresa
    {
        public int id;
        public string nombre;
        public string rut;
        public Empresa() { }
    }
    internal class Connection_Empresa
    {
        public Connection_Empresa() {}

        public Empresa getEmpresaByRut(string rut)
        {
            Empresa empresa = new Empresa();
            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getDataEmpresa",conexion);
                    cmd.Parameters.AddWithValue("rut", rut);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            empresa.id = Convert.ToInt32(dr["id"]);
                            empresa.nombre = Convert.ToString(dr["nombre"]).Trim();
                            empresa.rut = Convert.ToString(dr["rut"]).Trim();
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"getEmpresaByRut\n=>{ex.ToString()}");
            }
            return empresa;
        }
        public Empresa getDatosDimak()
        {
            return getEmpresaByRut("78809560");
        }
    }

}
