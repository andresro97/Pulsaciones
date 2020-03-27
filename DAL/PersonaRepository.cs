using Entity;
using System.Collections.Generic;

namespace DAL
{
    public class PersonaRepository
    {

        List<Persona> personas;
        public PersonaRepository()
        {
            personas = new List<Persona>();
        }

        public void Guardar(Persona persona)
        {
            personas.Add(persona);
        }




        public List<Persona> Consultar()
        {
            return personas;
        }

        public Persona BuscarIdentificacion(string identificacion)
        {

            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }

            }
            return null;

        }

        public bool Eliminar(string identificacion)
        {
            Persona AEliminar = BuscarIdentificacion(identificacion);
            if (AEliminar is null)
                return false;
            else
                return personas.Remove(AEliminar);


        }

        public void Modificar(Persona persona)
        {
            Eliminar(persona.Identificacion);
            Guardar(persona);

        }
    }
}
