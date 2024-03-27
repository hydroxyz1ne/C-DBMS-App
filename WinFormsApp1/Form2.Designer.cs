
namespace WinFormsApp1
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			textBox1 = new TextBox();
			label1 = new Label();
			button1 = new Button();
			button2 = new Button();
			textBox2 = new TextBox();
			button3 = new Button();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			textBox5 = new TextBox();
			textBox6 = new TextBox();
			textBox7 = new TextBox();
			label2 = new Label();
			button4 = new Button();
			button5 = new Button();
			button6 = new Button();
			button7 = new Button();
			button8 = new Button();
			button9 = new Button();
			button10 = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.BackgroundColor = SystemColors.Window;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(261, 231);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(744, 396);
			dataGridView1.TabIndex = 0;
			dataGridView1.CellContentClick += dataGridView1_CellContentClick;
			dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
			// 
			// textBox1
			// 
			textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			textBox1.ForeColor = SystemColors.ScrollBar;
			textBox1.Location = new Point(260, 84);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(558, 29);
			textBox1.TabIndex = 1;
			textBox1.Text = "Введите имя базы данных";
			textBox1.WordWrap = false;
			textBox1.TextChanged += textBox1_TextChanged;
			textBox1.Enter += textBox1_Enter;
			textBox1.Leave += textBox1_Leave;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.Location = new Point(260, 21);
			label1.Name = "label1";
			label1.Size = new Size(328, 45);
			label1.TabIndex = 2;
			label1.Text = "Открыть или создать";
			// 
			// button1
			// 
			button1.Location = new Point(824, 84);
			button1.Name = "button1";
			button1.Size = new Size(90, 31);
			button1.TabIndex = 3;
			button1.Text = "Открыть";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(920, 84);
			button2.Name = "button2";
			button2.Size = new Size(85, 31);
			button2.TabIndex = 4;
			button2.Text = "Создать";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// textBox2
			// 
			textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			textBox2.Location = new Point(261, 129);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(653, 29);
			textBox2.TabIndex = 5;
			textBox2.Enter += textBox2_Enter;
			textBox2.Leave += textBox2_Leave;
			// 
			// button3
			// 
			button3.Location = new Point(920, 127);
			button3.Name = "button3";
			button3.Size = new Size(85, 31);
			button3.TabIndex = 6;
			button3.Text = "Поиск";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// textBox3
			// 
			textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			textBox3.Location = new Point(12, 286);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(242, 29);
			textBox3.TabIndex = 7;
			textBox3.TextChanged += textBox3_TextChanged;
			// 
			// textBox4
			// 
			textBox4.Font = new Font("Segoe UI", 12F);
			textBox4.Location = new Point(12, 333);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(242, 29);
			textBox4.TabIndex = 8;
			textBox4.TextChanged += textBox4_TextChanged;
			// 
			// textBox5
			// 
			textBox5.Font = new Font("Segoe UI", 12F);
			textBox5.Location = new Point(12, 380);
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(242, 29);
			textBox5.TabIndex = 9;
			textBox5.TextChanged += textBox5_TextChanged;
			// 
			// textBox6
			// 
			textBox6.Font = new Font("Segoe UI", 12F);
			textBox6.Location = new Point(12, 427);
			textBox6.Name = "textBox6";
			textBox6.Size = new Size(242, 29);
			textBox6.TabIndex = 10;
			textBox6.TextChanged += textBox6_TextChanged;
			// 
			// textBox7
			// 
			textBox7.Font = new Font("Segoe UI", 12F);
			textBox7.Location = new Point(12, 474);
			textBox7.Name = "textBox7";
			textBox7.Size = new Size(242, 29);
			textBox7.TabIndex = 11;
			textBox7.TextChanged += textBox7_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(12, 231);
			label2.Name = "label2";
			label2.Size = new Size(176, 32);
			label2.TabIndex = 12;
			label2.Text = "Добавить авто";
			// 
			// button4
			// 
			button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button4.Location = new Point(12, 518);
			button4.Name = "button4";
			button4.Size = new Size(242, 144);
			button4.TabIndex = 13;
			button4.Text = "Добавить ";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// button5
			// 
			button5.Location = new Point(260, 633);
			button5.Name = "button5";
			button5.Size = new Size(745, 29);
			button5.TabIndex = 14;
			button5.Text = "Удалить выбранную запись";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click;
			// 
			// button6
			// 
			button6.Location = new Point(261, 169);
			button6.Name = "button6";
			button6.Size = new Size(140, 56);
			button6.TabIndex = 15;
			button6.Text = "Cортировать по марке";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button6_Click;
			// 
			// button7
			// 
			button7.Location = new Point(412, 169);
			button7.Name = "button7";
			button7.Size = new Size(140, 56);
			button7.TabIndex = 16;
			button7.Text = "Cортировать по стоимости";
			button7.UseVisualStyleBackColor = true;
			button7.Click += button7_Click;
			// 
			// button8
			// 
			button8.Location = new Point(563, 169);
			button8.Name = "button8";
			button8.Size = new Size(140, 56);
			button8.TabIndex = 17;
			button8.Text = "Cортировать по стране";
			button8.UseVisualStyleBackColor = true;
			button8.Click += button8_Click;
			// 
			// button9
			// 
			button9.Location = new Point(714, 169);
			button9.Name = "button9";
			button9.Size = new Size(140, 56);
			button9.TabIndex = 18;
			button9.Text = "Cортировать по цвету";
			button9.UseVisualStyleBackColor = true;
			button9.Click += button9_Click;
			// 
			// button10
			// 
			button10.Location = new Point(865, 169);
			button10.Name = "button10";
			button10.Size = new Size(140, 56);
			button10.TabIndex = 19;
			button10.Text = "Cортировать по наличию";
			button10.UseVisualStyleBackColor = true;
			button10.Click += button10_Click;
			// 
			// Form2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1020, 674);
			Controls.Add(button10);
			Controls.Add(button9);
			Controls.Add(button8);
			Controls.Add(button7);
			Controls.Add(button6);
			Controls.Add(button5);
			Controls.Add(button4);
			Controls.Add(label2);
			Controls.Add(textBox7);
			Controls.Add(textBox6);
			Controls.Add(textBox5);
			Controls.Add(textBox4);
			Controls.Add(textBox3);
			Controls.Add(button3);
			Controls.Add(textBox2);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(label1);
			Controls.Add(textBox1);
			Controls.Add(dataGridView1);
			Name = "Form2";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Form2";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
		}

		#endregion

		private DataGridView dataGridView1;
		private TextBox textBox1;
		private Label label1;
		private Button button1;
		private Button button2;
		private TextBox textBox2;
		private Button button3;
		private TextBox textBox3;
		private TextBox textBox4;
		private TextBox textBox5;
		private TextBox textBox6;
		private TextBox textBox7;
		private Label label2;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button7;
		private Button button8;
		private Button button9;
		private Button button10;
	}
}