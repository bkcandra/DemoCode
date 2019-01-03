using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Challenge.Core.Constants
{

    public class SystemConstants
    {
        public static string AGLJsonUri = "http://agl-developer-test.azurewebsites.net/people.json";

        /// <summary>
        /// We can separate or combine filter & sorting options, in this case we separate 
        /// </summary>
        public enum PetsFilter
        {
            [Display(Name = "Filter by Cat")]
            cat ,
            [Display(Name = "Filter by Dog")]
            dog ,
            [Display(Name = "Filter by Fish")]
            fish
        }

        public enum PetsSorting
        {
            [Display(Name = "Sort by name")]
            name ,
            [Display(Name = "Sort by type")]
            type 
        }
    }
}
