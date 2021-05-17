using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsEnrollment.Persist.Domain
{
    public class Lecture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LectureId { get; set; }

        public int TheatreId { get; set; }
        public int SubjectId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public List<LectureTheatre> Theatres { get; set; }
    }
}
