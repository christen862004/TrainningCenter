using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainningCenter.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    DeptartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DeptartmentId",
                        column: x => x.DeptartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_DeptartmentId",
                        column: x => x.DeptartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DeptartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Instructor_Department_DeptartmentId",
                        column: x => x.DeptartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeDegree = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResult_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseResult_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", ".Net" },
                    { 2, "Abdallah", "OS" },
                    { 3, "Faysal", "FrontEnd" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Degree", "DeptartmentId", "Hours", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 100, 1, 60, 50, "C#" },
                    { 2, 100, 2, 60, 50, "PHP" },
                    { 3, 100, 3, 60, 50, "Angular" }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DeptartmentId", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "Alex", 1, "m.png", "Karem" },
                    { 2, "Alex", 2, "m.png", "MOhsen" },
                    { 3, "Alex", 3, "2.jpg", "Mona" },
                    { 4, "Alex", 1, "2.jpg", "Fatma" }
                });

            migrationBuilder.InsertData(
                table: "CourseResult",
                columns: new[] { "Id", "CourseId", "TraineeDegree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 40, 1 },
                    { 2, 2, 80, 2 },
                    { 3, 3, 40, 3 },
                    { 4, 3, 90, 4 },
                    { 5, 2, 80, 1 }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Address", "CourseId", "DeptartmentId", "ImageURL", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Alex", 1, 1, "2.jpg", "Asmaa", 60000 },
                    { 2, "Alex", 2, 2, "m.png", "Ester", 50000 },
                    { 3, "Alex", 3, 3, "m.png", "Omar", 20000 },
                    { 4, "Alex", 1, 1, "2.jpg", "Heba", 30000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DeptartmentId",
                table: "Course",
                column: "DeptartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_CourseId",
                table: "CourseResult",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_TraineeId",
                table: "CourseResult",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_CourseId",
                table: "Instructor",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DeptartmentId",
                table: "Instructor",
                column: "DeptartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DeptartmentId",
                table: "Trainee",
                column: "DeptartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResult");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
