using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Skala dari masing-masing survey
/// </summary>
[Table("SurveySkala")]
[Index("Urutan", Name = "SurveySkala_Urutan_index")]
public partial class SurveySkala
{
    [Key]
    public int Id { get; set; }

    public int? IdSurvey { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    public int Urutan { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? IconActive { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? IconInactive { get; set; }

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

    [ForeignKey("IdSurvey")]
    [InverseProperty("SurveySkalas")]
    public virtual Survey? IdSurveyNavigation { get; set; }

    [InverseProperty("IdSurveySkalaNavigation")]
    public virtual ICollection<SurveyRetailerJawaban> SurveyRetailerJawabans { get; set; } = new List<SurveyRetailerJawaban>();

    [InverseProperty("IdSurveySkalaNavigation")]
    public virtual ICollection<SurveySkalaAlasan> SurveySkalaAlasans { get; set; } = new List<SurveySkalaAlasan>();
}
