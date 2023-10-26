namespace controlValeMercaderia.Controller
{
    internal class ConnectionDataBase
    {
        private const string dataSource = "Tu_Data_Source";
        private const string initialCatalog = "Tu_Initial_Catalog";
        private const string user = "Tu_User";
        private const string password = "Tu_Password";  


        private ConnectionDataBase() {
        }
        public static string getConnectionString()
        {
            return $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={user};Password={password}";
        }
    }
}
