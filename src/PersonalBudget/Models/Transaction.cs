using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalBudget.Data;
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
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public String Category { get; set; }

        public String Description { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any transaction.
                if (context.Transaction.Any())
                {
                    return;   // DB has been seeded
                }

                context.Transaction.AddRange(
                     new Transaction
                     {
                         Value = -50,
                         Date = DateTime.Parse("10-11-2016"),
                         Category = "Comida",
                         Description = "Mercadona"
                     },
                     new Transaction
                     {
                         Value = -50,
                         Date = DateTime.Parse("25-10-2016"),
                         Category = "Gasolina",
                         Description = "Shell Paterna"
                     },
                     new Transaction
                     {
                         Value = -30,
                         Date = DateTime.Parse("5-11-2016"),
                         Category = "Luz",
                         Description = "Recibo Octubre"
                     },
                     new Transaction
                     {
                         Value = 1000,
                         Date = DateTime.Parse("13-11-2016"),
                         Category = "Nomina",
                         Description = "Nomina octubre"
                     },
                     new Transaction
                     {
                         Value = -10,
                         Date = DateTime.Parse("3-11-2016"),
                         Category = "Comida",
                         Description = "Restaurante fuente del jarro"
                     },
                     new Transaction
                     {
                         Value = -50,
                         Date = DateTime.Parse("5-11-2016"),
                         Category = "Cajera",
                         Description = "Retirada efectivo Santander"
                     },
                     new Transaction
                     {
                         Value = -30,
                         Date = DateTime.Parse("24-10-2016"),
                         Category = "Gas",
                         Description = "Recibo Septiembre"
                     },
                     new Transaction
                     {
                         Value = -25,
                         Date = DateTime.Parse("3-11-2016"),
                         Category = "Agua",
                         Description = "Recibo Octubre"
                     },
                     new Transaction
                     {
                         Value = -35,
                         Date = DateTime.Parse("5-11-2016"),
                         Category = "Internet",
                         Description = "Recibo Octubre"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
