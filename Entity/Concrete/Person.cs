using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Person: IEntity
    {
        [Key]
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
