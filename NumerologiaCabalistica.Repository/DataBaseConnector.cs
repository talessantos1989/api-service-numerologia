using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
    public static class DataBaseConnector
    {
       
        public static string GetConnectionString()
        {
            string databaseURL = "mysql://root:Ma3GXkBCE2hU5LiCKGgV@containers-us-west-57.railway.app:5993/railway";
            string connectionString = "Host=containers-us-west-167.railway.app;Port=6491;User ID=postgres;password=SNuGk1HYtQQK1uhOeefh;Database=railway";

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
