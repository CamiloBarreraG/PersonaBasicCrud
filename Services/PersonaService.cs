using TryPactia.Models;
using TryPactia.Repositories;

namespace TryPactia.Services
{
    public interface IPersonaService{
        IEnumerable<Persona> GetAll();
        Persona Get(string cedula);
        void AddPersona(Persona persona); 
        void Edit(Persona persona);
        void Delete(string cedula);


        }
    public class PersonaService : IPersonaService
    {
        private readonly IRepoPersona _repoPersona;
        
        public PersonaService(IRepoPersona repoPersona)
        {
            _repoPersona = repoPersona;
        }
        public IEnumerable<Persona> GetAll()
        {
            
            return _repoPersona.GetAll();
        }
        public Persona Get(string cedula)
        {

            return _repoPersona.Get(cedula);
        }
        public void Edit(Persona persona)
        {

             _repoPersona.Edit(persona);
        }   
        public void Delete(string cedula)
        {
             _repoPersona.Delete(cedula);
        }

        public void AddPersona(Persona persona)
        {
             _repoPersona.AddPersona(persona);
        }
    }
}
