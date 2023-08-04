using System.Data;
using System.Data.SQLite;
using TeleTrader.Models;

namespace TeleTrader.Extensions
{
    public class DataHandler
    {
        private string _connectionString;

        public DataHandler(string dbFilePath)
        {
            _connectionString = $"Data Source={dbFilePath};Version=3;";
        }

        // Metod za učitavanje podataka u DataGridView
        public void LoadDataIntoDataGridView(DataGridView dataGridView, string exchangeFilter, string typeFilter, Label l)
        {
            IsConnStringSet();

            // Kreiranje SQL WHERE klauzule za filtriranje
            string whereClause = string.Empty;
            if (exchangeFilter != "All")
            {
                whereClause += $" AND e.Name = '{exchangeFilter}'";
            }
            if (typeFilter != "All")
            {
                whereClause += $" AND t.Name = '{typeFilter}'";
            }

            // Upit za selektovanje podataka iz baze sa primenjenim filtriranjem
            // WHERE 1 predstavlja uslov koji je uvek tačan, tj. vraća sve redove iz tabele bez filtriranja i daje mogućnost proširenja
            string query = $@"SELECT s.*, e.Name as ExchangeName, t.Name as TypeName
                      FROM Symbol s
                      JOIN Exchange e ON s.ExchangeId=e.Id
                      JOIN Type t ON s.TypeId=t.Id
                      WHERE 1 {whereClause}";

            DataTable table = new DataTable();

            // Otvaranje SQLite konekcije i automatsko zatvaranje nakon završetka rada (korišćenjem using bloka)
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    // Popunjavanje DataTable-a sa podacima iz baze
                    adapter.Fill(table);
                }
            }

            dataGridView.DataSource = table;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;

            // Skrivanje kolona
            AppHelpers.HideDataGridViewColumns(dataGridView, "DateAdded","Id","Isin", "CurrencyCode","PriceDate","TypeId","ExchangeId");
         

            // Label za broj redova
            l.Text = $"Data Count: {dataGridView.Rows.Count}";

        }



        // Metoda za popunjavanje ComboBox-ova SymbolType i Exchange sa/bez opcije "All" na početku
        public void LoadDataIntoComboBox(ComboBox comboBox, string columnName, string tableName, bool addAllOption)
        {
            IsConnStringSet();

            // Upit za selektovanje jedinstvenih vrednosti iz baze
            string query = $"SELECT DISTINCT {columnName} FROM {tableName}";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Izvršavanje upita nad bazom podataka
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Popunjavanje ComboBox-a sa podacima iz baze
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader[columnName].ToString());
                    }
                }
            }
            if (addAllOption)
            {
                // Dodavanje "All" opcije na prvo mesto u ComboBox-u i setovanje filtera na "All"
                comboBox.Items.Insert(0, "All");
                comboBox.SelectedIndex = 0;
            }
        }

        // Metod za EditSymbol
        public void EditSymbol(EditOrAddSymbol symbol)
        {
            IsConnStringSet();

            // Construct the SQL query to update the row in the Symbol table
            string query = $@"
                UPDATE Symbol
                SET
                    Name=@NewSymbolName,
                    Ticker = @Ticker,
                    Isin=@Isin,
                    CurrencyCode=@CurrencyCode,
                    Price = @Price,
                    PriceDate=@PriceDate,
                    ExchangeId = (SELECT Id FROM Exchange WHERE Name = @ExName),
                    TypeId = (SELECT Id FROM Type WHERE Name = @TypeName)
                WHERE Name = @OriginalSymbolName";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NewSymbolName", symbol.NewSymbolName);
                command.Parameters.AddWithValue("@Ticker", symbol.Ticker);
                command.Parameters.AddWithValue("@Isin", symbol.Isin);
                command.Parameters.AddWithValue("@CurrencyCode", symbol.CurrencyCode);
                command.Parameters.AddWithValue("@Price", symbol.Price);
                command.Parameters.AddWithValue("@PriceDate", symbol.PriceDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ExName", symbol.ExName);
                command.Parameters.AddWithValue("@TypeName", symbol.TypeName);
                command.Parameters.AddWithValue("@OriginalSymbolName", symbol.OriginalSymbolName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Delete Symbol
        public void DeleteSymbol(string symbolName)
        {
            IsConnStringSet();

            string query = "DELETE FROM Symbol WHERE Name = @SymbolName";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SymbolName", symbolName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Provera da li je connectionString postavljen
        private void IsConnStringSet()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Connection string is not set.");
            }
        }
    }
}
