using System;
using GrupoA.Education.Student.Domain.Generic.Entities;

namespace GrupoA.Education.Student.Domain.Student.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public int Ra { get; set; }
        
        //Individual Taxpayer Identification Number
        public string Itin { get; set; }
        
        protected Student()
        {
        }
        
        public Student(Guid id, string name, string mail, int ra, string itin) : base(id)
        {
            PrimaryKey = id;
            Name = name;
            Mail = mail;
            Ra = ra;
            Itin = itin;
        }        
    }
}