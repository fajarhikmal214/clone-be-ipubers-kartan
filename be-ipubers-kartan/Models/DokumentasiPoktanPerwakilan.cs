using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("DokumentasiPoktanPerwakilan")]
[Index("Id", Name = "DokumentasiPoktanPerwakilan_Id_uindex", IsUnique = true)]
public partial class DokumentasiPoktanPerwakilan
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NamaPerwakilan { get; set; } = null!;

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int IdDokumentasiPoktan { get; set; }

    [ForeignKey("IdDokumentasiPoktan")]
    [InverseProperty("DokumentasiPoktanPerwakilans")]
    public virtual DokumentasiPoktan IdDokumentasiPoktanNavigation { get; set; } = null!;
}
