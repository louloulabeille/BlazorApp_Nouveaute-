using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp_Nouveaute.Models.DTO
{
    public enum TrancheAge
    {
        Bebe,
        Enfant,
        Adolescent,
        Adulte,
        Senior
    }

    public class DemoModel
    {
        [Required(ErrorMessage ="La tranche d'âge est obligatoire.")]
        public TrancheAge TrancheAge { get; set; }
    }
}
