using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Drawing;
using TrainningCenter.Models;
using TrainningCenter.ViewModels;

namespace TrainningCenter.Controllers
{
    public class InstructorController : Controller
    {
        CenterContext context=new CenterContext();

        public IActionResult Index()//int pageno=1,int pagesize=10)
        {
            //  context.Instructor.Skip(0).Take(10)//page 1
            //  context.Instructor.Skip(10).Take(10)//page 2

            //context.Instructor.Skip((pageno - 1)*pagesize).Take(10).ToList
            List<Instructor> InstructorList= context.Instructor.ToList();
            return View("Index",InstructorList);
            //view Index ,Model : List<instructor>
        }


        #region New
        public IActionResult New()
        {
            List<Department> deptList=context.Department.ToList();
            List<Course> courseList=context.Course.ToList();

            NewInstructorViewModel instructorViewModel = new NewInstructorViewModel();
            instructorViewModel.DeptList = deptList;
            instructorViewModel.CourseList = courseList;

            return View("New",instructorViewModel);//Give Viewname Only
            //return View();//search view with the same action name "NEw"
            
            //return View("New",obj);//Give Viewname ,Model obj
            //return View(obj);//search view with the same action name "NEw" , Model obj
        }

        [HttpPost]
        public IActionResult SaveNew(NewInstructorViewModel NewInstructorVM)
        {
            if (NewInstructorVM.Name != null)
            {
                //automapper
                Instructor newInstructor = new Instructor() { 
                Name=NewInstructorVM.Name,
                Salary=NewInstructorVM.Salary,
                ImageURL=NewInstructorVM.ImageURL,
                DeptartmentId=NewInstructorVM.DeptartmentId,
                CourseId=NewInstructorVM.CourseId,
                Address=NewInstructorVM.Address   
                };
                context.Instructor.Add(newInstructor);
                context.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
            NewInstructorVM.DeptList=context.Department.ToList();
            NewInstructorVM.CourseList=context.Course.ToList();
            return View("New", NewInstructorVM);
        }
        #endregion
    }
}
