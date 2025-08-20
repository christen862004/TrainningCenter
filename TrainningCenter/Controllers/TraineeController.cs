using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainningCenter.Models;
using TrainningCenter.ViewModels;

namespace TrainningCenter.Controllers
{
    public class TraineeController : Controller
    {
        CenterContext context=new CenterContext();
        public IActionResult Result(int Tid,int Cid)
        {
            //collect data
            CourseResult? result= context.CourseResult
                .Include(r => r.Trainee).Include(r => r.Course)
                .FirstOrDefault(r => r.TraineeId == Tid && r.CourseId == Cid);
            if (result != null) {
                //declare VM
                TraineeCourseResultViewModel ResultVM = new();
                //mapp from Source(Moddels)==>destimation(VM)
                ResultVM.TraineeId = Tid;
                ResultVM.TraineeName=result.Trainee.Name;
                ResultVM.CourseName=result.Course.Name;
                ResultVM.TraineeDegree = result.TraineeDegree;
                ResultVM.Image = result.Trainee.ImageURL;
                if (ResultVM.TraineeDegree > result.Course.MinDegree)
                {
                    ResultVM.Status = "Success";
                    ResultVM.Color = "Green";
                }
                else
                {
                    ResultVM.Status = "Fail";
                    ResultVM.Color = "Red";
                }
                //return viewModel
                return View("Result",ResultVM);
            }
            return NotFound();

        }


        public IActionResult TotalResult(int tid)
        {
            Trainee trainee = context.Trainee.FirstOrDefault(t => t.Id == tid);
            List<ColoredCourseResultViewModel> courseREsultList=context.CourseResult
                .Include(r=>r.Course).Where(r=>r.TraineeId==tid)
                .Select(r=>new ColoredCourseResultViewModel() { 
                    CrsId = r.Course.Id,
                    CrsName=r.Course.Name,
                    TraineeDegree=r.TraineeDegree,
                    Color=r.TraineeDegree>r.Course.MinDegree?"Green":"Red",
                    Status = r.TraineeDegree > r.Course.MinDegree ? "Success" : "Fail",
                }).ToList();

            AllTraineeResultViewModel traineeResults = new AllTraineeResultViewModel();
            traineeResults.CourseResults= courseREsultList;
            traineeResults.TraineeName = trainee.Name;
            traineeResults.TraineeId = trainee.Id;


            return View(traineeResults);
        }
    }
}
