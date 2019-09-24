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
        string sqlConnectionString = @"Data Source=WSP6788D;Initial Catalog=MBBM_Test;Integrated Security=True";
        string tableName = "[MBBM_Test].[dbo].[Persons]";

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

            string sqlQueryString = $"INSERT INTO {tableName} " +
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
            dataGridView1.ClearSelection();

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
                    string sqlQueryString = $"DELETE FROM {tableName} " +
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

            dataGridView1.ClearSelection();

        }

        private void GetAllRecordsFromDB()
        {
            string sqlQueryString = $"" +
                                    $"SELECT PersonID, Name, Surname, Age, Gender " +
                                    $"FROM {tableName};";

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter(sqlQueryString, sqlConnection);
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            dataGridView1.ClearSelection();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnDeleteRecords.Enabled = true;
            }
            else
            {
                btnDeleteRecords.Enabled = false;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var itemIdToUpdate = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            var sqlQueryString = $"UPDATE {tableName}" +
                $" SET [Name] = '{txtName.Text}', [Surname] = '{txtSurname.Text}', [Age] = '{txtAge.Text}', [Gender] = '{cmbGender.SelectedItem}'"+
                $" WHERE [PersonID] = '{itemIdToUpdate}';";
              

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();

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
            dataGridView1.ClearSelection();
        }
    }
}
