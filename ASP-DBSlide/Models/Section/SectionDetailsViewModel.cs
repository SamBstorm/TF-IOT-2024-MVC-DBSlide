using System.ComponentModel;

namespace ASP_DBSlide.Models.Section
{
    public class SectionDetailsViewModel
    {
        [DisplayName("Identifiant")]
        public int Section_Id { get; set; }
        [DisplayName("Nom")]
        public string Section_Name { get; set; }
        [DisplayName("Délégué")]
        public int? Delegate_Id { get; set; }
    }
}
