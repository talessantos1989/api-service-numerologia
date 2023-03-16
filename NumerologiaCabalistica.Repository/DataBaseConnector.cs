using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
    public static class DataBaseConnector
    {
       
        public static string GetConnectionString()
        {
            string databaseURL = Environment.GetEnvironmentVariable("MYSQL_URL");
            string connectionString = "server=sql725.main-hosting.eu;database=u317257256_numerologia;uid=u317257256_root;pwd=Admin@123;port=3306";

            return string.IsNullOrEmpty(databaseURL) ? connectionString : BuildConnectionString(databaseURL);
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
