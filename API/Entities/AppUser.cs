using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<AppUserCourse> AppUserCourses { get; set; }
    }
}