using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class SearchModel : PageModel
    {
        public static string SearchTerms;
        public static IEnumerable<IOrderItem> items;
        public static string[] OrderTypes { get; set; }
        public static int CaloriesMin;
        public static int CaloriesMax;
        public static double PriceMin;
        public static double PriceMax = 8.32;
        public void OnGet()
        {
            SearchTerms = Request.Query["SearchTerms"];
            OrderTypes = Request.Query["OrderTypes"];
            string CaloriesMinStr = Request.Query["CaloriesMin"];
            string CaloriesMaxStr = Request.Query["CaloriesMax"];
            
            if (CaloriesMinStr == null || CaloriesMinStr.Length == 0) CaloriesMin = 0;
            else CaloriesMin = Convert.ToInt32(CaloriesMinStr);
            
            if (CaloriesMaxStr == null || CaloriesMaxStr.Length == 0) CaloriesMax = 982;
            else CaloriesMax = Convert.ToInt32(CaloriesMaxStr);

            string PriceMinStr = Request.Query["PriceMin"];
            string PriceMaxStr = Request.Query["PriceMax"];

            if (PriceMinStr == null || PriceMinStr.Length == 0) PriceMin = 0;
            else PriceMin = Convert.ToDouble(PriceMinStr);

            if (PriceMaxStr == null || PriceMaxStr.Length == 0) PriceMax = 8.32;
            else PriceMax = Convert.ToDouble(PriceMaxStr);

            items = Menu.FullMenu();

            List<Type> types = new List<Type>();
            foreach(string type in OrderTypes)
            {
                switch (type)
                {
                    case "Entrees":
                        types.Add(typeof(Entree));
                        break;
                    case "Sides":
                        types.Add(typeof(Side));
                        break;
                    case "Drinks":
                        types.Add(typeof(Drink));
                        break;
                }//end switch case
            }//end foreach loop

            items = Menu.Search(items, SearchTerms);
            items = Menu.FilterByOrderType(items, types);
            items = Menu.FilterByCalories(items, CaloriesMin, CaloriesMax);
            items = Menu.FilterByPrice(items, PriceMin, PriceMax);
        }//end OnGet()
    }//end class
}//end namespace