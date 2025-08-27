using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// table survey
/// </summary>
[Table("Survey")]
[Index("NamaSurvey", Name = "Survey_NamaSurvey_uindex", IsUnique = true)]
[Index("Pertanyaan", Name = "Survey_Pertanyaan_uindex", IsUnique = true)]
public partial class Survey
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NamaSurvey { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Pertanyaan { get; set; } = null!;

    [Column("isDismissable")]
    public int IsDismissable { get; set; }

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

    [InverseProperty("IdSurveyNavigation")]
    public virtual ICollection<SurveyRetailer> SurveyRetailers { get; set; } = new List<SurveyRetailer>();

    [InverseProperty("IdSurveyNavigation")]
    public virtual ICollection<SurveySkala> SurveySkalas { get; set; } = new List<SurveySkala>();
}
