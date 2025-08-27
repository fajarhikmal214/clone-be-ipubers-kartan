using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Detail Dokumentasi Poktan
/// </summary>
[Table("DokumentasiPoktanPetani")]
[Index("Id", Name = "DokumentasiPoktanPetani_Id_uindex", IsUnique = true)]
public partial class DokumentasiPoktanPetani
{
    [Key]
    public int Id { get; set; }

    public int IdDokumentasiPoktan { get; set; }

    public int IdPetani { get; set; }

    [ForeignKey("IdDokumentasiPoktan")]
    [InverseProperty("DokumentasiPoktanPetanis")]
    public virtual DokumentasiPoktan IdDokumentasiPoktanNavigation { get; set; } = null!;

    [ForeignKey("IdPetani")]
    [InverseProperty("DokumentasiPoktanPetanis")]
    public virtual Petani IdPetaniNavigation { get; set; } = null!;
}
