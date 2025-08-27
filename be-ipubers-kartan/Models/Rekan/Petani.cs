using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Petani")]
[Index("Nik", Name = "IX_Petani", IsUnique = true)]
public partial class Petani
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string NamaPetani { get; set; } = null!;

    [Column("NIK")]
    [StringLength(20)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? NoHp { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? KelompokTani { get; set; }

    [Column("FotoKTP1")]
    [StringLength(100)]
    [Unicode(false)]
    public string FotoKtp1 { get; set; } = null!;

    [Column("FotoKTP2")]
    [StringLength(100)]
    [Unicode(false)]
    public string FotoKtp2 { get; set; } = null!;

    [Column("isPetaniRDKK")]
    public int IsPetaniRdkk { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string StatusPetani { get; set; } = null!;

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

    [StringLength(500)]
    [Unicode(false)]
    public string? WajahTampakDepan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? WajahTampakKanan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? WajahTampakKiri { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? VideoWajah { get; set; }

    [Column("FotoKTP")]
    [StringLength(500)]
    [Unicode(false)]
    public string? FotoKtp { get; set; }

    [Column("SwafotoKTP")]
    [StringLength(500)]
    [Unicode(false)]
    public string? SwafotoKtp { get; set; }

    [InverseProperty("IdPetaniNavigation")]
    public virtual ICollection<DokumentasiPoktanPetani> DokumentasiPoktanPetanis { get; set; } = new List<DokumentasiPoktanPetani>();

    [InverseProperty("IdPetaniNavigation")]
    public virtual ICollection<PenjualanDump> PenjualanDumps { get; set; } = new List<PenjualanDump>();

    [InverseProperty("IdPetaniNavigation")]
    public virtual ICollection<Penjualan> Penjualans { get; set; } = new List<Penjualan>();

    [InverseProperty("IdPetaniNavigation")]
    public virtual ICollection<PoktanPetani> PoktanPetanis { get; set; } = new List<PoktanPetani>();

    [InverseProperty("IdPetaniNavigation")]
    public virtual ICollection<Rdkkpetani> Rdkkpetanis { get; set; } = new List<Rdkkpetani>();
}
