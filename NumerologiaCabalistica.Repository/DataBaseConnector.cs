using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerologiaCabalistica.Repository
{
    public static class DataBaseConnector
    {
       
        public static string GetConnectionString()
        {
            string databaseURL = Environment.GetEnvironmentVariable("MYSQL_URL");
            string connectionString = "server=localhost;database=numerologiacabalistica;uid=root;pwd=Admin@123";

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
