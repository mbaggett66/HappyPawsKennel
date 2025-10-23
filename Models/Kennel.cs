using System.Collections.Generic;

namespace HappyPawsKennel.Models
{
    public class Kennel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Size { get; set; }

        // Whether a kennel is occupied will depend on assigned dogs
        public bool IsOccupied => Dogs != null && Dogs.Any();

        // Relationship: One kennel can have many dogs
        public List<Dog> Dogs { get; set; } = new();
    }
}
