using System.ComponentModel.DataAnnotations;
using TravelExperience.Models.Validations;


namespace TravelExperience.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required.")]
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate.")]
        public DateTime EndDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "TotalCost must be a positive number.")]
        public decimal TotalCost { get; set; }

        [MinLength(1, ErrorMessage = "At least one activity is required.")]
        public virtual List<Activity> Activities { get; set; } = new();
    }
}
