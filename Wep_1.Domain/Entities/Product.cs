namespace Wep_1.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
