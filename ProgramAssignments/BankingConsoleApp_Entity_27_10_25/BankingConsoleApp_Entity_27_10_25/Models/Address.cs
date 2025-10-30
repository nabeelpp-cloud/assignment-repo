using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp_Entity_27_10_25.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Street { get; set; }
        [Required,MaxLength(100)]
        public string City { get; set; }
        [Required,MinLength(100)]
        public string State { get; set; }
        [Required,MaxLength(100)]
        public string PostalCode { get; set; }
        [Required,MinLength(100)]
        public string Country { get; set; }
    }
}
