using System;
using System.Collections.Generic;
using System.Text;

namespace BetEasy.Core.Models
{
    public class EventType
    {
        public int EventTypeID { get; set; }
        public string EventTypeDesc { get; set; }
        public int MasterEventTypeID { get; set; }
        public string Slug { get; set; }
    }

    public class VenueData
    {
        public string Venue { get; set; }
        public string StateCode { get; set; }
        public string Slug { get; set; }
    }

    public class Races
    {
        public int EventID { get; set; }
        public int MasterEventID { get; set; }
        public string EventName { get; set; }
        public string EventTypeDesc { get; set; }
        public string MasterEventName { get; set; }
        public DateTime AdvertisedStartTime { get; set; }
        public int RaceNumber { get; set; }
        public EventType EventType { get; set; }
        public VenueData Venue { get; set; }
        public bool IsMultiAllowed { get; set; }
        public string Slug { get; set; }
        public string DateSlug { get; set; }
        public bool RacingStreamAllowed { get; set; }
        public bool RacingReplayStreamAllowed { get; set; }
    }

    public class NextJump
    {
        public List<Races> result { get; set; }
        public bool success { get; set; }
    }
}
