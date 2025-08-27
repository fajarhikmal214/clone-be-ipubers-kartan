using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PoktanPetani")]
[Index("Id", Name = "PoktanPetani_Id_uindex", IsUnique = true)]
public partial class PoktanPetani
{
    [Key]
    public int Id { get; set; }

    public int PoktanId { get; set; }

    public int IdPetani { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string NamaPoktan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPetani")]
    [InverseProperty("PoktanPetanis")]
    public virtual Petani IdPetaniNavigation { get; set; } = null!;
}
