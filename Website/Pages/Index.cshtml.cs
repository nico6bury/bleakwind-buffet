using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }//end constructor

        public void OnGet()
        {

        }//end OnGet()

        /// <summary>
        /// Builds the string that is displayed
        /// </summary>
        /// <param name="item">the item that you want displayed</param>
        /// <returns>returns string to display</returns>
        public static string BuildString(IOrderItem item)
        {
            StringBuilder sb = new StringBuilder();
            //name of item, price, and calories
            string name = item.GetType().Name;

            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                if (pi.Name.ToLower() == "size")
                {
                    dynamic dynamicItem = item;
                    sb.Append($"{dynamicItem.Size}");
                }//end if this property is the size property
            }//end looping foreach property in the item's type

            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                if (pi.Name.ToLower() == "flavor")
                {
                    dynamic dynamicItem = item;
                    sb.Append($" {dynamicItem.Flavor}");
                }//end if this property is the flavor property
            }//end looping foreach property in the item's type

            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                if (pi.Name.ToLower() == "decaf")
                {
                    dynamic dynamicItem = item;
                    if(dynamicItem.Decaf = true)
                    {
                        sb.Append($" Decaf");
                    }//end if the item is decafinated
                }//end if this property is the flavor property
            }//end looping foreach property in the item's type

            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsUpper(name[i]) && sb.Length != 0) sb.Append(" ");
                sb.Append(name[i]);
            }//end looping for each character in name

            sb.Append(": ");
            sb.Append(item.Description);
            sb.Append("\t");
            sb.Append(item.Calories);
            sb.Append(" Cals\t");
            sb.Append(item.Price.ToString("C2"));
            return sb.ToString();
        }//end BuildString(item, hasSizeProperty)
    }//end class
}//end namespace