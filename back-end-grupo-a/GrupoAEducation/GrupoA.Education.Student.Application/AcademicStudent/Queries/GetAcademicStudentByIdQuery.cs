using System;
using GrupoA.Education.Student.Application.AcademicStudent.ViewModels;
using MediatR;

namespace GrupoA.Education.Student.Application.AcademicStudent.Queries
{
    public class GetAcademicStudentByIdQuery : IRequest<AcademicStudentViewModel>
    {
        public Guid Id { get; private set; }
        
        public GetAcademicStudentByIdQuery(Guid id)
        {
            Id = id;
        }        
    }
}