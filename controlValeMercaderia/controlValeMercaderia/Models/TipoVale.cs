using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlValeMercaderia.Models
{
    internal class TipoVale
    {
        public int id;
        public string nombre;
        public TipoVale() { }

    }

    internal class TipoValeConnectionDataBase
    {
        public TipoValeConnectionDataBase() { }

        public List<TipoVale> getAllTipoVale()
        {
            List<TipoVale> list = new List<TipoVale>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getAllTipoVale",conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TipoVale t = new TipoVale();
                            t.id = (int)dr["id"];
                            t.nombre = dr["nombre"].ToString().Trim();

                            list.Add(t);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"TipoValeConnectionDataBase()\n{e}");
            }
            return list;
        }
    }
}
