using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;

namespace BrisXmasTechDrinks2015Rsvps
{   
    public class RsvpsController : ApiController
    {              
        [HttpGet]
        public async Task<object> Get(string eventIds = null)
        {
            // override key here if running locally
            var apiKey = Data.ApiKey;
            
            var eventIdsString = eventIds ?? String.Join(",", Data.EventIds);
            var url = $"https://api.meetup.com/2/rsvps?key={apiKey}&event_id={eventIdsString}&order=name";
            
            var results = await GetFullApiResponse(url);
            
            // by event
            var includedEvents =
                results
                    .GroupBy(r => r.group.id)
                    .Select(r => 
                        new {
                                Group = r.First().group.urlname,
                                EventId = r.First().@event.id,
                                EventUrl = r.First().@event.event_url, 
                                YesCount = r.Count() 
                            })
                    .OrderByDescending(g => g.YesCount);
            
            // by person
            var yesResponses = 
                results
                    .Where(r => r.response == "yes")
                    .GroupBy(r => r.member.member_id)
                    .Select(m => 
                        new { 
                                Name = m.First().member.name,  
                                RsvpdIn = $"[ {String.Join("; ", m.Select(r=> r.group.urlname))} ]"
                            })
                    .OrderBy(m => m.Name)
                    .ToList();

            // for output
            return
                 new
                 {
                     EventIds = eventIdsString,
                     UniqueYesRSVPCount = yesResponses.Count,
                     ByGroup = includedEvents,
                     Names = yesResponses
                 };
                
        }
        
        // page through the api to retrieve all rsvps
        private async Task<List<Result>> GetFullApiResponse(string url)
        {
            var results = new List<Result>(); 
            
            do
            {
                var response = JsonConvert.DeserializeObject<RsvpApiResult>(await new HttpClient().GetStringAsync(url));
                results.AddRange(response.results);        
        
                url = response.meta.next;        
            } while (!String.IsNullOrEmpty(url));
            
            return results;
        }
        
    }
}
