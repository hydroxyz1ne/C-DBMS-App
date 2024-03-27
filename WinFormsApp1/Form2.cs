using DatabaseSQLCarDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public partial class Form2 : Form
	{
		private string filePath = string.Empty;

		BindingSource bindingSource = new BindingSource();

		List<Auto> auto = new List<Auto>();

		public string FilePath
		{
			get { return filePath; }
		}
		public Form2()
		{
			InitializeComponent();
			InitializeTextBoxPlaceholder();
		}

		private void InitializeTextBoxPlaceholder()
		{
			textBox1.Text = "Введите название базы данных";
			textBox1.ForeColor = System.Drawing.Color.Gray;
			textBox2.Text = "Введите наименование модели";
			textBox2.ForeColor = System.Drawing.Color.Gray;
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
			if (textBox1.Text == "Введите название базы данных")
			{
				textBox1.Text = "";
				textBox1.ForeColor = System.Drawing.Color.Black;
			}
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			if (textBox2.Text == "Введите наименование модели")
			{
				textBox2.Text = "";
				textBox2.ForeColor = System.Drawing.Color.Black;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				textBox1.Text = "Введите название базы данных";
				textBox1.ForeColor = System.Drawing.Color.Gray;
			}
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox2.Text))
			{
				textBox2.Text = "Введите наименование модели";
				textBox2.ForeColor = System.Drawing.Color.Gray;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			filePath = textBox1.Text;
			AutoDAO autoDAO = new AutoDAO(filePath);
			bindingSource.DataSource = autoDAO.getAllAuto(filePath);

			dataGridView1.DataSource = bindingSource;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			filePath = textBox1.Text;
			AutoDAO autoDAO = new AutoDAO(filePath);
			bindingSource.DataSource = autoDAO.createNew(textBox1.Text);

			dataGridView1.DataSource = bindingSource;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			bindingSource.DataSource = autoDAO.searchModels(textBox2.Text);

			dataGridView1.DataSource = bindingSource;
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			Auto auto = new Auto
			{
				Mark = textBox3.Text,
				Price = textBox4.Text,
				Country = textBox5.Text,
				Color = textBox6.Text,
				Stock = textBox7.Text,

			};
			AutoDAO autoDAO = new AutoDAO(filePath);
			int result = autoDAO.addNewAuto(auto);
			MessageBox.Show("Новая строка вставлена");

			List<Auto> allAuto = autoDAO.getAllAuto(filePath);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = allAuto;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int rowClicked = dataGridView1.CurrentRow.Index;
			int autoID = (int)dataGridView1.Rows[rowClicked].Cells[0].Value;

			AutoDAO autoDAO = new AutoDAO(filePath);

			int result = autoDAO.deleteAuto(autoID);

			MessageBox.Show("Запись удалена");

			auto = autoDAO.getAllAuto(filePath);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = auto;
		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			DataGridViewCell editedCell = dataGridView1.Rows[rowIndex].Cells[columnIndex];

			// Получаем ID записи из первого столбца (предполагается, что ID находится в первом столбце)
			int autoID = (int)dataGridView1.Rows[rowIndex].Cells["ID"].Value;

			string columnName = dataGridView1.Columns[columnIndex].Name;
			string newValue = editedCell.Value.ToString();
			Auto updatedAuto = new Auto
			{
				ID = autoID,
				Mark = (columnName == "MARK") ? newValue : dataGridView1.Rows[rowIndex].Cells["MARK"].Value.ToString(),
				Price = (columnName == "PRICE") ? newValue : dataGridView1.Rows[rowIndex].Cells["PRICE"].Value.ToString(),
				Country = (columnName == "COUNTRY") ? newValue : dataGridView1.Rows[rowIndex].Cells["COUNTRY"].Value.ToString(),
				Color = (columnName == "COLOR") ? newValue : dataGridView1.Rows[rowIndex].Cells["COLOR"].Value.ToString(),
				Stock = (columnName == "STOCK") ? newValue : dataGridView1.Rows[rowIndex].Cells["STOCK"].Value.ToString()
			};

			// Обновляем запись в базе данных
			AutoDAO autoDAO = new AutoDAO(filePath);
			int result = autoDAO.updateAutoInDatabase(updatedAuto);

			// Если обновление прошло успешно, выводим сообщение об успехе
			if (result > 0)
			{
				MessageBox.Show("Данные успешно обновлены");
			}
			else
			{
				MessageBox.Show("Ошибка при обновлении данных");
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			List<Auto> sortedAutos = autoDAO.SortByMark();
			autoDAO.ClearDatabase();
			autoDAO.InsertAutos(sortedAutos);
			dataGridView1.DataSource = null; 
			dataGridView1.DataSource = sortedAutos;

		}

		private void button7_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			List<Auto> sortedAutos = autoDAO.SortByPrice();
			autoDAO.ClearDatabase();
			autoDAO.InsertAutos(sortedAutos);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = sortedAutos;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			List<Auto> sortedAutos = autoDAO.SortByCountry();
			autoDAO.ClearDatabase();
			autoDAO.InsertAutos(sortedAutos);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = sortedAutos;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			List<Auto> sortedAutos = autoDAO.SortByColor();
			autoDAO.ClearDatabase();
			autoDAO.InsertAutos(sortedAutos);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = sortedAutos;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			AutoDAO autoDAO = new AutoDAO(filePath);
			List<Auto> sortedAutos = autoDAO.SortByStock();
			autoDAO.ClearDatabase();
			autoDAO.InsertAutos(sortedAutos);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = sortedAutos;
		}
	}

}
