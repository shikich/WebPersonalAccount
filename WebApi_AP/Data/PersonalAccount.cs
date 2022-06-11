using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi_AP.Data
{

    [Table("PersonalAccount")]
    public partial class PersonalAccount
    {
        [Key]
        [Column("ID_Account")]
        public int IdAccount { get; set; }
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
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string Building { get; set; }
        [Required]
        [Column("Appartment_id")]
        [StringLength(50)]
        public string AppartmentId { get; set; }
        public double Square { get; set; }
        [Column("Date_open", TypeName = "date")]
        public DateTime? DateOpen { get; set; }
        [Column("Date_close", TypeName = "date")]
        public DateTime? DateClose { get; set; }
        [Column("ID_Group")]
        public int? IdGroup { get; set; }
    }
}
