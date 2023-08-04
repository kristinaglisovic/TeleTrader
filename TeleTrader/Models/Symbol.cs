namespace TeleTrader.Models
{
    public class Symbol
    {
        public string? OriginalSymbolName { get; set; }
        public string? Ticker { get; set; }

        public string? Isin { get; set; }

        public string? CurrencyCode { get; set; }

        public double Price { get; set; }
        public DateTime PriceDate { get; set; }
        public DateTime DateAdded { get; set; }
        public string? ExName { get; set; }
        public string? TypeName { get; set; }

    }

    public class EditOrAddSymbol : Symbol
    {
        public string? NewSymbolName { get; set; }
    }

   
}
