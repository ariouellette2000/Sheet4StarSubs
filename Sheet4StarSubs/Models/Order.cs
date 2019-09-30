using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sheet4StarSubs.Models
{
    public class Order
    {
        public SubType Sub { get; set; }
        public SizeType Size { get; set; }
        public MealType MealDeal { get; set; }
        
        //Start Sheet 5 
       public double Quantity { get; set; }
        //End Sheet 5
    }
        public enum SubType
        {
            //You have to put using System.ComponentModel.DataAnnotation
            [Display(Name = "The Inox")]
            TheInox,
            [Display(Name = "The Levante")]
            TheLevante,
            [Display(Name = "The Globetrotter")]
            TheGlobeTrotter,
            [Display(Name = "The North")]
            TheNorth,
            [Display(Name = "The Quest")]
            TheQuest,
            [Display(Name = "The Ignition")]
            TheIgnition,
            [Display(Name = "The Locarno")]
            TheLocarno
        }
        public enum SizeType
        {
            Kids,
            Small,
            Medium,
            Large
        }
        public enum MealType
        {
            None,
            DrinkAndChips,
            DrinkAndCookies
        }
    
}