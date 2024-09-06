using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuristApp2.Models.TuristApp2.Models;

namespace TuristApp2.Models
{
    public class Posty
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Opis { get; set; }

        [ForeignKey("Miejsca")]
        public int? MiejscaId { get; set; }

        public Miejsca? Miejsca { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
