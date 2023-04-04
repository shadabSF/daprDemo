namespace ConsumerApi.DTO
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public double OrderAmount { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
