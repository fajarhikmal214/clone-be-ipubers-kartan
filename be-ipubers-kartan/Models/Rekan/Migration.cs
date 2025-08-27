using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("migrations")]
public partial class Migration
{
    [Key]
    [Column("id")]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;
}
