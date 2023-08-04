namespace TeleTrader.Extensions
{
    public static class AppHelpers
    {
        // Metod za omogućavanje više dugmadi
        public static void EnableOneOrMoreControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = true;
            }
        }


        // Metod za onemogućavanje dugmadi
        public static void DisableOneOrMoreControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }

        // Metod za skrivanje kolona iz DataViewGrid-a
        public static void HideDataGridViewColumns(DataGridView dataGridView, params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].Visible = false;
                }
            }
        }

    }
}
