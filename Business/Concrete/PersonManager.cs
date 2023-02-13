using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public string Add(Person person)
        {
            _personDal.Add(person);
            return "Ekleme Başarılı";
        }

        public string Delete(Person person)
        {
            _personDal.Delete(person);

            return "Silme Başarılı";
        }

        public List<Person> GetAll()
        {
            return _personDal.GetAll();
        }

        public Person GetById(int personId)
        {
            return _personDal.Get(x => x.PersonId == personId);
        }

        public string Update(Person person)
        {
            _personDal.Update(person);
            return "Güncelleme Başarılı";
        }
    }
}
