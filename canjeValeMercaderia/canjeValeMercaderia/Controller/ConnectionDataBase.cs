using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dimak.Controller
{
    internal class ConnectionDataBase
    {

        private const string dataSource = "DESKTOP-FP72OS2\\SQLEXPRESS";
        private const string initialCatalog = "valeMercaderia_Dimak";
        private const string user = "sa";
        private const string password = "admin";


        private ConnectionDataBase(){}
        public static string getConnectionString()
        {
            return $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={user};Password={password}";
        }
    }
}
