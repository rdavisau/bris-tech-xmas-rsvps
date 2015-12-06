using System.Collections.Generic;

namespace BrisXmasTechDrinks2015Rsvps
{
    public class RsvpApiResult
    {
        public List<Result> results { get; set; }
        public Meta meta { get; set; }
    }
    
    public class Venue
    {
        public string country { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string address_1 { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public int id { get; set; }
        public double lat { get; set; }
        public bool repinned { get; set; }
    }
    
    public class MemberPhoto
    {
        public int photo_id { get; set; }
        public string photo_link { get; set; }
        public string thumb_link { get; set; }
        public string highres_link { get; set; }
    }
    
    public class Member
    {
        public int member_id { get; set; }
        public string name { get; set; }
    }
    
    public class Event
    {
        public string name { get; set; }
        public string id { get; set; }
        public object time { get; set; }
        public string event_url { get; set; }
    }
    
    public class Group
    {
        public string join_mode { get; set; }
        public object created { get; set; }
        public double group_lon { get; set; }
        public int id { get; set; }
        public string urlname { get; set; }
        public double group_lat { get; set; }
    }
    
    public class Result
    {
        public Venue venue { get; set; }
        public object created { get; set; }
        public string response { get; set; }
        public MemberPhoto member_photo { get; set; }
        public int guests { get; set; }
        public Member member { get; set; }
        public int rsvp_id { get; set; }
        public object mtime { get; set; }
        public Event @event { get; set; }
        public Group group { get; set; }
    }
    
    public class Meta
    {
        public string next { get; set; }
        public string method { get; set; }
        public int total_count { get; set; }
        public string link { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string lon { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public long updated { get; set; }
        public string lat { get; set; }
    }
}