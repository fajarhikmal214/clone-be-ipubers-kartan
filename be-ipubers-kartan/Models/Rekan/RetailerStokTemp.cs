using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RetailerStokTemp")]
[Index("IdProdukRetailer", "Bulan", "Tahun", "IdKecamatan", Name = "RetailerStokTemp_IdProdukRetailer_Bulan_Tahun_IdKecamatan_uindex", IsUnique = true)]
[Index("Id", Name = "RetailerStokTemp_Id_uindex", IsUnique = true)]
public partial class RetailerStokTemp
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatan { get; set; } = null!;

    public int IdProdukRetailer { get; set; }

    public int Bulan { get; set; }

    public int Tahun { get; set; }

    public int StokAwal { get; set; }

    public int Penebusan { get; set; }

    public int Penyaluran { get; set; }

    public int StokAkhir { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Catatan { get; set; }

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

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("RetailerStokTemps")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerStokTemps")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
