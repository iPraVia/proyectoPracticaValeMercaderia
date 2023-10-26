using System;
using System.Data.SqlClient;

namespace dimak.Controller
{
    internal class ValeMercaderiaConnectionDataBase
    {
        public ValeMercaderiaConnectionDataBase() { }

        public bool isActiveVale(int id_trabajador)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getOneValeMercaderia",conexion);
                    cmd.Parameters.AddWithValue("id_trabajador",id_trabajador);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if ((((byte)dr["estado"]) == 1))
                            {
                                return true;
                            }
                        }
                    }

                }
            }
            catch(SqlException e)
            {
                Console.WriteLine($"getActiveVale\n{e}");
            }
            return false;
        }
        public bool canjearVale(int id_trabajador)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_canjearVale", conexion);
                    cmd.Parameters.AddWithValue("id_trabajador",id_trabajador);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"canjearVale\n{e}");
            }
            return false;
        }
    }
}
