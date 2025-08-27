using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("metadata")]
public partial class Metadata
{
    [Key]
    [Column("id")]
    [StringLength(255)]
    public string Id { get; set; } = null!;

    [Column("value", TypeName = "text")]
    public string? Value { get; set; }
}
