using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsEnrollment.Persist.Domain
{
    public class LectureTheatre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public int Capacity { get; set; }
    }
}
