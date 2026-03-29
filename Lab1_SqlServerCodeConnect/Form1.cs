using Microsoft.Data.SqlClient;
using System.Data;

namespace Lab1_SqlServerCodeConnect
{
    public partial class Form1 : Form
    {
        const string CONNECTIONSTRING = @"server=.\SQLEXPRESS; database=northwind; Integrated Security=true; TrustServerCertificate=true;";
        public Form1()
        {
            InitializeComponent();
        }

        //This Event is raised whenever the selection changes in the ComboBox.
        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTables.SelectedIndex == -1)
            {
                MessageBox.Show("No Index Selected");
            }
            else
            {
                string selectedTable = cboTables.Text;
                LoadDataIntoGrid(selectedTable);

                grpStats.Visible = true;
            }
        }
        //loads the data from our db into dgvOutput
        private void LoadDataIntoGrid(string selectedTable)
        {
            //selects the entire table and creates the new DataTable obj
            string query = $"select * from [{selectedTable}]";
            DataTable dataTable = new DataTable();
            try
            {
                //opens our connection and our creates our SqlCommand obj
                using SqlConnection connection = new SqlConnection(CONNECTIONSTRING);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                //loads the data into dgvOutput
                dataTable.Load(command.ExecuteReader());
                dgvOutput.DataSource = dataTable;
                dgvOutput.AutoResizeColumns();
                connection.Close();
            }
            //catches any exception caused by our sql
            catch(Exception ex)
            {
                MessageBox.Show($"Load Data into Grid Failed\n Error: {ex}");
                dgvOutput.DataSource = null;
            }
        }

        //This Event is raised whenever the selection changes in the DataGridView
        private void dgvOutput_SelectionChanged(object sender, EventArgs e)
        {
            //only executes if you select rows
            if (dgvOutput.SelectedRows.Count > 0)
            {
                try
                {
                    //makes an empty string called pK for the switch case
                    string pK = "";
                    //checks the cboTable text value and checks the primary key of the selected row and calls the respective method
                    switch (cboTables.Text)
                    {
                        case "Customers":
                            pK = dgvOutput.SelectedRows[0].Cells["CustomerID"].Value.ToString();
                            DisplayCustomerStats(pK);
                            break;
                        case "Products":
                            pK = dgvOutput.SelectedRows[0].Cells["ProductID"].Value.ToString();
                            DisplayProductStats(pK);
                            break;
                        case "Orders":
                            pK = dgvOutput.SelectedRows[0].Cells["OrderID"].Value.ToString();
                            DisplayOrdersStats(pK);
                            break;
                        case "Employees":
                            pK = dgvOutput.SelectedRows[0].Cells["EmployeeID"].Value.ToString();
                            DisplayEmployeesStats(pK);
                            break;
                        //Mostly for testing i didnt make a spelling mistake in the cases but still could be useful error handling
                        default:
                            MessageBox.Show($"{cboTables.Text} Invalid Table");
                            break;
                    }
                }
                //catches any exceptions by the switch case
                catch(Exception ex)
                {
                    MessageBox.Show($"Error selecting the row\nError: {ex}");
                }
            }
        }
        //Methods that make a SQLQuery feeds it into ExecuteScalarQuery method and gets the results in a string. Afterwards updates the labels with the output and correct text
        private void DisplayEmployeesStats(string pK)
        {
            string queryNumberOrdersProcessed = $"SELECT COUNT(DISTINCT OrderID) FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID WHERE e.EmployeeID = @pK;";
            string numOrderProcessed = ExecuteScalarQuery(pK, queryNumberOrdersProcessed);

            string queryTotalSalesValue = $"SELECT FORMAT(SUM(UnitPrice * Quantity * (1 - Discount)), 'C') FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID JOIN [Order Details] od ON o.OrderID = od.OrderID WHERE e.EmployeeID = @pK;";
            string totalSalesValue = ExecuteScalarQuery(pK, queryTotalSalesValue);

            lblStat1Desc.Text = "Total Number of Orders Processed:";
            lblStat1Value.Text = numOrderProcessed;
            lblStat2Desc.Text = "Total Sales Value Handled:";
            lblStat2Value.Text = totalSalesValue;
        }
        private void DisplayOrdersStats(string pK)
        {

            string queryOrderValue = $"SELECT FORMAT(SUM(UnitPrice * Quantity * (1 - Discount)), 'C') FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID WHERE o.OrderID = @pK;";
            string ordVal = ExecuteScalarQuery(pK, queryOrderValue);

            string queryDistOrder = $"SELECT COUNT(DISTINCT ProductID) FROM [Order Details] WHERE OrderID = @pK;";
            string ordDist = ExecuteScalarQuery(pK, queryDistOrder);

            lblStat1Desc.Text = "Order Total Value:";
            lblStat1Value.Text = ordVal;
            lblStat2Desc.Text = "Number of Line Items:";
            lblStat2Value.Text = ordDist;
        }
        private void DisplayProductStats(string pK)
        {

            string queryUnitsSold = $"SELECT SUM(Quantity) FROM [Order Details] WHERE ProductID = @pK;";
            string unitsSold = ExecuteScalarQuery(pK, queryUnitsSold);

            string queryRevenueGen = $"SELECT FORMAT(SUM(UnitPrice * Quantity * (1 - Discount)), 'C') FROM [Order Details] WHERE ProductID = @pK;";
            string revenueGenerated = ExecuteScalarQuery(pK, queryRevenueGen);

            lblStat1Desc.Text = "Total Units Sold:";
            lblStat1Value.Text = unitsSold;
            lblStat2Desc.Text = "Total Revenue Generated:";
            lblStat2Value.Text = revenueGenerated;
        }
        private void DisplayCustomerStats(string pK)
        {

            string totalSpentQuery = $"SELECT FORMAT(SUM(UnitPrice * Quantity * (1 - Discount)), 'C') FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID WHERE c.CustomerID = @pK;";
            string customerSpent = ExecuteScalarQuery(pK, totalSpentQuery);

            string queryTotalOrders = $"SELECT COUNT(o.OrderID) AS TotalOrders FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID WHERE c.CustomerID = @pK;";
            string customerOrders = ExecuteScalarQuery(pK, queryTotalOrders);

            lblStat1Desc.Text = "Total Spent By Customer:";
            lblStat1Value.Text = customerSpent;
            lblStat2Desc.Text = "Total Number of Orders:";
            lblStat2Value.Text = customerOrders;
        }
        //takes in two strings and outputs a string
        private string ExecuteScalarQuery(string pK, string query)
        {
            try
            {
                //sets up out rString and our param of pK
                string rString;
                SqlParameter primaryKey = new SqlParameter("@pK", pK);
                //opens the connection
                using SqlConnection connection = new SqlConnection(CONNECTIONSTRING);
                connection.Open();   
                //creates a sqlcommand and adds the param to it
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(primaryKey);
                //Returns the rString with the data from the SQL command
                rString = command.ExecuteScalar().ToString();
                connection.Close();
                return rString;
                
            }
            //catches any errors caused by ExecuteScalarQuery
            catch (Exception ex)
            {
                MessageBox.Show($"Error Executing Sql Query: {ex}");
                return "";
            }
        }

        //Form Load Events occur AFTER the Form Constructor but BEFORE the Form is made
        //Visible to the user.
        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting up the initial table names in the ComboBox.
            string[] tables = { "Customers", "Products", "Orders", "Employees" };
            cboTables.Items.AddRange(tables);
            //Hiding the Group Box (grpStats) when there is no data to show in it!
            //We'll need to make this visible (can use .Show()) when there are relevant stats to display
            grpStats.Hide();
        }
    }
}
