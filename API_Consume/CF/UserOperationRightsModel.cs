using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API_Consume.CF
{
    public class UserOperationRightsModel
    {
        [Required, Display(Name = "IsAdd")]
        public bool IsAdd { get; set; }

        [Required, Display(Name = "IsEdit")]
        public bool IsEdit { get; set; }

        [Required, Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        [Required, Display(Name = "IsExport")]
        public bool IsExport { get; set; }

        [Required, Display(Name = "IsPrint")]
        public bool IsPrint { get; set; }

        [Display(Name = "PageHelpText")]
        public string? PageHelpText { get; set; }

        [Display(Name = "PageImportantNote")]
        public string? PageImportantNote { get; set; }
    }
}
