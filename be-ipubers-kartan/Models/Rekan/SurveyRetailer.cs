using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Survey untuk masing-masing Retailer
/// </summary>
[Table("SurveyRetailer")]
[Index("CreatedAt", Name = "SurveyRetailer_CreatedAt_index")]
[Index("IdSurvey", "IdRetailer", Name = "SurveyRetailer_IdSurvey_IdRetailer_uindex", IsUnique = true)]
public partial class SurveyRetailer
{
    [Key]
    public int Id { get; set; }

    public int IdSurvey { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("SurveyRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSurvey")]
    [InverseProperty("SurveyRetailers")]
    public virtual Survey IdSurveyNavigation { get; set; } = null!;

    [InverseProperty("IdSurveyRetailerNavigation")]
    public virtual ICollection<SurveyRetailerJawaban> SurveyRetailerJawabans { get; set; } = new List<SurveyRetailerJawaban>();
}
