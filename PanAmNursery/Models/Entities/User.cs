namespace PanAmNursery.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }
    }
}