using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Index("Id", Name = "KementanKios_Id_uindex", IsUnique = true)]
[Index("KodeKios", "KodeDesa", Name = "KementanKios_KodeKios_KodeDesa_uindex", IsUnique = true)]
public partial class KementanKio
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaKios { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UpdateBy { get; set; }
}
