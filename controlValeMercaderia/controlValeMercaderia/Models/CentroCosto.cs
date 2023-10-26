using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace controlValeMercaderia.Models
{
    internal class CentroCosto
    {
        public int id;
        public string nombre;

        public CentroCosto() { }

    }

    internal class CentroCostoConnectionWithDataBase
    {
        public CentroCostoConnectionWithDataBase() { }
        public List<CentroCosto> getAllCentroCosto()
        {
            List<CentroCosto> lista = new List<CentroCosto>();
            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getAllCentroCosto",conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CentroCosto centroCosto = new CentroCosto();

                            centroCosto.id = (int)dr["id"];
                            centroCosto.nombre = dr["nombre"].ToString().Trim();

                            lista.Add(centroCosto);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"getAllCentroCosto() \n{e.ToString()}");
            }
            return lista;
        }
    }
}
