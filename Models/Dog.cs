namespace HappyPawsKennel.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string OwnerName { get; set; }

        // Relationship: A dog can be assigned to a kennel
        public int? KennelId { get; set; }
        public Kennel? Kennel { get; set; }
    }
}
