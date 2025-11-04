using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp_Entity_27_10_25.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string FullName {  get; set; }
        [Required,MaxLength(256)]
        public string Email {  get; set; }
        public  string PhoneNumber {  get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public ICollection<Account> Accounts { get; set; }=new List<Account>();
        public int AddressId {  get; set; }

        public Address Address { get; set; }

    }
}
