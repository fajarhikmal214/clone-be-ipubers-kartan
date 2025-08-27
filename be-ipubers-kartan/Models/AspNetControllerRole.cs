using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

public partial class AspNetControllerRole
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string RoleId { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int Menu { get; set; }

    [ForeignKey("Menu")]
    [InverseProperty("AspNetControllerRoles")]
    public virtual MasterMenu MenuNavigation { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("AspNetControllerRoles")]
    public virtual AspNetRole Role { get; set; } = null!;
}
