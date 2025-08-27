using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// table untuk log kirim mutasi stok
/// </summary>
[Table("KementanLogKirimMutasiStok")]
[Index("Id", Name = "KementanLogKirimMutasiStok_Id_uindex", IsUnique = true)]
public partial class KementanLogKirimMutasiStok
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualanProdukRetailerPkp { get; set; }

    public int StatusKirim { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int? IdMutasi { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoPkp { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? KodeKios { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoTransaksiRms { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KodeProduk { get; set; }

    public int? Qty { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Aksi { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Key { get; set; }

    public int? TglTebus { get; set; }

    public int? BulanTebus { get; set; }

    public int? TahunTebus { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [Unicode(false)]
    public string? FormDataString { get; set; }

    public int? IdTrx { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Komoditas { get; set; }
}
