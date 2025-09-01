using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainningCenter.Models;
using TrainningCenter.Reposiotry;
using TrainningCenter.ViewModels;

namespace TrainningCenter.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepo;
        private readonly IDepartmentRepository depRepo;

        public CourseController(ICourseRepository courseRepo,IDepartmentRepository depRepo)
        {
            this.courseRepo = courseRepo;
            this.depRepo = depRepo;
        }
        public IActionResult Index()
        {
            List<Course> courses = courseRepo.GetAll("Department");
            
            List<CourseWithDepNameViewModel> courseList=
                courses.Select(c => new CourseWithDepNameViewModel()
                {
                    CourseId = c.Id, DeptName = c.Department.Name, CourseName = c.Name })
                .ToList();
            return View("Index",courseList);
        }

        public IActionResult New()
        {
            //collect
            List<Department> deptList = depRepo.GetAll();
            //declare
            
            NewCourseViewModel crsVM = new NewCourseViewModel();
            //mapping
            crsVM.DeptList= deptList;

            return View("New", crsVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(NewCourseViewModel crsVMFromRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Course crs = new Course()
                    {
                        Name = crsVMFromRequest.Name,
                        Hours = crsVMFromRequest.Hours,
                        Degree = crsVMFromRequest.Degree,
                        MinDegree = crsVMFromRequest.MinDegree,
                        DeptartmentId = crsVMFromRequest.DeptartmentId
                    };
                    courseRepo.Add(crs);
                    courseRepo.Save();
                    return RedirectToAction("Index", "Course");
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);

                }
            }
            crsVMFromRequest.DeptList = depRepo.GetAll();
            return View("New", crsVMFromRequest);
        }


        public IActionResult CheckMinDegree(int MinDegree,int Degree)
        {
            return Json(MinDegree < Degree);
        }

        public IActionResult DividedBy3(int Hours)
        {
            return Json(Hours % 3==0);
        }
    }
}
