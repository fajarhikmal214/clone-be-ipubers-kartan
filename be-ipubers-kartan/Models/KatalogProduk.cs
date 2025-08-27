using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("KatalogProduk")]
[Index("IsDomesticProduction", Name = "KatalogProduk_IsDomesticProduction_index")]
[Index("IsPiPastiAda", Name = "KatalogProduk_IsPiPastiAda_index")]
[Index("IsPi", Name = "KatalogProduk_IsPi_index")]
[Index("IsRetail", Name = "KatalogProduk_IsRetail_index")]
[Index("KodeSap", Name = "KatalogProduk_KodeSap_index")]
[Index("Kode", Name = "KatalogProduk_Kode_uindex", IsUnique = true)]
[Index("Status", Name = "KatalogProduk_Status_index")]
public partial class KatalogProduk
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Kode { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Nama { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Satuan { get; set; }

    /// <summary>
    /// 1 = Ya
    /// 0 = Tidak
    /// </summary>
    public int? IsPi { get; set; }

    /// <summary>
    /// 1 = Ya
    /// 0 = Tidak
    /// </summary>
    public int? IsRetail { get; set; }

    /// <summary>
    /// 1 = Ya
    /// 0 = Tidak
    /// </summary>
    public int? IsDomesticProduction { get; set; }

    /// <summary>
    /// 1 = Ya
    /// 0 = Tidak
    /// </summary>
    public int? IsPiPastiAda { get; set; }

    [StringLength(256)]
    public string? NamaProdusen { get; set; }

    public byte? Status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? KodeSap { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("IdKatalogNavigation")]
    public virtual ICollection<ProdukRetailer> ProdukRetailers { get; set; } = new List<ProdukRetailer>();
}
