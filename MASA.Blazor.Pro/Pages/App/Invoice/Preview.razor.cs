namespace MASA.Blazor.Pro.Pages.App.Invoice
{
    public partial class Preview
    {
        private bool _showSendInvoice;
        private bool _showAddPayment;
        private InvoiceRecordDto? _invoiceRecord;

        public override string Name { get; } = "invoice_preview";

        [Parameter]
        public int? Id { get; set; }

        public InvoiceRecordDto InvoiceRecord => _invoiceRecord ??= InvoiceService.GetInvoiceRecordList().FirstOrDefault(i => i.Id == Id) ?? InvoiceService.GetInvoiceRecordList().First();

        private void NavigateToEdit()
        {
            NavigationManager.NavigateTo($"apps/invoice/edit/{Id ?? 0}");
        }
    }
}
