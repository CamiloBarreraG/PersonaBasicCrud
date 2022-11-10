using TryPactia.Models;

namespace TryPactia.Repositories
{
    public interface IRepoPersona
    {
        IEnumerable<Persona> GetAll();
        Persona Get(string cedula);
        void AddPersona(Persona persona);
        void Edit(Persona persona);
        void Delete(string cedula);
    }
    public class RepoPersona:IRepoPersona
    {
        private readonly PersonaContext db;

        public RepoPersona(PersonaContext db)
        {
            this.db = db;
        }

        public void Delete(string cedula)
        {
            try { 
                var personaEliminar = db.Persona.Where(persona => persona.Cedula == cedula).FirstOrDefault();
                if (personaEliminar != null)
                {
                    db.Remove(personaEliminar);
                    db.SaveChanges();
                }
                else
                {
                    throw new NullReferenceException("Esta persona no existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Edit(Persona persona)
        {
            try { 
                var personaEditar = db.Persona.Where(personaDB => personaDB.Cedula == persona.Cedula).FirstOrDefault();
                if (personaEditar!=null)
                {
                    personaEditar.Apellido = persona.Apellido;
                    personaEditar.Nombre = persona.Nombre;
                    db.Entry(personaEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new NullReferenceException("Esta persona no existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Persona Get(string cedula)
        {
            try { 
            return db.Persona.Where(persona=>persona.Cedula==cedula).FirstOrDefault()??new Persona();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Persona> GetAll()
        {
            try { 
                return db.Persona.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            
        public void AddPersona(Persona persona)
        {
            try
            {
                db.Persona.Add(persona);
                db.SaveChanges();
            }
            
            catch (Exception)   
            {
                throw new Exception("El documento registrado ya se encuentra guardado");
            }
        }
    }
}
