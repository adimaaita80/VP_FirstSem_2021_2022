using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_DB_2
{
    public partial class frmStudentsList : Form
    {

        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\user\\Documents\\StudentsDB.accdb";
        private OleDbConnection con;

        public frmStudentsList()
        {
            con = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void frmStudentsList_Load(object sender, EventArgs e)
        {
            UpdateStudentsGrid();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            InsertStudent(txtStudentNo.Text, txtFirstName.Text, txtLastName.Text);
            UpdateStudentsGrid();
        }

        private void InsertStudent(
            string studentNo, 
            string studentFirstName, 
            string studentLastName)
        {
            string insertCommand = $"Insert Into Students(StudentNo, StudentFirstName, StudentLastName) " +
                $"values('{studentNo}', '{studentFirstName}', '{studentLastName}')";

            OleDbCommand cmd = new OleDbCommand(insertCommand, con);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void UpdateStudentsGrid()
        {
            OleDbCommand cmd = new OleDbCommand("Select * from Students", con);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
