using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    UserRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCourses",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCourses", x => new { x.AppUserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_AppUserCourses_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonAudio = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    SentenceAudio = table.Column<string>(type: "TEXT", nullable: true),
                    RecordedAudio = table.Column<string>(type: "TEXT", nullable: true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentences_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sentences_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    SentenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    TranslatedText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Sentences_SentenceId",
                        column: x => x.SentenceId,
                        principalTable: "Sentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName", "UserRole" },
                values: new object[] { 1, new byte[] { 6, 15, 159, 219, 253, 234, 203, 60, 24, 183, 230, 184, 241, 94, 168, 100, 63, 22, 47, 239, 229, 157, 33, 112, 186, 103, 96, 121, 7, 60, 221, 214, 188, 166, 62, 182, 89, 145, 122, 239, 220, 209, 198, 81, 239, 37, 26, 117, 69, 195, 31, 208, 84, 106, 50, 9, 58, 191, 113, 150, 32, 224, 254, 212 }, new byte[] { 121, 205, 174, 161, 177, 240, 31, 88, 164, 21, 77, 61, 85, 175, 47, 162, 149, 103, 129, 238, 43, 9, 24, 92, 145, 172, 135, 185, 189, 147, 227, 10, 94, 144, 169, 240, 139, 205, 14, 181, 228, 129, 143, 230, 189, 254, 94, 21, 122, 55, 141, 9, 230, 229, 117, 88, 17, 67, 94, 85, 156, 152, 134, 57, 199, 85, 185, 54, 197, 150, 200, 188, 118, 60, 115, 176, 56, 71, 185, 49, 80, 98, 109, 240, 218, 77, 200, 124, 16, 183, 130, 5, 233, 169, 51, 112, 111, 185, 59, 165, 226, 245, 210, 197, 121, 64, 3, 254, 222, 63, 120, 2, 251, 48, 3, 133, 126, 213, 223, 2, 79, 73, 107, 195, 61, 183, 89, 151 }, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName", "UserRole" },
                values: new object[] { 2, new byte[] { 6, 15, 159, 219, 253, 234, 203, 60, 24, 183, 230, 184, 241, 94, 168, 100, 63, 22, 47, 239, 229, 157, 33, 112, 186, 103, 96, 121, 7, 60, 221, 214, 188, 166, 62, 182, 89, 145, 122, 239, 220, 209, 198, 81, 239, 37, 26, 117, 69, 195, 31, 208, 84, 106, 50, 9, 58, 191, 113, 150, 32, 224, 254, 212 }, new byte[] { 121, 205, 174, 161, 177, 240, 31, 88, 164, 21, 77, 61, 85, 175, 47, 162, 149, 103, 129, 238, 43, 9, 24, 92, 145, 172, 135, 185, 189, 147, 227, 10, 94, 144, 169, 240, 139, 205, 14, 181, 228, 129, 143, 230, 189, 254, 94, 21, 122, 55, 141, 9, 230, 229, 117, 88, 17, 67, 94, 85, 156, 152, 134, 57, 199, 85, 185, 54, 197, 150, 200, 188, 118, 60, 115, 176, 56, 71, 185, 49, 80, 98, 109, 240, 218, 77, 200, 124, 16, 183, 130, 5, 233, 169, 51, 112, 111, 185, 59, 165, 226, 245, 210, 197, 121, 64, 3, 254, 222, 63, 120, 2, 251, 48, 3, 133, 126, 213, 223, 2, 79, 73, 107, 195, 61, 183, 89, 151 }, "Robb", 2 });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName", "UserRole" },
                values: new object[] { 3, new byte[] { 6, 15, 159, 219, 253, 234, 203, 60, 24, 183, 230, 184, 241, 94, 168, 100, 63, 22, 47, 239, 229, 157, 33, 112, 186, 103, 96, 121, 7, 60, 221, 214, 188, 166, 62, 182, 89, 145, 122, 239, 220, 209, 198, 81, 239, 37, 26, 117, 69, 195, 31, 208, 84, 106, 50, 9, 58, 191, 113, 150, 32, 224, 254, 212 }, new byte[] { 121, 205, 174, 161, 177, 240, 31, 88, 164, 21, 77, 61, 85, 175, 47, 162, 149, 103, 129, 238, 43, 9, 24, 92, 145, 172, 135, 185, 189, 147, 227, 10, 94, 144, 169, 240, 139, 205, 14, 181, 228, 129, 143, 230, 189, 254, 94, 21, 122, 55, 141, 9, 230, 229, 117, 88, 17, 67, 94, 85, 156, 152, 134, 57, 199, 85, 185, 54, 197, 150, 200, 188, 118, 60, 115, 176, 56, 71, 185, 49, 80, 98, 109, 240, 218, 77, 200, 124, 16, 183, 130, 5, 233, 169, 51, 112, 111, 185, 59, 165, 226, 245, 210, 197, 121, 64, 3, 254, 222, 63, 120, 2, 251, 48, 3, 133, 126, 213, 223, 2, 79, 73, 107, 195, 61, 183, 89, 151 }, "Elise", 2 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "English" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "French" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Norwegian" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 1, 2, "Assimil French with Ease" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 2, 2, "Assimil Using French" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 3, 3, "Assimil Norwegian" });

            migrationBuilder.InsertData(
                table: "AppUserCourses",
                columns: new[] { "AppUserId", "CourseId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AppUserCourses",
                columns: new[] { "AppUserId", "CourseId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AppUserCourses",
                columns: new[] { "AppUserId", "CourseId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "AppUserCourses",
                columns: new[] { "AppUserId", "CourseId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 1, 1, "localpath", "Introduction - Assimil French with Ease", 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 2, 1, "localpath", "Lesson 2", 2 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 3, 1, "localpath", "Lesson 3", 3 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 4, 2, "localpath", "Introduction - Assimil Using French", 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 5, 2, "localpath", "Lesson 2", 2 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 6, 2, "localpath", "Lesson 3", 3 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 7, 3, "localpath", "Introduction - Assimil Norwegian", 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 8, 3, "localpath", "Lesson 2", 2 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "LessonAudio", "Name", "Number" },
                values: new object[] { 9, 3, "localpath", "Lesson 3", 3 });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "LanguageId", "LessonId", "Number", "RecordedAudio", "SentenceAudio", "Text" },
                values: new object[] { 1, 2, 1, 1, "local path", "local path", "This is the first sentence in French" });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "LanguageId", "LessonId", "Number", "RecordedAudio", "SentenceAudio", "Text" },
                values: new object[] { 2, 2, 1, 2, "local path", "local path", "This is the second sentence in French" });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "LanguageId", "LessonId", "Number", "RecordedAudio", "SentenceAudio", "Text" },
                values: new object[] { 3, 2, 1, 3, "local path", "local path", "This is the third sentence in French" });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "LanguageId", "LessonId", "Number", "RecordedAudio", "SentenceAudio", "Text" },
                values: new object[] { 4, 2, 1, 4, "local path", "local path", "This is the fourth sentence in French" });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "LanguageId", "SentenceId", "TranslatedText" },
                values: new object[] { 1, 1, 1, "This is the English translation of the first sentence" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCourses_CourseId",
                table: "AppUserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentences_LanguageId",
                table: "Sentences",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentences_LessonId",
                table: "Sentences",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId",
                table: "Translations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_SentenceId",
                table: "Translations",
                column: "SentenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserCourses");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
