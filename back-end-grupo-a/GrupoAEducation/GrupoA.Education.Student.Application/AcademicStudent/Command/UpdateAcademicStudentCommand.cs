using System;
using GrupoA.Education.Student.Application.AcademicStudent.interfaces;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;

namespace GrupoA.Education.Student.Application.AcademicStudent.Command
{
    public class UpdateAcademicStudentCommand: ICommand<AcademicStudentViewModel>
    {
        public Guid PrimaryKey { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public int Ra { get; set; }
        //Individual Taxpayer Identification Number
        public string Itin { get; set; }        
        
        public UpdateAcademicStudentCommand SetKey(Guid id)
        {
            PrimaryKey = id;
            return this;
        }        
    }
}