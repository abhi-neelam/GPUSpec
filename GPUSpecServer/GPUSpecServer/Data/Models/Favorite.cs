using System.ComponentModel.DataAnnotations.Schema;

namespace GPUSpecServer.Data.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public int ListingId { get; set; }
        public Listing? Listing { get; set; }
    }
}
