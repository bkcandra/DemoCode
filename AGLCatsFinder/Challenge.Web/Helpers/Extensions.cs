using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Challenge.Web.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Convert Enum to Collection/Ienumerable of Text and Value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumObj"></param>
        /// <returns>Ienumerable[String Text,String Value]</returns>
        public static IEnumerable ToIEnum<T>(this T enumObj)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            List<SelectListItem> values = new List<SelectListItem>();
            foreach (var eItem in Enum.GetValues(typeof(T)))
            {
                DisplayAttribute attribute = eItem.GetType()
           .GetField(eItem.ToString())
           .GetCustomAttributes(typeof(DisplayAttribute), false)
           .SingleOrDefault() as DisplayAttribute;

                values.Add(new SelectListItem()
                {
                    Text = (attribute != null && !string.IsNullOrEmpty(attribute.Name)) ? attribute.Name : eItem.ToString(),
                    Value = (eItem).ToString()
                });
            }

            return values;

        }
    }
}
