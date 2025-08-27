using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// table untuk log/history kirim data stok PKP ke Kementan
/// </summary>
[Table("KementanLogKirimStok")]
[Index("Id", Name = "KementanLogKirimStok_Id_uindex", IsUnique = true)]
public partial class KementanLogKirimStok
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NoPkp { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalKirim { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalDiterimaKios { get; set; }

    public int Urea { get; set; }

    public int Npk { get; set; }

    public int Sp36 { get; set; }

    public int Za { get; set; }

    public int? NpkFormula { get; set; }

    public int Organic { get; set; }

    public int Poc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int StatusKirim { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KodeProduk { get; set; }

    public int? Qty { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("KementanLogKirimStoks")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
