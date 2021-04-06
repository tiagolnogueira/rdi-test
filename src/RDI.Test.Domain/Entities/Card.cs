namespace RDI.Test.Domain.Entities
{
    public class Card : Entity
    {
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public Customer Customer { get; set; }
    }
}
