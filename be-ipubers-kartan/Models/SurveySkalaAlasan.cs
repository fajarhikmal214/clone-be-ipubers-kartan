using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SurveySkalaAlasan")]
[Index("IdSurveySkala", "Alasan", Name = "SurveyAlasan_IdSurvey_Alasan_uindex", IsUnique = true)]
[Index("Id", Name = "SurveyAlasan_Id_uindex", IsUnique = true)]
public partial class SurveySkalaAlasan
{
    [Key]
    public int Id { get; set; }

    public int IdSurveySkala { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Alasan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdSurveySkala")]
    [InverseProperty("SurveySkalaAlasans")]
    public virtual SurveySkala IdSurveySkalaNavigation { get; set; } = null!;
}
