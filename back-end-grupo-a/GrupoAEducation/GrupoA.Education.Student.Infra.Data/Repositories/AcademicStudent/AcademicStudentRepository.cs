using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GrupoA.Education.Student.Domain.Student.Interfaces;
using GrupoA.Education.Student.Infra.Data.Context;
using GrupoA.Education.Student.Infra.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrupoA.Education.Student.Infra.Data.Repositories.AcademicStudent
{
    public class AcademicStudentRepository: Repository<Domain.Student.Entities.Student, EducationDbContext>, IStudentRepository
    {
        public AcademicStudentRepository(EducationDbContext context) : base(context)
        {
        }

        public IQueryable<Domain.Student.Entities.Student> GetAll(string filter, string orderByField, string orderType = "asc")
        {
            var studentGetAllQuery = _context.Students.AsNoTracking();
            
            if (!string.IsNullOrEmpty(filter))
                studentGetAllQuery = studentGetAllQuery.Where(
                    student => student.Name.ToLower().Contains(filter.ToLower())
                    || student.Itin.ToLower().Contains(filter.ToLower())
                    || student.Mail.ToLower().Contains(filter.ToLower())
                    || student.Ra.ToString().Contains(filter.ToLower()));
            
            if (!string.IsNullOrEmpty(orderByField))
            {
                switch (orderByField)
                {
                    case "name":
                    {
                        if (orderType == "asc")
                            studentGetAllQuery = studentGetAllQuery.OrderBy(s => s.Name.ToLower());
                        else
                            studentGetAllQuery = studentGetAllQuery.OrderByDescending(s => s.Name.ToLower());
                    } break;
                    
                    case "itin":
                    {
                        if (orderType == "asc")
                            studentGetAllQuery = studentGetAllQuery.OrderBy(s => s.Itin);
                        else
                            studentGetAllQuery = studentGetAllQuery.OrderByDescending(s => s.Itin);
                    } break;   
                    
                    case "mail":
                    {
                        if (orderType == "asc")
                            studentGetAllQuery = studentGetAllQuery.OrderBy(s => s.Mail.ToLower());
                        else
                            studentGetAllQuery = studentGetAllQuery.OrderByDescending(s => s.Mail.ToLower());
                    } break;       
                    
                    case "ra":
                    {
                        if (orderType == "asc")
                            studentGetAllQuery = studentGetAllQuery.OrderBy(s => s.Ra);
                        else
                            studentGetAllQuery = studentGetAllQuery.OrderByDescending(s => s.Ra);
                    } break;                      
                                
                }
            }

            return studentGetAllQuery;
        }

        public int GetNextRaNumber()
        {
            var maxRaNumber = _context.Students.Max(s => s.Ra);
            return ++maxRaNumber;
        }
    }
}