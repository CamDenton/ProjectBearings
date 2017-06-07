using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearingApp.Models
{
    public class MeebaInfo
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string itemName { get; set; }
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Polarity")]
        public string pull { get; set; }
        [Display(Name = "Appoint")]
        public int apptInt { get; set; }
        [Display(Name = "Work")]
        public int workInt { get; set; }
        [Display(Name = "Social")]
        public int socInt { get; set; }
        [Display(Name = "Event")]
        public int evtInt { get; set; }
        public int persInt { get; set; }
        public int otherInt { get; set; }
        public int innerInt { get; set; }
        public int OuterInt { get; set; }
    }
}