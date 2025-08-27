using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class DistPenyaluran
{
    public long Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Nomor { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Tanggal { get; set; }

    [Column("Transportasi_JenisKendaraan")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TransportasiJenisKendaraan { get; set; }

    [Column("Transportasi_NomorPolisi")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TransportasiNomorPolisi { get; set; }

    [Column("Transportasi_NamaPengemudi")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TransportasiNamaPengemudi { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Note { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NomorReferensi { get; set; }

    [Column("Penyalur_Asal")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PenyalurAsal { get; set; }

    [Column("Penyalur_Asal_Jenis")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PenyalurAsalJenis { get; set; }

    [Column("Penyalur_Tujuan")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PenyalurTujuan { get; set; }

    [Column("Penyalur_Tujuan_Jenis")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PenyalurTujuanJenis { get; set; }

    [Column("Cancellation_Status")]
    public bool? CancellationStatus { get; set; }

    [Column("Cancellation_Date", TypeName = "datetime")]
    public DateTime? CancellationDate { get; set; }

    [Column("Cancellation_Note")]
    [StringLength(250)]
    [Unicode(false)]
    public string? CancellationNote { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int? Source { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaSupplier { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoNotaPemesanan { get; set; }

    public int? AlamatPengantaran { get; set; }
}
