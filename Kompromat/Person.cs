using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kompromat
{
    public class Person
    {
        [Description("This is the First Name")]
        [DisplayName("ID")] 
        public int Id { get; set; }

        [Description("This is the First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Description("This is the First Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string University { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public string Bio { get; set; }


        public string LogInfo
        {
            get
            {
                return $"[{Id}] {LastName} {FirstName} {FatherName} ({Birthday.Day}-{Birthday.Month}-{Birthday.Year})";
            }
        }

        public string FullInfo
        {
            get
            {
                return $"{Id} {LastName} {FirstName} {FatherName} {Birthday.Day} {Birthday.Month} {Birthday.Year} \n {Email}  {University} {PhoneNumber} {Telegram}";

            }
        }
    }
}
