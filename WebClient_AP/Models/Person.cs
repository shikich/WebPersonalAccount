using System;

#nullable disable

namespace WebClient_AP.Models
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateSince { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
