using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
    public static class DataBaseConnector
    {
       
        public static string GetConnectionString()
        {
            string connectionString = "server=sql725.main-hosting.eu;database=u317257256_numerologia;uid=u317257256_root;pwd=Admin@123";

            return connectionString;
        }

        public static string GetConnectionString(string databaseUrl)
        {
            return BuildConnectionString(databaseUrl);
        }

        private static string BuildConnectionString(string databaseURL)
        {
            var databaseUri = new Uri(databaseURL);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new MySqlConnectionStringBuilder
            {
                Server = databaseUri.Host,
                Port = Convert.ToUInt32(databaseUri.Port),
                UserID = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = MySqlSslMode.Required
            };
            return builder.ToString();
        }
    }
}
