using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBudget.Models
{
    public class Transaction
    {
        public int ID { get; set; }

        [Required]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public Decimal Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public String Category { get; set; }

        public String Description { get; set; }
    }
}
