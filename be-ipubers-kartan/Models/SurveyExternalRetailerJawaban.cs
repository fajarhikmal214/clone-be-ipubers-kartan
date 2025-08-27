using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SurveyExternalRetailerJawaban")]
public partial class SurveyExternalRetailerJawaban
{
    [Key]
    public long Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? SurveyExternalRetailerId { get; set; }

    public int? NomorPertanyaan { get; set; }

    public string? Jawaban { get; set; }

    [ForeignKey("SurveyExternalRetailerId")]
    [InverseProperty("SurveyExternalRetailerJawabans")]
    public virtual SurveyExternalRetailer? SurveyExternalRetailer { get; set; }
}
