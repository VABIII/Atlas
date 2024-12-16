using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atlas.Data
{
    [Table("EventArtists", Schema = "Event")]
    public class EventArtists
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EventArtistId { get; set; }
        public int? EventId { get; set; }
        public int? ArtistId { get; set; }
        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artists Artists { get; set; }
    }
}

