using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PurpleCutz.Entities;
using PurpleCutz.Models;

namespace PurpleCutzApi.DataAccessLayer
{
    public class PersonRepository : IDataRepository<Person>
    {
        private readonly PurpleCutzContext _purpleCutzContext;
        public PersonRepository(PurpleCutzContext context)
        {
            _purpleCutzContext = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _purpleCutzContext.People.ToList();
        }

        public Person Get(long id)
        {
            return _purpleCutzContext.People
                .FirstOrDefault(e => e.PersonId == id);
        }

        public void Add(Person entity)
        {
            _purpleCutzContext.People.Add(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Update(Person person, Person entity)
        {
            _purpleCutzContext.Entry(person).CurrentValues.SetValues(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Delete(Person person)
        {
            _purpleCutzContext.Remove(person);
            _purpleCutzContext.SaveChanges();
        }
    }
}
