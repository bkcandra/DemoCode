using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MDChall.Core
{
    public class SystemConstants
    {
        public static readonly int RecordLocatorLength = 6;

        public static readonly char[] nameSeparator = { '-', ' ' };

        public static readonly List<string> AcceptedExtensions = new List<string> { ".TXT" };

        public static readonly string MDAPIServer = "http://mdwapi.azurewebsites.net";

        public static readonly string MDApiPostProcessAddress = MDAPIServer + "/api/Passengerprocessor";
        public static readonly string MDApiListAddress = MDAPIServer + "/api/PassengerList";


        public static readonly string RecordSeparator = ".L/";

        public enum Gender
        {
            [Display(Name = "Male")]
            MR,
            [Display(Name = "Female")]
            MRS
        }



        public static List<String> GetTestPNL()
        {
            var npl = new List<String>();

            npl.Add("1ARNOLD/NIGELMR-B2 .L/LVGVUP");
            npl.Add(".R/TKNE HK1 9244501028078/1");
            npl.Add("1TAYLOR/HAYLEYMRS-B2 .L/LVGVUP");
            npl.Add("1CLIFFORD/DAVIDMR .L/LVKBCB");
            npl.Add(" ");
            npl.Add("null");
            npl.Add("1CLARKE/MICHAELMR-K2 .L/LVK6HA");
            npl.Add(".R/TKNE HK1 9244501213584/1");

            return npl;
        }

    }
}
