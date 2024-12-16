using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.DTO;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;

namespace Atlas.Data
{
    [Table("Events", Schema = "Event")]
    public class Events
    {
        public Events()
        {
            
        }
        public Events(EventDTO eventDto) : this()
        {
            EventArtist = eventDto.EventArtist;
            EventDate = DateTime.Parse(eventDto.EventDate);
            EventLink = eventDto.EventLink;
            EventTime = eventDto.EventTime;
            EventImgSrc = eventDto.EventImgSrc;
            VenueId = eventDto.EventVenue switch
            {
                "The Signal" => 1,
                "Soldiers and Sailors Memorial Auditorium" => 2,
                "The Walker Theatre" => 3,
                "The Tivoli Theatre" => 4,
                _ => 0
            };
        }
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EventId { get; set; }

        public string? EventArtist { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventTime { get; set; }
        public string? EventLink { get; set; }
        public string? EventImgSrc { get; set; }
        public int? VenueId { get; set; }
        
        [ForeignKey("VenueId")]
        public virtual Venues Venue { get; set; }
        public virtual ICollection<EventArtists> EventArtists { get; set; }
        
    }
}

