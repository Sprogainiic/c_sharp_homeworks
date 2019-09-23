using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string sqlConnectionString = @"Data Source=DESKTOP-DCIOL1B\SQLEXPRESS;Initial Catalog=C_Sharp_Exercise_DB;Integrated Security=True";

        List<string> genderList = new List<string>() {"", "Male", "Female" };

        public Form1()
        {
            InitializeComponent();
            btnDeleteRecords.Enabled = false;
            cmbGender.DataSource = genderList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllRecordsFromDB();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {

            string sqlQueryString = $"INSERT INTO[C_Sharp_Exercise_DB].[dbo].[Persons] " +
                                    $"([Name], [Surname], [Age], [Gender]) " +
                                    $"VALUES('{txtName.Text}', '{txtSurname.Text}', {txtAge.Text}, '{cmbGender.SelectedItem}')";

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection))
                {
                    sqlConnection.Open();
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        GetAllRecordsFromDB();
                    }
                    catch
                    {
                        Console.WriteLine("Could not create table.");
                    }
                }
            }
        }

        private void btnDeleteRecords_Click(object sender, EventArgs e)
        {
            var idToDelete = new List<int>();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (dataGridView1.Rows[row.Index].Cells[0].Value != null)
                    {
                        idToDelete.Add((int)dataGridView1.Rows[row.Index].Cells[0].Value);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();

                foreach (var item in idToDelete)
                {
                    string sqlQueryString = $"DELETE FROM [C_Sharp_Exercise_DB].[dbo].[Persons] " +
                                            $"WHERE [PersonID] = {item} ";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection))
                    {
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            GetAllRecordsFromDB();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

            }
        }

        private void GetAllRecordsFromDB()
        {
            string sqlQueryString = $"" +
                                    $"SELECT PersonID, Name, Surname, Age, Gender " +
                                    $"FROM dbo.Persons;";

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter(sqlQueryString, sqlConnection);
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnDeleteRecords.Enabled = true;
            }
            else
            {
                btnDeleteRecords.Enabled = false;
            }
        }
    }
}
