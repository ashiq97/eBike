using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeBazar.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items) 
        {
            var ItemList = new List<SelectListItem>();

            var sli = new SelectListItem
            {
                Text = "--------Select-----",
                Value = "0"
            };
            ItemList.Add(sli);
            if (Items.ToList().Count != 0)
            {
                foreach (var item in Items)
                {
                    sli = new SelectListItem
                    {
                        //Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                        //Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString()
                        Text = item.GetPropertyValue("Name"),
                        Value = item.GetPropertyValue("Id")
                    };
                    ItemList.Add(sli);
                }
            }
            return ItemList;
        }
    }
}
