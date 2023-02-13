using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person GetById(int personId);
        string Add(Person person);
        string Delete(Person person);
        string Update(Person person);
    }
}
