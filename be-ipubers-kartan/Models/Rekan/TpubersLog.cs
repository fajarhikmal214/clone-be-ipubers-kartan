using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("TpubersLog")]
public partial class TpubersLog
{
    [Key]
    [StringLength(36)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    public int? Tahun { get; set; }

    public int? Bulan { get; set; }

    public int? ProvinsiId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ProvinsiName { get; set; }

    public int? KabupatenIndex { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KabupatenName { get; set; }

    public int? KecamatanIndex { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KecamatanName { get; set; }

    public int? JumlahData { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public bool? IsCompleted { get; set; }

    [Unicode(false)]
    public string? ExceptionMessage { get; set; }
}
