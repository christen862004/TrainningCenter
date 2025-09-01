using Microsoft.EntityFrameworkCore;

namespace TrainningCenter.Models
{
    public class CenterContext:DbContext
    {
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CourseResult> CourseResult { get; set; }
        public CenterContext()
        {
            
        }
        public CenterContext(DbContextOptions<CenterContext> options):base(options)
        {
            
        }
        //DB option
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TrainningCenter;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department() {Id=1,Name=".Net",ManagerName="Ahmed" });
            modelBuilder.Entity<Department>().HasData(new Department() {Id=2,Name="OS",ManagerName="Abdallah" });
            modelBuilder.Entity<Department>().HasData(new Department() {Id=3,Name="FrontEnd",ManagerName="Faysal" });

            modelBuilder.Entity<Course>().HasData(new Course(){Id=1,Name="C#",Degree=100,MinDegree=50,Hours=60,DeptartmentId=1 });
            modelBuilder.Entity<Course>().HasData(new Course(){Id=2,Name="PHP",Degree=100,MinDegree=50,Hours=60,DeptartmentId=2 });
            modelBuilder.Entity<Course>().HasData(new Course(){Id=3,Name="Angular",Degree=100,MinDegree=50,Hours=60,DeptartmentId=3 });

            modelBuilder.Entity<Instructor>().HasData(new Instructor() {Id=1,Name="Asmaa",ImageURL="2.jpg",Address="Alex",DeptartmentId=1,CourseId=1,Salary=60000});
            modelBuilder.Entity<Instructor>().HasData(new Instructor() {Id=2,Name="Ester",ImageURL="m.png",Address="Alex",DeptartmentId=2,CourseId=2,Salary=50000});
            modelBuilder.Entity<Instructor>().HasData(new Instructor() {Id=3,Name="Omar",ImageURL="m.png",Address="Alex",DeptartmentId=3,CourseId=3,Salary=20000});
            modelBuilder.Entity<Instructor>().HasData(new Instructor() {Id=4,Name="Heba",ImageURL="2.jpg",Address="Alex",DeptartmentId=1,CourseId=1,Salary=30000});

            modelBuilder.Entity<Trainee>().HasData(new Trainee() {Id=1,Name="Karem", Address="Alex",ImageURL="m.png",DeptartmentId=1});
            modelBuilder.Entity<Trainee>().HasData(new Trainee() {Id=2,Name="MOhsen", Address="Alex",ImageURL="m.png",DeptartmentId=2});
            modelBuilder.Entity<Trainee>().HasData(new Trainee() {Id=3,Name="Mona", Address="Alex",ImageURL="2.jpg",DeptartmentId=3});
            modelBuilder.Entity<Trainee>().HasData(new Trainee() {Id=4,Name="Fatma", Address="Alex",ImageURL="2.jpg",DeptartmentId=1});

            modelBuilder.Entity<CourseResult>().HasData(new CourseResult() { Id=1,TraineeId=1,CourseId=1,TraineeDegree=40});
            modelBuilder.Entity<CourseResult>().HasData(new CourseResult() { Id=2,TraineeId=2,CourseId=2,TraineeDegree=80});
            modelBuilder.Entity<CourseResult>().HasData(new CourseResult() { Id=3,TraineeId=3,CourseId=3,TraineeDegree=40});
            modelBuilder.Entity<CourseResult>().HasData(new CourseResult() { Id=4,TraineeId=4,CourseId=3,TraineeDegree=90});
            modelBuilder.Entity<CourseResult>().HasData(new CourseResult() { Id=5,TraineeId=1,CourseId=2,TraineeDegree=80});

        }

    }
}
