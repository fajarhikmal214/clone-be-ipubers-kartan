using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("BsiUploadSettlement")]
public partial class BsiUploadSettlement
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string FileName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UploadedAt { get; set; }

    public short Status { get; set; }
}
