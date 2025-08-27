using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[PrimaryKey("Kode", "IdRetailer")]
[Table("PelangganRetailerIFarms")]
public partial class PelangganRetailerIfarm
{
    [Key]
    [StringLength(150)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [Key]
    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [Column("NIK")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Nik { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoHp { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Alamat { get; set; }

    public byte Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int LevelHarga { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NoProjek { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaProjek { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PelangganRetailerIfarms")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
