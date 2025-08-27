using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RDKKProduk")]
[Index("IdRdkkpetani", Name = "NCI_RDKKProduk1")]
[Index("CreatedAt", Name = "RDKKProduk_CreatedAt_index")]
public partial class Rdkkproduk
{
    [Key]
    public int Id { get; set; }

    [Column("IdRDKKPetani")]
    public int IdRdkkpetani { get; set; }

    public int IdProduk { get; set; }

    [Column("MTKe")]
    public int? Mtke { get; set; }

    [Column("MT")]
    public double Mt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Komoditas { get; set; }

    public int? IdKomoditas { get; set; }

    [ForeignKey("IdProduk")]
    [InverseProperty("Rdkkproduks")]
    public virtual Produk IdProdukNavigation { get; set; } = null!;

    [ForeignKey("IdRdkkpetani")]
    [InverseProperty("Rdkkproduks")]
    public virtual Rdkkpetani IdRdkkpetaniNavigation { get; set; } = null!;
}
