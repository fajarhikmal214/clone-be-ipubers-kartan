using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("DokumentasiPoktan")]
[Index("Id", Name = "DokumentasiPoktan_Id_uindex", IsUnique = true)]
[Index("PoktanId", "TglAwal", "IdRetailer", Name = "DokumentasiPoktan_PoktanId_TglAwal_IdRetailer_uindex", IsUnique = true)]
public partial class DokumentasiPoktan
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TglAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TglAkhir { get; set; }

    public int PoktanId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NamaPoktan { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string KetuaPoktan { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string UrlDokumen { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int Status { get; set; }

    [InverseProperty("IdDokumentasiPoktanNavigation")]
    public virtual ICollection<DokumentasiPoktanPerwakilan> DokumentasiPoktanPerwakilans { get; set; } = new List<DokumentasiPoktanPerwakilan>();

    [InverseProperty("IdDokumentasiPoktanNavigation")]
    public virtual ICollection<DokumentasiPoktanPetani> DokumentasiPoktanPetanis { get; set; } = new List<DokumentasiPoktanPetani>();

    [ForeignKey("IdRetailer")]
    [InverseProperty("DokumentasiPoktans")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
