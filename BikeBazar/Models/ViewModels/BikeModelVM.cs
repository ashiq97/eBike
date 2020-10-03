using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeBazar.Models.ViewModels
{
    public class BikeModelVM
    {
        public BikeModel BikeModel { get; set; }
        public IEnumerable<Make> Makes { get; set; }

        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Make> Items)
        {
            var makeList = new List<SelectListItem>();

            var sli = new SelectListItem
            {
                Text = "--------Select-----",
                Value = "0"
            };
            makeList.Add(sli);
            if (Items.ToList().Count != 0)
            {
                foreach (Make make in Items)
                {
                    sli = new SelectListItem
                    {
                        Text = make.Name,
                        Value = make.Id.ToString()
                    };
                makeList.Add(sli);
                }
            }
            return makeList;
        }
    }
}
