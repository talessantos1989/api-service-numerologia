using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
	public class CommandRepository
	{
        public List<Customer> GetCustomers()
		{
			string connectionString = DataBaseConnector.GetConnectionString();

			List<Customer> customers = new List<Customer>();
			DateTime dataDeHoje = DateTime.Now.Date;
			try
			{
				using (MySqlConnection conn = new MySqlConnection(connectionString))
				{
					conn.Open();

					MySqlCommand command = new MySqlCommand($"SELECT id_cliente, nome, email, telefone, data_compra, data_nascimento, codigo_transacao from clientes where " +
						$"enviado = @enviado and data_compra < @dataDeHoje", conn);

					command.Parameters.AddWithValue("@enviado", 0);
					command.Parameters.AddWithValue("@dataDeHoje", dataDeHoje);
					Console.WriteLine(command.CommandText);
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

		

		public void SaveBDSendMap(int id)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection(DataBaseConnector.GetConnectionString()))
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