using System;

namespace StudentsEnrollment.Application.Models
{
    public class LectureModel
    {
        public string SubjectName { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
