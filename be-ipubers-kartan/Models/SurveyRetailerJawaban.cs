using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// Jawaban dari masing-masing retailer terkait dengan survey yang diterima
/// </summary>
[Table("SurveyRetailerJawaban")]
[Index("Id", Name = "SurveyRetailerJawaban_Id_uindex", IsUnique = true)]
public partial class SurveyRetailerJawaban
{
    [Key]
    public int Id { get; set; }

    public int IdSurveyRetailer { get; set; }

    public int IdSurveySkala { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Alasan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdSurveyRetailer")]
    [InverseProperty("SurveyRetailerJawabans")]
    public virtual SurveyRetailer IdSurveyRetailerNavigation { get; set; } = null!;

    [ForeignKey("IdSurveySkala")]
    [InverseProperty("SurveyRetailerJawabans")]
    public virtual SurveySkala IdSurveySkalaNavigation { get; set; } = null!;
}
