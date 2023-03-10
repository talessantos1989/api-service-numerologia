using MySql.Data.MySqlClient;

namespace NumerologiaCabalistica.Repository
{
	public class CommandRepository
	{
		public List<Customer> GetCustomers()
		{
			List<Customer> customers = new List<Customer>();
			DateTime dataDeHoje = DateTime.Now.Date;
			try
			{
				using (MySqlConnection conn = new MySqlConnection("server=containers-us-west-194.railway.app;database=numerologiacabalistica;uid=root;pwd=zDost56iJufiZOFYhrJX"))
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

		public void SaveSendMap(int id)
		{
			try
			{
				using (MySqlConnection conn = new MySqlConnection("server=localhost;database=numerologiacabalistica;uid=root;pwd=Admin@123"))
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