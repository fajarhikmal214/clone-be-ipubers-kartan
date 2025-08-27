using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Tutorial")]
public partial class Tutorial
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Judul { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Deskripsi { get; set; }

    public int ParentId { get; set; }

    [ForeignKey("ParentId")]
    [InverseProperty("Tutorials")]
    public virtual TutorialParent Parent { get; set; } = null!;
}
