using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Atlas.DTO
{
// EventsListDTO myDeserializedClass = JsonConvert.DeserializeObject<EventsListDTO>(myJsonResponse);
    public class EventDTO
    {
        // [JsonPropertyName("EventVenue")]
        public string EventVenue { get; set; }

        // [JsonPropertyName("EventArtist")]
        public string EventArtist { get; set; }

        // [JsonPropertyName("EventDate")]
        public string EventDate { get; set; }

        // [JsonPropertyName("EventLink")]
        public string EventLink { get; set; }

        // [JsonPropertyName("EventTime")]
        public string EventTime { get; set; }
        // [JsonPropertyName("EventImgSrc")]
        public string EventImgSrc { get; set; }
    }
    
    public class EventsListDTO
    {
        // [JsonProperty(nameof(EventsList))]
        public List<EventDTO> EventsList { get; set; } 
    }
    
    public class EventArtistsDto
    {
        public int? EventArtistId { get; set; }
        public int? EventId { get; set; }
        public int? ArtistId { get; set; }
        public string? Event { get; set; }
        public ICollection<ArtistsDto> ArtistsDtos { get; set; }
    
    }
    
    public class ArtistsDto
    {
        public int? ArtistId { get; set; }
        public Guid? ArtistGuid { get; set; }
        [StringLength(100)] 
        public string? ArtistName { get; set; }
        public ICollection<string>? eventArtists { get; set; }
    }
    
    public class VenueDto
    {
        public int? VenueId { get; set; }
        public Guid? VenueGuid { get; set; }
        [StringLength(100)] 
        public string? VenueName { get; set; }
        public ICollection<string>? Events { get; set; }
    }
}

