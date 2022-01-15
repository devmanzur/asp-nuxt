using SimpleCart.Core.Interfaces;

namespace SimpleCart.Core.Models.Orders;

public class Order : BaseEntity
{
    private Order()
    {
    }

    public Order(Customer customer, List<OrderItem> items, PaymentType paymentType = PaymentType.CashOnDelivery,
        PaymentStatus paymentStatus = PaymentStatus.Due)
    {
        this._items = items;
        this.Customer = customer;
        this.PaymentType = paymentType;
        this.PaymentStatus = paymentStatus;
        this.Status = OrderStatus.OrderPlaced;
        this.DeliveryDate = DateTime.UtcNow.AddDays(7).Date;
        this.TrackingId = Guid.NewGuid().ToString("N");
        this.TotalAmount = _items.Select(x => x.TotalPrice).Sum();
        this.Vat = TotalAmount * (decimal)0.15;
        this.DeliveryCharge = 50;
        this.Discount = TotalAmount * (decimal)-0.05;
        this.PayableAmount = TotalAmount + Vat + DeliveryCharge + Discount;
    }

    public string TrackingId { get; private set; }
    public PaymentType PaymentType { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime DeliveryDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Vat { get; private set; }
    public decimal DeliveryCharge { get; private set; }
    public decimal Discount { get; private set; }
    public decimal PayableAmount { get; private set; }
    public Customer Customer { get; private set; }
    private readonly List<OrderItem> _items = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
}