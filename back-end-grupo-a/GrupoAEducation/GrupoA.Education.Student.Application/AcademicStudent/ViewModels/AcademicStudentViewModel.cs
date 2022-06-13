using GrupoA.Education.Student.Common.ViewModel;

namespace GrupoA.Education.Student.Application.AcademicStudent.ViewModels
{
    public class AcademicStudentViewModel : BaseViewModel
    {
        //Key
        public int Ra { get; set; }
        
        public string Name { get; set; }
        public string Itin { get; set; }
        public string Mail { get; set; }
    }
}