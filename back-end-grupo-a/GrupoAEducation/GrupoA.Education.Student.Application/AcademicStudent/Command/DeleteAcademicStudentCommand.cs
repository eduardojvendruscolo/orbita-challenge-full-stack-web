using System;
using GrupoA.Education.Student.Application.AcademicStudent.interfaces;

namespace GrupoA.Education.Student.Application.AcademicStudent.Command
{
    public class DeleteAcademicStudentCommand: ICommand<bool>
    {
        public Guid PrimaryKey { get; private set; }
        
        public DeleteAcademicStudentCommand(Guid primaryKey)
        {
            PrimaryKey = primaryKey;
        }        
    }
}