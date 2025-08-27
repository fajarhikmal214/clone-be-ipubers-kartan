using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SPJB", Schema = "dbo_tebus")]
[Index("IdRetailer", "IdKecamatan", Name = "IDX_SPJB")]
public partial class Spjb1
{
    [Key]
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    [Column("NoSPJB")]
    [StringLength(50)]
    [Unicode(false)]
    public string NoSpjb { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    public int Tahun { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAkhir { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Komoditas { get; set; } = null!;

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DistriutorId { get; set; } = null!;

    [ForeignKey("DistriutorId")]
    [InverseProperty("Spjb1s")]
    public virtual Distributor Distriutor { get; set; } = null!;

    [ForeignKey("IdKecamatan")]
    [InverseProperty("Spjb1s")]
    public virtual MasterKecamatan IdKecamatanNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("Spjb1s")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
