using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi_AP.Data
{
    [Table("Person")]
    public partial class Person
    {
        [Key]
        [Column("ID_Person")]
        public int IdPerson { get; set; }
        [Required]
        [Column("First_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("Middle_name")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Column("Date_since", TypeName = "date")]
        public DateTime? DateSince { get; set; }
        [Column("Date_to", TypeName = "date")]
        public DateTime? DateTo { get; set; }
    }
}
