using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
public partial class VmasterKode
{
    [StringLength(5)]
    [Unicode(false)]
    public string KodeInduk { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NamaInduk { get; set; } = null!;

    public int Id { get; set; }

    public int IdInduk { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }

    public int Urutan { get; set; }

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
}
