using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RDKK")]
[Index("IdRetailer", "Tahun", Name = "IX_RDKK_1", IsUnique = true)]
public partial class Rdkk
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string KelompokTani { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string NamaKios { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? Kelurahan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Subsektor { get; set; } = null!;

    public int Tahun { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [InverseProperty("IdErdkkNavigation")]
    public virtual ICollection<Erdkkdetail> Erdkkdetails { get; set; } = new List<Erdkkdetail>();

    [ForeignKey("IdRetailer")]
    [InverseProperty("Rdkks")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdRdkkNavigation")]
    public virtual ICollection<Rdkkpetani> Rdkkpetanis { get; set; } = new List<Rdkkpetani>();
}
