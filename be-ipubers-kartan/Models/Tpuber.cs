using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[PrimaryKey("KodeKios", "Nik", "TanggalInput")]
[Table("TPubers")]
public partial class Tpuber
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime TanggalInput { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NamaKios { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProvinsiId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Provinsi { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KabupatenId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Kabupaten { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? KecamatanId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    public int? TahunTebus { get; set; }

    public int? BulanTebus { get; set; }

    public int? TanggalTebus { get; set; }

    [StringLength(250)]
    public string? Status { get; set; }

    [StringLength(250)]
    public string? StatusData { get; set; }

    [StringLength(250)]
    public string? Keterangan { get; set; }

    public int? Urea { get; set; }

    public int? Npk { get; set; }

    public int? Sp36 { get; set; }

    public int? Za { get; set; }

    public int? NpkFormula { get; set; }

    public int? Organik { get; set; }

    public int? OrganikCair { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(250)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [StringLength(250)]
    public string? UpdatedBy { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Komoditas { get; set; }
}
