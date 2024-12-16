using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Protocol.Resources;

namespace Atlas.Data
{
    [Table("Artists", Schema = "Artist")]
    public class Artists
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArtistId { get; set; }
        public Guid ArtistGuid { get; set; } = Guid.NewGuid();
        [StringLength(100)] 
        public string ArtistName { get; set; } = "";
        public virtual ICollection<EventArtists> EventArtists { get; set; }
    }
}

