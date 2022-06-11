#nullable disable

namespace WebClient_AP.Models.View
{
    public class PersonalAccount_GroupVM
    {
        //For List of PA
        public int IdAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string AppartmentId { get; set; }
        public double Square { get; set; }
        public DateTime? DateOpen { get; set; }
        public DateTime? DateClose { get; set; }
        public int? IdGroup { get; set; }
        public int Quantity { get; set; }
    }
}
