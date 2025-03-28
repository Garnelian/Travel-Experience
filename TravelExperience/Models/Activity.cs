using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelExperience.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        [JsonIgnore]
        public int TripId { get; set; }  

        [Required(ErrorMessage = "DestinationId is required.")]
        public int DestinationId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 day.")]
        public int Duration { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be greater than 0.")]
        public decimal Cost { get; set; }
        [JsonIgnore]
        public Trip Trip { get; set; }
    }
}
