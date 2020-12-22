using API.Entities;
using API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserCourse> AppUserCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Utility.CreatePasswordHash("passw0rd", out byte[] passwordhash, out byte[] passwordSalt);

            modelBuilder.Entity<AppUserCourse>()
                .HasKey(uc => new { uc.AppUserId, uc.CourseId });

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Admin",
                    PasswordHash = passwordhash,
                    PasswordSalt = passwordSalt,
                    UserRole = AppUserRole.Admin
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "Robb",
                    PasswordHash = passwordhash,
                    PasswordSalt = passwordSalt,
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "Elise",
                    PasswordHash = passwordhash,
                    PasswordSalt = passwordSalt,
                }
            );

            modelBuilder.Entity<AppUserCourse>().HasData(
                new AppUserCourse { AppUserId = 1, CourseId = 1 },
                new AppUserCourse { AppUserId = 1, CourseId = 2 },
                new AppUserCourse { AppUserId = 1, CourseId = 3 },
                new AppUserCourse { AppUserId = 2, CourseId = 3 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Assimil French with Ease",
                    LanguageId = 2
                },
                new Course
                {
                    Id = 2,
                    Name = "Assimil Using French",
                    LanguageId = 2
                },
                new Course
                {
                    Id = 3,
                    Name = "Assimil Norwegian",
                    LanguageId = 3
                }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "English"
                },
                new Language
                {
                    Id = 2,
                    Name = "French"
                },
                new Language
                {
                    Id = 3,
                    Name = "Norwegian"
                }
            );

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = 1,
                    Name = "Introduction - Assimil French with Ease",
                    Number = 1,
                    CourseId = 1,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 2,
                    Name = "Lesson 2",
                    Number = 2,
                    CourseId = 1,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 3,
                    Name = "Lesson 3",
                    Number = 3,
                    CourseId = 1,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 4,
                    Name = "Introduction - Assimil Using French",
                    Number = 1,
                    CourseId = 2,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 5,
                    Name = "Lesson 2",
                    Number = 2,
                    CourseId = 2,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 6,
                    Name = "Lesson 3",
                    Number = 3,
                    CourseId = 2,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 7,
                    Name = "Introduction - Assimil Norwegian",
                    Number = 1,
                    CourseId = 3,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 8,
                    Name = "Lesson 2",
                    Number = 2,
                    CourseId = 3,
                    LessonAudio = "localpath"
                },
                new Lesson
                {
                    Id = 9,
                    Name = "Lesson 3",
                    Number = 3,
                    CourseId = 3,
                    LessonAudio = "localpath"
                }
            );

            modelBuilder.Entity<Sentence>().HasData(
                new Sentence
                {
                    Id = 1,
                    Number = 1,
                    Text = "This is the first sentence in French",
                    SentenceAudio = "local path",
                    RecordedAudio = "local path",
                    LessonId = 1,
                    LanguageId = 2
                },
                new Sentence
                {
                    Id = 2,
                    Number = 2,
                    Text = "This is the second sentence in French",
                    SentenceAudio = "local path",
                    RecordedAudio = "local path",
                    LessonId = 1,
                    LanguageId = 2
                },
                new Sentence
                {
                    Id = 3,
                    Number = 3,
                    Text = "This is the third sentence in French",
                    SentenceAudio = "local path",
                    RecordedAudio = "local path",
                    LessonId = 1,
                    LanguageId = 2
                },
                new Sentence
                {
                    Id = 4,
                    Number = 4,
                    Text = "This is the fourth sentence in French",
                    SentenceAudio = "local path",
                    RecordedAudio = "local path",
                    LessonId = 1,
                    LanguageId = 2
                }
            );

            modelBuilder.Entity<Translation>().HasData(
                new Translation
                {
                    Id = 1,
                    LanguageId = 1,
                    SentenceId = 1,
                    TranslatedText = "This is the English translation of the first sentence"
                }
            );
        }
    }
}