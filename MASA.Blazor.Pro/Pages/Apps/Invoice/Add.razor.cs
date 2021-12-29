namespace MASA.Blazor.Pro.Pages.Apps.Invoice
{
    public partial class Add : ProCompontentBase
    {
        private bool _showAddPayment;
        private string _invoiceTo = "";
        private readonly List<string> _invoices = new()
        {
            "Hall-Robbins PLC",
            " Mccann LLC and Sons",
            "Leonard-Garcia and Sons",
            "Smith, Miller and Henry LLC",
            "Garcia-Cameron and Sons"
        };
        private string _payment = "";
        private List<string> _payments = new()
        {
            "Bank Account","PayPal","UPI Transfer"
        };
        private readonly List<int> _taxs = new()
        {
            0,1,10,14,18
        };
        private List<Bill> _bills = new ()
        {
            new Bill()
        };
        private string _note = "It was a pleasure working with you and your team. We hope you will Favorite us in mind for future freelance projects. Thank You!";

        public override string Name { get; } = "Apps-Invoice";

        [Parameter]
        public int? Id { get; set; }

        public bool IsEdit => Id is not null;

        public InvoiceRecord InvoiceRecord = InvoiceService._invoiceRecords.First();

        public void OnBillChange(Bill oldValue, Bill newValue)
        {
            oldValue.Bind(newValue);
        }

        private static string ConvertText(int value)
        {
            return $"{value}%";
        }
    }
}
