

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainningCenter.Models;

namespace TrainningCenter.ViewModels
{
    public class NewCourseViewModel
    {
        public int Id { get; set; }

        [MinLength(2,ErrorMessage="Name Must be More thna 2 Letter")]
        [MaxLength(25,ErrorMessage ="Name Must be Less Than 25 Letter")]
        [Unique]//New | Edit
        public string Name { get; set; }

        [Remote("DividedBy3","Course",ErrorMessage ="Course Hours Must be Enable divided By 3")]
        public int Hours { get; set; }
        
        [Remote("CheckMinDegree","Course",AdditionalFields ="Degree",ErrorMessage ="Min Degree Must be Less Than Degree")]
        public int MinDegree { get; set; }
        
        [Range(50,100)]
        public int Degree { get; set; }
        
        [Display(Name="Department")]
        public int DeptartmentId { get; set; }

        public List<Department>? DeptList { get; set; }
    }
}
