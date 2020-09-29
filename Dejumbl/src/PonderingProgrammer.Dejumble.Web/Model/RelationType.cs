using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Dejumble.Web.Model
{
    public enum RelationType
    {
        [Display(Name = "Is related to", Description = "Most generic type of relation.")]
        IsRelatedTo,
        [Display(Name = "Is analogous to", Description = "Represents same concept but in different environment.")]
        IsAnalogousTo,
        [Display(Description = "Abstraction is a simplified concept with removed details.")]
        Abstracts,
        [Display(Description = "Generalization is a more general concept formulated from more specific instances and based on their common properties.")]
        Instantiates,
        Generalizes,
        Exemplifies,
        [Display(Description = "Group concepts, broad concepts or complex concepts can include its constituents.")]
        Includes,
        [Display(Name = "Is part of")]
        IsPartOf,
        Supports,
        [Display(Name = "Is supported by")]
        IsSupportedBy,
        Contradicts,
        [Display(Name = "Is contradicted by")]
        IsContradictedBy,
    }
}