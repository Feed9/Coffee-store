namespace Coffee_store.Models
{
    enum OrderStatus
    {
        Created,
        Confirmed,
        AwaitingPayment,
        PaymentError,
        PaymentСonfirmed,
        AwaitingCancellationConfirmation,
        CancellationDecline,
        Cancelled,
        InProgress,
        InDelivery,
        Delivired,
        Done
    }
}
