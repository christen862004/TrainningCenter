using System.ComponentModel.DataAnnotations;
using TrainningCenter.ViewModels;

namespace TrainningCenter.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CenterContext context = new CenterContext();

            string name = value.ToString();
            NewCourseViewModel? crsFRomReq=validationContext.ObjectInstance as NewCourseViewModel;

            //NEw (id=0)
            //Edit (id !=0)
            Course crsFRomB= context.Course
                .FirstOrDefault(c => c.Name == name && c.Id != crsFRomReq.Id);
            if (crsFRomB == null)
                return ValidationResult.Success;
            return new ValidationResult("Course NAme Already Found");



        }
    }
}
