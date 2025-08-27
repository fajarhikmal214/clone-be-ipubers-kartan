using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RptStokDPCS")]
public partial class RptStokDpc
{
    [StringLength(50)]
    [Unicode(false)]
    public string? Propinsi { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Kabupaten { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NamaKios { get; set; } = null!;

    public double Urea { get; set; }

    [Column("NPK")]
    public double Npk { get; set; }

    [Column("NPKKhusus")]
    public double Npkkhusus { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Alamat { get; set; }

    [Key]
    [StringLength(12)]
    public string KodeKios { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? IdPropinsi { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKabupaten { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? WarnaLapor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Sumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalLapor { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Foto1 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Foto2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
