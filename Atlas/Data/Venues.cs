using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Atlas.Data
{
    [Table("Venues", Schema = "Venue")]
    public class Venues
    {
        public enum EventVenues
        {
            // [Display(Name = "The Signal")]
            // TheSignal = 1,
            //             
            // [Display(Name = "Soldiers and Sailors Memorial Auditorium")]
            // MemorialAuditorium, 
            //             
            // [Display(Name = "The Walker Theatre")]
            // TheWalker, 
            //             
            // [Display(Name = "The Tivoli Theatre")]
            // TheTivoli 
            
            
            
            
            [EnumMember(Value = "The Signal")]
            TheSignal,
                        
            [EnumMember(Value = "Soldiers and Sailors Memorial Auditorium")]
            MemorialAuditorium, 
                        
            [EnumMember(Value = "The Walker Theatre")]
            TheWalker, 
                        
            [EnumMember(Value = "The Tivoli Theatre")]
            TheTivoli 
            
        }
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VenueId { get; set; }
        public Guid VenueGuid { get; set; } = Guid.NewGuid();
        [StringLength(100)] 
        public string VenueName { get; set; } = "";
        
        public virtual ICollection<Events>? Events { get; set; }
    }
}

