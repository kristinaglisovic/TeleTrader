using TeleTrader.Extensions;
using TeleTrader.Forms;
using TeleTrader.Models;

namespace TeleTrader
{
    public partial class Form1 : Form
    {
        private DataHandler dataHandler;

        public Form1()
        {
            InitializeComponent();

            // Fill-ovanje kolona kako ne bi postojao blank space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            DisableFormControls();
        }
        private void databaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Otvaranje dialog-a za odabir željene baze
                openFileDialog.Filter = "SQLite Database File|*.sqlite;*.db3;*.s3db|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string databaseFilePath = openFileDialog.FileName;

                    try
                    {
                        if (ValidationExtensions.IsValidDatabaseFile(databaseFilePath) && dataHandler == null)
                        {
                            string selectedFilePath = openFileDialog.FileName;

                            // Kreiranje DataHandler objekta sa putanjom do baze
                            dataHandler = new DataHandler(selectedFilePath);

                            // Popunjavanje Type Combobox-a sa opcijom all
                            dataHandler.LoadDataIntoComboBox(comboBoxType, "Name", "Type", true);

                            // Popunjavanje Exchange Combobox-a
                            dataHandler.LoadDataIntoComboBox(comboBoxExchange, "Name", "Exchange", true);

                            SharedData.ComboBoxExchangeItems = comboBoxExchange.Items.OfType<string>().ToList();
                            SharedData.ComboBoxTypeItems = comboBoxType.Items.OfType<string>().ToList();

                            // Popunjavanje DataGridView-a podacima iz Symbol tabele (bez filtera)
                            LoadInitialForm();

                            // Button enable
                            EnableFormControls();
                        }
                        else
                        {
                            // Fajl nije validan
                            MessageBox.Show("Error: Invalid database file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Prikaz bilo kakve greške koje se pojave prilikom rada sa bazom podataka
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        //Filter
        private void button1_Click(object sender, EventArgs e)
        {
            // Dobijanje izabranog filtera za Exchange ComboBox
            string exchangeFilter = comboBoxExchange.SelectedItem.ToString();

            // Dobijanje izabranog filtera za Type ComboBox
            string typeFilter = comboBoxType.SelectedItem.ToString();

            // Ažuriranje podataka u DataGridView-u sa primenjenim filterima
            dataHandler.LoadDataIntoDataGridView(dataGridView1, exchangeFilter, typeFilter, lbDataCount);

        }

        // Add Symbol
        private void button2_Click(object sender, EventArgs e)
        {
            SymbolForm modalForm = new SymbolForm(FormMode.Add, new Symbol { DateAdded = DateTime.Now.Date, PriceDate=DateTime.Now });

            if (modalForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataHandler.AddSymbol(modalForm.ModifiedSymbol);

                    LoadInitialForm();

                    SelectRowBySymbolName(modalForm.ModifiedSymbol.NewSymbolName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // View or Edit Symbol
        private void button3_Click(object sender, EventArgs e)
        {
            // Provera da li je selektovan red u formi
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Dohvatanje selektovanog reda
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                var symbol = new Symbol
                {
                    OriginalSymbolName = selectedRow.Cells["Name"].Value.ToString(),
                    Ticker = selectedRow.Cells["Ticker"].Value.ToString(),
                    Price = double.Parse(selectedRow.Cells["Price"].Value.ToString()),
                    ExName = selectedRow.Cells["ExchangeName"].Value.ToString(),
                    TypeName = selectedRow.Cells["TypeName"].Value.ToString(),
                    DateAdded = ((DateTime)selectedRow.Cells["DateAdded"].Value),
                    PriceDate= ((DateTime)selectedRow.Cells["PriceDate"].Value),
                    Isin= selectedRow.Cells["Isin"].Value.ToString(),
                    CurrencyCode= selectedRow.Cells["CurrencyCode"].Value.ToString()
                };

                // Instanca modala i prosleđivanje podataka
                SymbolForm modalForm = new SymbolForm(FormMode.ViewOrEdit, symbol);

                if (modalForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dataHandler.EditSymbol(modalForm.ModifiedSymbol);

                        LoadInitialForm();

                        SelectRowBySymbolName(modalForm.ModifiedSymbol.NewSymbolName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to view or edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Delete Symbol
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string symbolName = selectedRow.Cells["Name"].Value.ToString();

                // Dialog
                var result = MessageBox.Show($"Are you sure you want to delete the symbol '{symbolName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        dataHandler.DeleteSymbol(symbolName);


                        LoadInitialForm();


                        MessageBox.Show($"Symbol '{symbolName}' has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Unload Database
        private void unloadDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataHandler = null;
            dataGridView1.DataSource = null;
            comboBoxExchange.Items.Remove("All");
            comboBoxExchange.Items.Clear();
            comboBoxType.Items.Remove("All");
            comboBoxType.Items.Clear();
            lbDataCount.Text = "Data Count: 0";
            DisableFormControls();
        }


        private void DisableFormControls()
        {
            AppHelpers.DisableOneOrMoreControls(button1, button2, button3, button4, comboBoxExchange, comboBoxType);
            unloadDatabaseToolStripMenuItem.Visible = false;
            databaseToolStripMenuItem1.Visible = true;
        }

        private void EnableFormControls()
        {
            AppHelpers.EnableOneOrMoreControls(button1, button2, button3, button4, comboBoxExchange, comboBoxType);
            unloadDatabaseToolStripMenuItem.Visible = true;
            databaseToolStripMenuItem1.Visible = false;
        }

        private void LoadInitialForm()
        {
            comboBoxExchange.SelectedItem = "All";
            comboBoxType.SelectedItem = "All";
            dataHandler.LoadDataIntoDataGridView(dataGridView1, "All", "All", lbDataCount);
        }


        private void SelectRowBySymbolName(string symbolName)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Name"].Value.ToString() == symbolName)
                {
                    row.Selected = true;
                    break;
                }
            }
        }


    }
}