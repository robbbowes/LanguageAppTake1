namespace API.Entities
{
    public class AppUserCourse
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}