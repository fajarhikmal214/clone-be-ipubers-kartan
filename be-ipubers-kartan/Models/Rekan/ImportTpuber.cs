using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[PrimaryKey("IdRetailer", "Tahun", "Bulan", "ImportTo")]
[Table("_importTPubers")]
public partial class ImportTpuber
{
    [Key]
    [StringLength(12)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [Key]
    public int Tahun { get; set; }

    [Key]
    public int Bulan { get; set; }

    public int? RowsCount { get; set; }

    public int? Status { get; set; }

    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string ImportTo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
