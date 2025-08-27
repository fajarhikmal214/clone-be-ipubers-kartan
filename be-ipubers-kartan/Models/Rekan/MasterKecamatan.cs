using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterKecamatan")]
public partial class MasterKecamatan
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Nama { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKab { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdWcm { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdAlokasi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdInduk { get; set; }

    [ForeignKey("IdKab")]
    [InverseProperty("MasterKecamatans")]
    public virtual MasterKabupaten? IdKabNavigation { get; set; }

    [InverseProperty("IdKecamatanRekanNavigation")]
    public virtual ICollection<MappingArea> MappingAreas { get; set; } = new List<MappingArea>();

    [InverseProperty("IdKecamatanRekanNavigation")]
    public virtual ICollection<MappingDesa> MappingDesas { get; set; } = new List<MappingDesa>();

    [InverseProperty("IdKecNavigation")]
    public virtual ICollection<MasterDesa> MasterDesas { get; set; } = new List<MasterDesa>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<PendaftaranRetailer> PendaftaranRetailers { get; set; } = new List<PendaftaranRetailer>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<PkpCopy> PkpCopies { get; set; } = new List<PkpCopy>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<Pkp> Pkps { get; set; } = new List<Pkp>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<ProdukRetailerStokKecamatan> ProdukRetailerStokKecamatans { get; set; } = new List<ProdukRetailerStokKecamatan>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<RetailerA> RetailerAs { get; set; } = new List<RetailerA>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<Retailer> Retailers { get; set; } = new List<Retailer>();

    [ForeignKey("IdKecamatan")]
    [InverseProperty("IdKecamatans")]
    public virtual ICollection<Retailer> Codes { get; set; } = new List<Retailer>();
}
