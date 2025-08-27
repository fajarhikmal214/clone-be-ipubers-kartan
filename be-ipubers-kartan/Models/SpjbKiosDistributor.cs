using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SpjbKiosDistributor", Schema = "dbo_tebus")]
[Index("Nomor", Name = "KEY_SpjbKiosDistributor_Nomor", IsUnique = true)]
public partial class SpjbKiosDistributor
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    [StringLength(256)]
    [Unicode(false)]
    public string Nomor { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int Tahun { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IdDistributor { get; set; }

    public int Status { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? NoReferensi { get; set; }

    public int Tipe { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalAkhir { get; set; }

    [ForeignKey("IdDistributor")]
    [InverseProperty("SpjbKiosDistributors")]
    public virtual Distributor? IdDistributorNavigation { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("SpjbKiosDistributors")]
    public virtual MasterKecamatan IdKecamatanNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("SpjbKiosDistributors")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("NoReferensiNavigation")]
    public virtual ICollection<SpjbKiosDistributor> InverseNoReferensiNavigation { get; set; } = new List<SpjbKiosDistributor>();

    [ForeignKey("NoReferensi")]
    [InverseProperty("InverseNoReferensiNavigation")]
    public virtual SpjbKiosDistributor? NoReferensiNavigation { get; set; }

    [InverseProperty("IdSpjbNavigation")]
    public virtual ICollection<SpjbKiosDistributorDetail> SpjbKiosDistributorDetails { get; set; } = new List<SpjbKiosDistributorDetail>();
}
