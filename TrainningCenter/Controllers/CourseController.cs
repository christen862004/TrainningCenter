using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainningCenter.Models;
using TrainningCenter.ViewModels;

namespace TrainningCenter.Controllers
{
    public class CourseController : Controller
    {
        CenterContext context=new CenterContext();
        public IActionResult Index()
        {
            List<CourseWithDepNameViewModel> courseList=
                context.Course.Include(c => c.Department)
                .Select(c => new CourseWithDepNameViewModel()
                {
                    CourseId = c.Id, DeptName = c.Department.Name, CourseName = c.Name })
                .ToList();
            return View("Index",courseList);
        }

        public IActionResult New()
        {
            //collect
            List<Department> deptList = context.Department.ToList();
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
                    context.Course.Add(crs);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Course");
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);

                }
            }
            crsVMFromRequest.DeptList= context.Department.ToList();
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
