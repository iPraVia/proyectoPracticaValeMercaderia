using controlValeMercaderia.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.OneD;

namespace controlValeMercaderia.Models
{
    internal class SMTP
    {
        public int id;
        public string email;
        public string password;
        public string smtp_host;
        public int smtp_port;
        public string alias;
        public SMTP() { }
    }
    
    internal class Connection_SMTP
    {
        public Connection_SMTP() { }

        public SMTP getDataConnection()
        {
            SMTP smtp = new SMTP();
            try
            {
                using (var conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getDataConnectionSMTP",conexion);
                    cmd.Parameters.AddWithValue("id",1);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            smtp.id = (int)(dr["id"]);
                            smtp.email = (dr["email"]).ToString().Trim();
                            smtp.password = (dr["password"]).ToString().Trim();
                            smtp.smtp_host = (dr["smtp_host"]).ToString().Trim();
                            smtp.smtp_port = (int)(dr["smtp_port"]);
                            smtp.alias = "Dimak";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"getDataConnection\n=>{ex.ToString()}");
            }
            return smtp;
        }
        public SMTP getDataEmail()
        {
            SMTP smtp = new SMTP();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getDataEmail", conexion);
                    cmd.Parameters.AddWithValue("id", 1);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            smtp.email = dr["email"].ToString().Trim();
                            smtp.password = dr["password"].ToString().Trim();
                            smtp.alias = dr["alias"].ToString().Trim();
                            smtp.smtp_host = string.Empty;
                            smtp.smtp_port = 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"getDataEmail\n{e}");
            }
            return smtp;
        }
        public bool updateDataEmail(string email,string pass,string alias="")
        {
            bool update = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_updateDataEmail", conexion);
                    
                    cmd.Parameters.AddWithValue("email",email);
                    cmd.Parameters.AddWithValue("password",pass);
                    cmd.Parameters.AddWithValue("alias",alias);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    update = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"updateDataEmail\n{e}");
            }
            return update;
        }
        public bool updateDataSMTP(string HOST,int PORT)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_updateDataSMTP", conexion);
                    cmd.Parameters.AddWithValue("host", HOST);
                    cmd.Parameters.AddWithValue("port", PORT);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    return true;
                }
            }catch(SqlException e)
            {
                Console.WriteLine($"updateDataSMTP\n{e}");
                return false;
            }
        }
        public bool existsDataSMTP()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConnectionDataBase.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_getDataSMTP", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            continue;
                        }
                    }
                }
                return true;
            }
            catch(SqlException e)
            {
                return false;
            }
        }
    }

}