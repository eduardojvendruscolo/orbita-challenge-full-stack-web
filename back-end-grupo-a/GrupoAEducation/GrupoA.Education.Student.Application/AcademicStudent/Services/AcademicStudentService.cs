using System;
using System.Threading.Tasks;
using GrupoA.Education.Student.Application.Resources;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Domain.Interfaces;
using GrupoA.Education.Student.Infra.Data.Uow;

namespace GrupoA.Education.Student.Application.AcademicStudent.Services
{
    public class AcademicStudentService : IAcademicStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationContext _notificationContext;
        
        public AcademicStudentService(IUnitOfWork uow, INotificationContext notificationContext)
        {
            _uow = uow;
            _notificationContext = notificationContext;
        }        
        
        public async Task AcademicStudenAlreadyExists(int ra, string itin, string mail)
        {
            var academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Ra.Equals(ra));
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithRaAlreadyExists), 
                    String.Format(Messages.StudentWithRaAlreadyExists, academicStudent.Name, ra)); 
            }
            
            academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Itin.Equals(itin));
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithItinAlreadyExists), 
                    String.Format(Messages.StudentWithItinAlreadyExists, academicStudent.Name, itin)); 
            }            
               
            academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Mail.Equals(mail));
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithMailAlreadyExists), 
                    String.Format(Messages.StudentWithMailAlreadyExists, academicStudent.Name, mail)); 
            }
        }

        public async Task AnotherStudenAlreadyExists(int ra, string itin, string mail, Guid primaryKey)
        {
            var academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Ra.Equals(ra) && p.PrimaryKey != primaryKey);
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithRaAlreadyExists), 
                    String.Format(Messages.StudentWithRaAlreadyExists, academicStudent.Name, ra)); 
            }
            
            academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Itin.Equals(itin) && p.PrimaryKey != primaryKey);
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithItinAlreadyExists), 
                    String.Format(Messages.StudentWithItinAlreadyExists, academicStudent.Name, itin)); 
            }            
               
            academicStudent = await _uow.Students.FirstOrDefaultAsync(p => p.Mail.Equals(mail) && p.PrimaryKey != primaryKey);
            if (academicStudent != null)
            {
                _notificationContext.BadRequest(nameof(Messages.StudentWithMailAlreadyExists), 
                    String.Format(Messages.StudentWithMailAlreadyExists, academicStudent.Name, mail)); 
            }
        }
        
        public bool IsBrazilianItinValid(string Itin)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            Itin = Itin.Trim();
            Itin = Itin.Replace(".", "").Replace("-", "");
            if (Itin.Length != 11)
                return false;
            tempCpf = Itin.Substring(0, 9);
            soma = 0;

            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if ( resto < 2 )
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return Itin.EndsWith(digito);
        }        
    }
}