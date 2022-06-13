using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoA.Education.Student.Domain.Generic.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid PrimaryKey { get; set; }

        protected BaseEntity()
        {
        }

        protected BaseEntity(Guid primaryKey)
        {
            PrimaryKey = primaryKey;
        }        
    }
}