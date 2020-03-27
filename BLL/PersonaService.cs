using DAL;
using Entity;
using System.Collections.Generic;
namespace BLL
{
    public class PersonaService
    {
        static PersonaRepository personaRepository = new PersonaRepository();


        public string Guardar(Persona persona)
        {
            if (personaRepository.BuscarIdentificacion(persona.Identificacion) == null)
            {
                personaRepository.Guardar(persona);

                return "Se guardó la información satisfactoriamente";
            }
            else
            {
                return "No se aceptan Identificación duplicadas";
            }
        }
        public List<Persona> Consultar()
        {
            return personaRepository.Consultar();
        }

        public string Eliminar(string identificacion)
        {
            if (personaRepository.Eliminar(identificacion))

                return $"La persona con identificacion '{ identificacion }' fué eliminado";

            else
                return $"La persona con identificacion '{identificacion}' NO se pudo eliminar";
        }

        public Persona Buscar(string identificacion)
        {
            return personaRepository.BuscarIdentificacion(identificacion);
        }

        public string Modificar(Persona persona)
        {
            Persona persona2 = personaRepository.BuscarIdentificacion(persona.Identificacion);
            if (persona != null)
            {
                personaRepository.Modificar(persona);
                return $"Se Modifucaron los datos de manera correcta";

            }

            return $"NO Se Modificaron los datos de manera correcta";
        }


    }


}
