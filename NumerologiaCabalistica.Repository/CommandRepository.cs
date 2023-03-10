using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace NumerologiaCabalistica.Repository
{
	public class CommandRepository
	{
		string databaseURL = Environment.GetEnvironmentVariable("DATABASE_URL");
		string connectionString = "server=localhost;database=numerologiacabalistica;uid=root;pwd=Admin@123";
		public List<Customer> GetCustomers()
		{
			string connectionString = GetConnectionString();

			List<Customer> customers = new List<Customer>();
			DateTime dataDeHoje = DateTime.Now.Date;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					MySqlCommand command = new MySqlCommand($"SELECT id_cliente, nome, email, telefone, data_compra, data_nascimento, codigo_transacao from CLIENTES where " +
						$"enviado = @enviado and data_compra < @dataDeHoje", conn);

					command.Parameters.AddWithValue("@enviado", 0);
					command.Parameters.AddWithValue("@dataDeHoje", dataDeHoje);

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							customers.Add(new Customer()
							{
								NomeCompleto = reader.GetString("nome"),
								CodigoTransacao = reader.GetString("codigo_transacao"),
								DataCompra = reader.GetDateTime("data_compra"),
								DataDeNascimento = reader.GetDateTime("data_nascimento"),
								Email = reader.GetString("email"),
								Telefone = reader.GetString("telefone"),
								Id = reader.GetInt32("id_cliente")
							});
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return customers;
		}

		private string GetConnectionString()
		{
			return string.IsNullOrEmpty(databaseURL) ? connectionString : BuildConnectionString(databaseURL);
		}

		private string BuildConnectionString(string databaseURL)
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

		public void SaveSendMap(int id)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
				{
					conn.Open();
					MySqlCommand command = new MySqlCommand($"UPDATE clientes SET enviado = 1 where id_cliente = @id_cliente", conn);
					command.Parameters.AddWithValue("@id_cliente", id);
					command.ExecuteNonQuery();

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}