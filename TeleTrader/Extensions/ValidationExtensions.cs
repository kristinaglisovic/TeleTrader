namespace TeleTrader.Extensions
{
    public static class ValidationExtensions
    {
        // Metod za proveru ekstenzije selektovanog fajla
        public static bool IsValidDatabaseFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return (extension == ".sqlite" || extension == ".db3" || extension == ".s3db");
        }

        // Metod za validaciju polja formi
        public static bool AreFieldsValid(Label errorLabel, params Control[] controls)
        {
            bool isValid = true;

            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorLabel.Text = "All fields must be filled.";
                        isValid = false;
                        break;
                    }

                    if (textBox.Name == "textBoxPrice" && (!double.TryParse(textBox.Text, out double price) || price <= 0))
                    {
                        errorLabel.Text = "Price must be a valid number greater than 0.";
                        isValid = false;
                        break;
                    }
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    DateTime selectedDate = dateTimePicker.Value.Date;
                    DateTime currentDate = DateTime.Now.Date;
                    isValid = selectedDate <= currentDate;

                    errorLabel.Text = "Date can't be greater than today's date.";
                }
            }

            errorLabel.Visible = !isValid;
            return isValid;
        }
    }
}
