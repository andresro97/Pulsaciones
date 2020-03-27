using BLL;
using Entity;
using System;
namespace PulsacionesUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonaService personaService = new PersonaService();
            ConsoleKeyInfo opcion;

            void Guardar()
            {

                do
                {

                    Persona persona = new Persona();

                    Console.WriteLine("Digite su identificacion");
                    persona.Identificacion = Console.ReadLine();
                    Console.WriteLine("Digite su nombre");
                    persona.Nombre = Console.ReadLine();
                    Console.WriteLine("Digite su sexo");
                    persona.Sexo = Console.ReadLine();
                    Console.WriteLine("Digite su edad");
                    persona.Edad = Int16.Parse(Console.ReadLine());

                    persona.CalcularPulsacion();

                    Console.WriteLine(personaService.Guardar(persona));

                    Console.WriteLine("Desea Continuar S/N:");
                    Console.WriteLine("");
                    opcion = Console.ReadKey();


                } while (opcion.KeyChar == 'S' || opcion.KeyChar == 's');

                Console.Clear();
            }

            void Consultar()
            {
                foreach (var item in personaService.Consultar())
                {
                    Console.WriteLine($" Identificacion: {item.Identificacion}    Nomnre:{item.Nombre}      Edad {item.Edad}     Sexo {item.Sexo}     pulsacion {item.Pulsacion} ");

                }
                Console.ReadKey();
            }


            void BuscarPorIdentificacion()
            {
                Console.WriteLine("Digite una identificacion para ver datos");

                string identificacion = Console.ReadLine();

                Console.WriteLine($" Identificacion: {personaService.Buscar(identificacion).Identificacion}    Nomnre:{personaService.Buscar(identificacion).Nombre}      Edad {personaService.Buscar(identificacion).Edad}     Sexo {personaService.Buscar(identificacion).Sexo}     pulsacion {personaService.Buscar(identificacion).Pulsacion} ");
                Console.ReadKey();

            }

            void EliminarPorIdentificacion()
            {
                Console.WriteLine("Digite una identificacion para eliminar");
                string identificacionEliminar = Console.ReadLine();
                Console.WriteLine(personaService.Eliminar(identificacionEliminar));
            }

            void Modificar()
            {

                Console.WriteLine("Digite identificaion para modificar datos");
                string identificacionModificar = Console.ReadLine();
                Persona PersonaVieja = personaService.Buscar(identificacionModificar);
                if (PersonaVieja is null)
                {
                    Console.WriteLine("No exite persona");
                    Console.ReadKey();
                }
                else
                {

                    Console.WriteLine(PersonaVieja.ToString());
                    Console.ReadKey();
                    Persona persona2 = new Persona();
                    persona2.Identificacion = PersonaVieja.Identificacion;
                    Console.WriteLine("Digite su nombre");
                    persona2.Nombre = Console.ReadLine();
                    Console.WriteLine("Digite su sexo");
                    persona2.Sexo = Console.ReadLine();
                    Console.WriteLine("Digite su edad");
                    persona2.Edad = Int16.Parse(Console.ReadLine());
                    persona2.CalcularPulsacion();
                    personaService.Modificar(persona2);
                }
            }


            int salirDoWhile = 1;
            do
            {
                string convertCaseSwitch;
                int caseSwitch;
                Console.Clear();
                Console.WriteLine("1. Guardar datos");
                Console.WriteLine("2. Ver Datos guardados");
                Console.WriteLine("3. Buscar por Identificacion");
                Console.WriteLine("4. Eliminar (Por Identificacion)");
                Console.WriteLine("5. Modificar");
                Console.WriteLine("6. salir");
                Console.Write("");
                Console.Write("Escoja una opcion:");
                convertCaseSwitch = Console.ReadLine();
                caseSwitch = int.Parse(convertCaseSwitch);

                switch (caseSwitch)
                {
                    case 1:
                        Guardar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        BuscarPorIdentificacion();
                        break;
                    case 4:
                        EliminarPorIdentificacion();
                        break;
                    case 5:
                        Modificar();
                        break;
                    case 6:
                        salirDoWhile = 2;
                        break;
                    default:
                        Console.WriteLine("NO ES UNA OPCION VALIDA");
                        break;
                }


            } while (salirDoWhile == 1);


        }

    }

}/**/
