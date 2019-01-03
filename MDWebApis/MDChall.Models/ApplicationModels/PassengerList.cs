using System;
using System.Collections.Generic;
using System.Text;

namespace MDChall.Models.ApplicationModels
{
    public class PassengerList
    {
        private static Dictionary<String, List<String>> _passenger { get; set; }

        public PassengerList()
        {
            if (GetList() == null)
                _passenger = new Dictionary<string, List<string>>();
        }

        public Dictionary<String, List<String>> GetList()
        {
            return _passenger;
        }

        public void Set(Dictionary<String, List<String>> Passengers)
        {
            _passenger = Passengers;
        }

        public bool Add(PassengerRecord record)
        {
            var str = String.Format("{0}/{1}{2}", record.FirstName, record.LastName, record.Gender);
            try
            {
                var dict = GetList();
                var newList = new List<String>();
                if (dict.TryGetValue(record.Key, out newList))
                    newList.Add(str.ToUpperInvariant());
                else
                    dict.TryAdd(record.Key.ToUpperInvariant(), new List<String> { str.ToUpperInvariant() });
                Set(dict);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
