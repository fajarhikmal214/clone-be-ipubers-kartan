using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterController")]
public partial class MasterController
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ControllerName { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Path { get; set; }

    [Unicode(false)]
    public string? Deskripsi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Nama { get; set; }
}
