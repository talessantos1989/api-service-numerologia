using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
    public static class DataBaseConnector
    {
       
        public static string GetConnectionString()
        {
            string databaseURL = "mysql://root:Ma3GXkBCE2hU5LiCKGgV@containers-us-west-57.railway.app:5993/railway";
            string connectionString = "server=sql725.main-hosting.eu;port=3306;uid=u317257256_root;pwd=Primeiradama0811;sslmode=disabled;database=u317257256_numerologia";

            return connectionString;
            //return BuildConnectionString(databaseURL);
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
                SslMode = MySqlSslMode.Disabled
            };
            return builder.ToString();
        }
    }
}
