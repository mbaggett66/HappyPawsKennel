using System.ComponentModel.DataAnnotations;

namespace HappyPawsKennel.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Breed is required.")]
        [StringLength(50, ErrorMessage = "Breed cannot exceed 50 characters.")]
        public string Breed { get; set; }

        [Range(0, 25, ErrorMessage = "Age must be between 0 and 25.")]
        public int Age { get; set; }

        [Range(0.1, 200, ErrorMessage = "Please enter a valid weight.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Owner name is required.")]
        [Display(Name = "Owner Name")]
        [StringLength(100)]
        public string OwnerName { get; set; }

        // Relationship: A dog can be assigned to a kennel
        [Display(Name = "Kennel")]
        public int? KennelId { get; set; }
        public Kennel? Kennel { get; set; }
    }
}
