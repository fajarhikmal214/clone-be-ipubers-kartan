using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SurveyExternalRetailer")]
[Index("IdSurveyExternal", "IdRetailer", Name = "IX_SurveyExternalRetailer", IsUnique = true)]
public partial class SurveyExternalRetailer
{
    [Key]
    [StringLength(150)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    public int IdSurveyExternal { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    public int StatusSubmit { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalSubmit { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("SurveyExternalRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSurveyExternal")]
    [InverseProperty("SurveyExternalRetailers")]
    public virtual SurveyExternal IdSurveyExternalNavigation { get; set; } = null!;

    [InverseProperty("SurveyExternalRetailer")]
    public virtual ICollection<SurveyExternalRetailerJawaban> SurveyExternalRetailerJawabans { get; set; } = new List<SurveyExternalRetailerJawaban>();
}
