namespace MASA.Blazor.Pro.Pages.Apps.Invoice
{
    public partial class Preview
    {
        private bool _showSendInvoice;
        private bool _showAddPayment;
        private InvoiceRecord? _invoiceRecord;

        public override string Name { get; } = "invoice_preview";

        [Parameter]
        public int? Id { get; set; }

        public InvoiceRecord InvoiceRecord => _invoiceRecord ??= InvoiceService._invoiceRecords.FirstOrDefault(i => i.Id == Id) ?? InvoiceService._invoiceRecords.First();

        private void NavigateToEdit()
        {
            NavigationManager.NavigateTo($"apps/invoice/edit/{Id ?? 0}");
        }
    }
}
