using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterPerusahaanAfiliasi")]
public partial class MasterPerusahaanAfiliasi
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Jenis { get; set; }

    [InverseProperty("PerusahaanAfiliasiNavigation")]
    public virtual ICollection<PendaftaranRetailer> PendaftaranRetailers { get; set; } = new List<PendaftaranRetailer>();
}
