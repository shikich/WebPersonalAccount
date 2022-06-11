using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi_AP.Data
{
    [Keyless]
    [Table("OneGroup")]
    public partial class OneGroup
    {
        [Column("ID_Group")]
        public int IdGroup { get; set; }
        [Column("ID_Person")]
        public int IdPerson { get; set; }
    }
}
