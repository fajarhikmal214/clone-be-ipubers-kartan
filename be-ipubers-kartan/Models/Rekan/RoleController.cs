using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

public partial class RoleController
{
    [Key]
    public int Id { get; set; }

    public int ControllerId { get; set; }

    [StringLength(450)]
    public string RoleId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [MaxLength(100)]
    public byte[]? UpdatedBy { get; set; }
}
