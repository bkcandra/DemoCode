using MDChall.Core;
using MDChall.Core.WebServices;
using MDChall.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MDChall.Core.Functions
{
    public class PassengerProcessor
    {
        private PassengerList pl = new PassengerList();

        public Dictionary<String, List<String>> ProcessPNL(List<String> NamePassengerList)
        {
            if (!NamePassengerList.Any())
                return null;

            var res = new Dictionary<String, List<String>>();
            foreach (var passenger in NamePassengerList)
            {
                var record = passenger.Trim();
                if (string.IsNullOrEmpty(record) || (record.FirstOrDefault() != '1'))
                    continue;

                var keyIndex = record.IndexOf(SystemConstants.RecordSeparator);
                if (keyIndex == -1)
                    continue;

                if ((keyIndex + SystemConstants.RecordSeparator.Length + SystemConstants.RecordLocatorLength) > record.Length)
                    continue;

                var passengerkey = record.Substring(keyIndex + SystemConstants.RecordSeparator.Length, SystemConstants.RecordLocatorLength);

                var separatorIndex = record.IndexOfAny(SystemConstants.nameSeparator);
                var passengerName = record.Substring(1, (separatorIndex - 1));


                var passengerList = new List<String>();

                if (res.TryGetValue(passengerkey, out passengerList))
                    passengerList.Add(passengerName);
                else
                {
                    passengerList = new List<String>();
                    passengerList.Add(passengerName);
                    res.Add(passengerkey, passengerList);
                }
                pl.Set(res);
            }
            return res;
        }

        public List<String> GetPNL()
        {
            var pasList = pl.GetList();
            var res = new List<String>();
            if (pasList == null && pasList.Count() == 0)
                return res;

            foreach (var list in pasList)
                foreach (var p in list.Value)
                    res.Add(String.Format("1{0} {1}{2}", p, SystemConstants.RecordSeparator, list.Key));
            return res;
        }

        public async Task<string> ExportToStringAsync(String query) {

            var pasList = await new PassengerSearch().SearchPNLAsync(query.Trim());

            if (pasList == null && pasList.Count() == 0)
                return null;

            var sb = new StringBuilder();
            foreach (var list in pasList)
                foreach (var p in list.Value)
                    sb.AppendFormat("1{0} {1}{2}{3}", p, SystemConstants.RecordSeparator, list.Key, Environment.NewLine);

            return sb.ToString();
        }
    }
}
