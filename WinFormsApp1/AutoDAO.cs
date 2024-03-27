using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Data;
using WinFormsApp1;

namespace DatabaseSQLCarDatabase
{
	internal class AutoDAO
	{
		public string FilePath { get; set; } = string.Empty;
		private string connectionString;

		public AutoDAO(string filePath)
		{
			FilePath = filePath;
			connectionString = $"datasource=localhost;port=3306;username=root;password=root;database={filePath}";
		}

		public List<Auto> getAllAuto(string filePath)
		{
			List<Auto> returnThese = new List<Auto>();
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();

			MySqlCommand command = new MySqlCommand("SELECT * FROM `auto`", connection);
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Auto a = new Auto
					{
						ID = reader.GetInt32(0),
						Mark = reader.GetString(1),
						Price = reader.GetString(2),
						Country = reader.GetString(3),
						Color = reader.GetString(4),
						Stock = reader.GetString(5),
					};
					returnThese.Add(a);
				}
			}
			connection.Close();

			return returnThese;
		}
		public List<Auto> createNew(string nameDatabase)
		{
			List<Auto> returnThese = new List<Auto>();
			string connectionString = "server=localhost;port=3306;user=root;password=root";
			using (MySqlConnection connection = new MySqlConnection(connectionString))
			{
				connection.Open();

				MySqlCommand createDatabaseCommand = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {nameDatabase}", connection);
				createDatabaseCommand.ExecuteNonQuery();

				connection.ChangeDatabase(nameDatabase);

				MySqlCommand createTableCommand = new MySqlCommand("CREATE TABLE IF NOT EXISTS auto (ID INT AUTO_INCREMENT PRIMARY KEY, MARK VARCHAR(100), PRICE VARCHAR(100), COUNTY VARCHAR(100), COLOR VARCHAR(100), STOCK VARCHAR(100))", connection);
				createTableCommand.ExecuteNonQuery();

				using (MySqlDataReader reader = createTableCommand.ExecuteReader())
				{
					while (reader.Read())
					{
						Auto a = new Auto
						{
							ID = reader.GetInt32(0),
							Mark = reader.GetString(1),
							Price = reader.GetString(2),
							Country = reader.GetString(3),
							Color = reader.GetString(4),
							Stock = reader.GetString(5),
						};
						returnThese.Add(a);
					}
				}
				connection.Close();
			}
			return returnThese;
		}
		public List<Auto> searchModels(String searchTerm)
		{
			List<Auto> returnThese = new List<Auto>();
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();

			String searchPhrase = "%" + searchTerm + "%";
			MySqlCommand command = new MySqlCommand();
			command.CommandText = "SELECT * FROM `auto` WHERE MARK LIKE @search";
			command.Parameters.AddWithValue("@search", searchPhrase);
			command.Connection = connection;

			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Auto a = new Auto
					{
						ID = reader.GetInt32(0),
						Mark = reader.GetString(1),
						Price = reader.GetString(2),
						Country = reader.GetString(3),
						Color = reader.GetString(4),
						Stock = reader.GetString(5),
					};
					returnThese.Add(a);
				}
			}
			connection.Close();

			return returnThese;
		}
		internal int addNewAuto(Auto auto)
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();

			MySqlCommand getMaxIdCommand = new MySqlCommand("SELECT MAX(ID) FROM `auto`", connection);
			object maxIdResult = getMaxIdCommand.ExecuteScalar();

			int newId = (maxIdResult != null && maxIdResult != DBNull.Value) ? Convert.ToInt32(maxIdResult) + 1 : 1;

			MySqlCommand command = new MySqlCommand("INSERT INTO `auto`(`ID`, `MARK`, `PRICE`, `COUNTY`, `COLOR`, `STOCK`) VALUES (@id, @mark, @price, @country, @color, @stock)", connection);
			command.Parameters.AddWithValue("@id", newId);
			command.Parameters.AddWithValue("@mark", auto.Mark);
			command.Parameters.AddWithValue("@price", auto.Price);
			command.Parameters.AddWithValue("@country", auto.Country);
			command.Parameters.AddWithValue("@color", auto.Color);
			command.Parameters.AddWithValue("@stock", auto.Stock);

			int newRows = command.ExecuteNonQuery();
			connection.Close();

			return newRows;
		}
		internal int deleteAuto(int autoID)
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();

			MySqlCommand command = new MySqlCommand("DELETE FROM `auto` WHERE `auto`.`ID` = @id", connection);
			command.Parameters.AddWithValue("@id", autoID);
			int result = command.ExecuteNonQuery();
			connection.Close();

			return result;
		}
		internal int updateAutoInDatabase(Auto auto)
		{
			int rowsAffected = 0;

			using (MySqlConnection connection = new MySqlConnection(connectionString))
			{
				connection.Open();

				MySqlCommand command = new MySqlCommand("UPDATE `auto` SET `MARK` = @mark, `PRICE` = @price, `COUNTY` = @country, `COLOR` = @color, `STOCK` = @stock WHERE `ID` = @autoID", connection);
				command.Parameters.AddWithValue("@autoID", auto.ID);
				command.Parameters.AddWithValue("@mark", auto.Mark);
				command.Parameters.AddWithValue("@price", auto.Price);
				command.Parameters.AddWithValue("@country", auto.Country);
				command.Parameters.AddWithValue("@color", auto.Color);
				command.Parameters.AddWithValue("@stock", auto.Stock);

				rowsAffected = command.ExecuteNonQuery();

				connection.Close();
			}

			return rowsAffected;
		}
		internal List<Auto> SortByMark()
		{
			List<Auto> sortedAutos = new List<Auto>();

			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("SELECT * FROM `auto` ORDER BY MARK ASC", connection);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Auto auto = new Auto
							{
								ID = reader.GetInt32(0),
								Mark = reader.GetString(1),
								Price = reader.GetString(2),
								Country = reader.GetString(3),
								Color = reader.GetString(4),
								Stock = reader.GetString(5)
							};
							sortedAutos.Add(auto);
						}
					}

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сортировке по столбцу MARK: {ex.Message}");
			}

			return sortedAutos;
		}
		internal List<Auto> SortByPrice()
		{
			List<Auto> sortedAutos = new List<Auto>();

			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("SELECT * FROM `auto` ORDER BY PRICE ASC", connection);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Auto auto = new Auto
							{
								ID = reader.GetInt32(0),
								Mark = reader.GetString(1),
								Price = reader.GetString(2),
								Country = reader.GetString(3),
								Color = reader.GetString(4),
								Stock = reader.GetString(5)
							};
							sortedAutos.Add(auto);
						}
					}

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сортировке по столбцу PRICE: {ex.Message}");
			}

			return sortedAutos;
		}
		internal List<Auto> SortByCountry()
		{
			List<Auto> sortedAutos = new List<Auto>();

			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("SELECT * FROM `auto` ORDER BY COUNTY ASC", connection);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Auto auto = new Auto
							{
								ID = reader.GetInt32(0),
								Mark = reader.GetString(1),
								Price = reader.GetString(2),
								Country = reader.GetString(3),
								Color = reader.GetString(4),
								Stock = reader.GetString(5)
							};
							sortedAutos.Add(auto);
						}
					}

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сортировке по столбцу COUNTRY: {ex.Message}");
			}

			return sortedAutos;
		}
		internal List<Auto> SortByColor()
		{
			List<Auto> sortedAutos = new List<Auto>();

			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("SELECT * FROM `auto` ORDER BY COLOR ASC", connection);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Auto auto = new Auto
							{
								ID = reader.GetInt32(0),
								Mark = reader.GetString(1),
								Price = reader.GetString(2),
								Country = reader.GetString(3),
								Color = reader.GetString(4),
								Stock = reader.GetString(5)
							};
							sortedAutos.Add(auto);
						}
					}

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сортировке по столбцу COLOR: {ex.Message}");
			}

			return sortedAutos;
		}
		internal List<Auto> SortByStock()
		{
			List<Auto> sortedAutos = new List<Auto>();

			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("SELECT * FROM `auto` ORDER BY STOCK ASC", connection);

					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Auto auto = new Auto
							{
								ID = reader.GetInt32(0),
								Mark = reader.GetString(1),
								Price = reader.GetString(2),
								Country = reader.GetString(3),
								Color = reader.GetString(4),
								Stock = reader.GetString(5)
							};
							sortedAutos.Add(auto);
						}
					}

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сортировке по столбцу STOCK: {ex.Message}");
			}

			return sortedAutos;
		}
		public void InsertAutos(List<Auto> autos)
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();

			foreach (Auto auto in autos)
			{
				MySqlCommand command = new MySqlCommand("INSERT INTO `auto`(`MARK`, `PRICE`, `COUNTY`, `COLOR`, `STOCK`) VALUES (@mark, @price, @country, @color, @stock)", connection);
				command.Parameters.AddWithValue("@mark", auto.Mark);
				command.Parameters.AddWithValue("@price", auto.Price);
				command.Parameters.AddWithValue("@country", auto.Country);
				command.Parameters.AddWithValue("@color", auto.Color);
				command.Parameters.AddWithValue("@stock", auto.Stock);

				command.ExecuteNonQuery();
			}

			connection.Close();
		}
		internal void ClearDatabase()
		{
			try
			{
				using (MySqlConnection connection = new MySqlConnection(connectionString))
				{
					connection.Open();

					MySqlCommand command = new MySqlCommand("TRUNCATE TABLE `auto`", connection);
					command.ExecuteNonQuery();

					connection.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при очистке базы данных: {ex.Message}");
			}
		}
	}
}
