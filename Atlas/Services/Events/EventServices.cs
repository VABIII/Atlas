using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Serialization;
using Atlas.Data;
using Atlas.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;


namespace Atlas.Services.Events
{
    public class EventServices(X23DbContext context) : IEventServices
    {
        private static EventsListDTO ReadDummyData()
        {
            EventsListDTO eventsList;
            
            using(StreamReader sr = new StreamReader(@"C:\Users\Trey\Desktop\Weapon-X\Atlas\Atlas\Services\Events\TestData.txt"))
            {
                 eventsList = JsonConvert.DeserializeObject<EventsListDTO>(sr.ReadToEnd());
            }

            return eventsList;

        }
        
        public async Task<List<Venues>>GetEvents()
        {
            SortEventsByVenue();

            // var x = nameof(EventVenueNames.TheSignal);
            // var y = Enum.GetName(typeof(FunkyAttributesEnum), value);
            var events = ReadDummyData();

            var sortedEvents = events.EventsList
                .Select(x => new Data.Events
                {
                    EventArtist = x.EventArtist,
                    EventDate = DateTime.Parse(x.EventDate),
                    EventLink = x.EventLink,
                    EventTime = x.EventTime,
                    VenueId = x.EventVenue switch
                    {
                        "The Signal" => 1,
                        "Soldiers and Sailors Memorial Auditorium" => 2,
                        "The Walker Theatre" => 3,
                        "The Tivoli Theatre" => 4,
                        _ => 0
                        
                    },
                })
                .ToList();

            context.Add(sortedEvents);
            await context.SaveChangesAsync();
            
            
            
            
            var venues = await context.Venues.ToListAsync();
            return venues;
        }

        private void GetVenueName(string venueName)
        {
            int venueId;
            switch (venueName)
            {
                case "The Signal":
                    // return 1;
                    break;
                
            }
        }

        public void SortEventsByVenue()
        {
            var enumType = typeof(Venues.EventVenues);
            
            
            
            var enumValues = System.Enum.GetValues(typeof(Venues.EventVenues));
            var x = enumValues.GetValue(2);
            var y = Enum.GetName(typeof(Venues.EventVenues), x);



            // return new (object)object();
        }
    }
    
}

