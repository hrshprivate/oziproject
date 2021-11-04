using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.textBox3.AutoSize = false;
            this.textBox3.Size = new Size(this.textBox3.Size.Width, 44);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`) VALUES (@login, @password)", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox3.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт создал,красава!");
            else
                MessageBox.Show("Аккаунт не создал,дуралей!");
            db.closeConnection();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point lastpoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }

    
}
