using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("LogTransaksiKartan")]
public partial class LogTransaksiKartan
{
    [Key]
    public int Id { get; set; }

    public string RequestBody { get; set; } = null!;

    public string ResponseBody { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    public int? KodeWilayah { get; set; }

    public int? JumlahData { get; set; }

    public int? Tanggal { get; set; }

    public int? Bulan { get; set; }

    public int? Tahun { get; set; }

    [InverseProperty("IdLogTransaksiKartanNavigation")]
    public virtual ICollection<LogTransaksiKartanDatum> LogTransaksiKartanData { get; set; } = new List<LogTransaksiKartanDatum>();
}
