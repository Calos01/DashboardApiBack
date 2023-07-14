namespace DashboardApiBack.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int Amount { get; set; }
        public DateTime PedRealizado { get; set; }
        public DateTime? PedCompletado { get; set; }
        public string Status { get; set; }
        public int? Total { get; set;}

    }
}
