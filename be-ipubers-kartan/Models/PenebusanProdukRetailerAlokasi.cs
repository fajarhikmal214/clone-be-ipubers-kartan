using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanProdukRetailerAlokasi", Schema = "dbo_tebus")]
public partial class PenebusanProdukRetailerAlokasi
{
    [Key]
    public int Id { get; set; }

    public int? IdPenebusanKiosDistributor { get; set; }

    public int? IdProdukRetailer { get; set; }

    public int? AlokasiAwal { get; set; }

    public int? Qty { get; set; }

    public int? AlokasiAkhir { get; set; }

    public int? TipeTransaksi { get; set; }

    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdPenebusanKiosDistributor")]
    [InverseProperty("PenebusanProdukRetailerAlokasis")]
    public virtual PenebusanKiosDistributor? IdPenebusanKiosDistributorNavigation { get; set; }

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("PenebusanProdukRetailerAlokasis")]
    public virtual ProdukRetailer? IdProdukRetailerNavigation { get; set; }
}
