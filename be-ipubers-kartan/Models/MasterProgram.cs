using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("MasterProgram")]
[Index("Code", Name = "MasterProgram_Code_uindex", IsUnique = true)]
public partial class MasterProgram
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Description { get; set; }

    public bool? Status { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ParentCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string UpdatedBy { get; set; } = null!;

    [InverseProperty("MasterProgram")]
    public virtual ICollection<MasterProgramRetailer> MasterProgramRetailers { get; set; } = new List<MasterProgramRetailer>();
}
