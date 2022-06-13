using AutoMapper;
using GrupoA.Education.Student.Application.AcademicStudent.Command;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;

namespace GrupoA.Education.Student.Application.AcademicStudent.Mappings
{
    public class StudentAutoMapper: Profile
    {
        public StudentAutoMapper()
        {
            CreateMap<Domain.Student.Entities.Student, AcademicStudentViewModel>();
            CreateMap<InsertAcademicStudentCommand, Domain.Student.Entities.Student>();
        }
    }
}