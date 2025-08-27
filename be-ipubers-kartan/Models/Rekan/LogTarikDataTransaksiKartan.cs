using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("LogTarikDataTransaksiKartan")]
public partial class LogTarikDataTransaksiKartan
{
    [Key]
    public int Id { get; set; }

    public int Tanggal { get; set; }

    public int Bulan { get; set; }

    public int Tahun { get; set; }

    public int Status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? StatusDesc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int? KodeWilayah { get; set; }
}
