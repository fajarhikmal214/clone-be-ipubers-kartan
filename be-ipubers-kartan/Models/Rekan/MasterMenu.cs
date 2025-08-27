using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterMenu")]
public partial class MasterMenu
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Controller { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Icon { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Action { get; set; }

    public short? Urutan { get; set; }

    public int? App { get; set; }

    [InverseProperty("MenuNavigation")]
    public virtual ICollection<AspNetControllerRole> AspNetControllerRoles { get; set; } = new List<AspNetControllerRole>();
}
