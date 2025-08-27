using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

public partial class LogTransaksiKartanDatum
{
    [Key]
    public int Id { get; set; }

    public int IdLogTransaksiKartan { get; set; }

    [Column("MID")]
    [StringLength(50)]
    [Unicode(false)]
    public string Mid { get; set; } = null!;

    public DateOnly TanggalTransaksi { get; set; }

    public int Urea { get; set; }

    [Column("NPK")]
    public int Npk { get; set; }

    [Column("NPKFK")]
    public int Npkfk { get; set; }

    public int Status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Tipe { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdLogTransaksiKartan")]
    [InverseProperty("LogTransaksiKartanData")]
    public virtual LogTransaksiKartan IdLogTransaksiKartanNavigation { get; set; } = null!;
}
