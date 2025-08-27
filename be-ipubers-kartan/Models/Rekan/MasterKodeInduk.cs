using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterKodeInduk")]
[Index("Kode", Name = "IX_MasterKodeInduk", IsUnique = true)]
public partial class MasterKodeInduk
{
    [Key]
    public int Id { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

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

    [InverseProperty("IdIndukNavigation")]
    public virtual ICollection<MasterKode> MasterKodes { get; set; } = new List<MasterKode>();
}
