using System.Globalization;
using TeleTrader.Extensions;
using TeleTrader.Models;

namespace TeleTrader.Forms
{
    public partial class SymbolForm : Form
    {
        private Symbol _symbol;

        private FormMode _mode;

        public EditOrAddSymbol ModifiedSymbol { get; set; }


        // View/Edit konstruktor
        public SymbolForm(FormMode mode, Symbol symbol)
        {
            InitializeComponent();
            InitializeForm(mode, symbol);
        }

        //Add konstruktor
        private void InitializeForm(FormMode mode, Symbol symbol)
        {
            _mode = mode;
            _symbol = symbol;

            SetFormValues(symbol);
            AddEventHandlers();
            UpdateSaveButtonState();
        }


        private void AddEventHandlers()
        {
            textBoxSyName.TextChanged += HandleFormValueChanged;
            textBoxTicker.TextChanged += HandleFormValueChanged;
            textBoxIsin.TextChanged += HandleFormValueChanged;
            textBoxCurrency.TextChanged += HandleFormValueChanged;
            textBoxPrice.TextChanged += HandleFormValueChanged;
            dateTimePickerPriceDate.TextChanged += HandleFormValueChanged;
            comboBoxExch.TextChanged += HandleFormValueChanged;
            comboBoxType.TextChanged += HandleFormValueChanged;
        }

        private void SetFormValues(Symbol symbol)
        {
            this.Text = _mode+" Symbol";
            textBoxSyName.Text = symbol != null ? symbol.OriginalSymbolName : "";
            textBoxTicker.Text = symbol != null ? symbol.Ticker : "";
            textBoxIsin.Text = symbol != null ? symbol.Isin : "";
            textBoxCurrency.Text = symbol != null ? symbol.CurrencyCode : "";
            textBoxPrice.Text = symbol != null ? symbol.Price.ToString() : "";
            textBoxDateAdded.Text = symbol.DateAdded.ToString("dd.MM.yyyy");
            dateTimePickerPriceDate.Value = symbol.PriceDate;

            comboBoxExch.Items.AddRange(SharedData.ComboBoxExchangeItems.Skip(1).ToArray());
            comboBoxType.Items.AddRange(SharedData.ComboBoxTypeItems.Skip(1).ToArray());

            int exchIndex = symbol != null ? comboBoxExch.FindStringExact(symbol.ExName) : -1;
            int typeIndex = symbol != null ? comboBoxType.FindStringExact(symbol.TypeName) : -1;

            comboBoxExch.SelectedIndex = exchIndex != -1 ? exchIndex : 0;
            comboBoxType.SelectedIndex = typeIndex != -1 ? typeIndex : 0;

            switch (_mode)
            {
                case FormMode.Add:
                    labelMode.Text = "Add Symbol";
                    break;
                case FormMode.ViewOrEdit:
                    labelMode.Text = "View/Edit Symbol";
                    break;
            }
        }

        private bool IsFormChanged()
        {
            return textBoxSyName.Text != _symbol.OriginalSymbolName ||
                   textBoxTicker.Text != _symbol.Ticker ||
                   textBoxIsin.Text != _symbol.Isin ||
                   dateTimePickerPriceDate.Value != _symbol.PriceDate ||
                   textBoxCurrency.Text != _symbol.CurrencyCode ||
                   textBoxPrice.Text != _symbol.Price.ToString() ||
                   comboBoxExch.SelectedItem?.ToString() != _symbol.ExName ||
                   comboBoxType.SelectedItem?.ToString() != _symbol.TypeName;
        }

        private void HandleFormValueChanged(object? sender, EventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool isFormChanged = IsFormChanged();
            bool areFieldsValid = ValidationExtensions.AreFieldsValid(labelError, textBoxSyName, textBoxTicker, textBoxIsin, textBoxCurrency, textBoxPrice,dateTimePickerPriceDate);

            btnSave.Enabled = isFormChanged && areFieldsValid ;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case FormMode.Add:
                    ModifiedSymbol = new EditOrAddSymbol
                    {
                        NewSymbolName = textBoxSyName.Text,
                        Ticker = textBoxTicker.Text,
                        Price = double.Parse(textBoxPrice.Text),
                        ExName = comboBoxExch.SelectedItem?.ToString(),
                        TypeName = comboBoxType.SelectedItem?.ToString(),
                    };
                    break;
                case FormMode.ViewOrEdit:

                    ModifiedSymbol = new EditOrAddSymbol
                    {
                        OriginalSymbolName = _symbol.OriginalSymbolName,
                        NewSymbolName = textBoxSyName.Text,
                        Ticker = textBoxTicker.Text,
                        Isin=textBoxIsin.Text,
                        CurrencyCode=textBoxCurrency.Text,
                        Price = double.Parse(textBoxPrice.Text),
                        PriceDate= dateTimePickerPriceDate.Value,
                        ExName = comboBoxExch.SelectedItem?.ToString(),
                        TypeName = comboBoxType.SelectedItem?.ToString(),
                    };
                   
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
            }
        }
    }
}
