using OpenTK.Mathematics;

namespace TareaU.Animaciones.Datos
{
    public class Grabacion
    {
        public static List<Accion> AccionesAuto1()
        {
            float k = 1.5f;
            return new List<Accion>
            {
                new("escalar", 16, 1, 2f),
                // new("escalar", 3, 1, -2),
                new("posicionar", 1, Vector3.Zero, 5 * k, new Vector3(0, 0, -19)),
                new("posicionar", 6 * k, new Vector3(0, 0, -19), 1.5f * k, new Vector3(-2, 0, -21)),
                new("rotar", 6f * k, Vector3.Zero, 1.5f * k, new Vector3(0, 90, 0)),
                new("posicionar", 7.5f * k, new Vector3(-2, 0, -21), 5 * k, new Vector3(-20, 0, -21)),
                new("posicionar", 12.5f * k, new Vector3(-20, 0, -21), 1.5f * k, new Vector3(-22, 0, -19)),
                new("rotar", 12.5f * k, Vector3.Zero, 1.5f * k, new Vector3(0, 90, 0)),
                new("posicionar", 14f * k, new Vector3(-22, 0, -19), 5 * k, new Vector3(-22, 0, 0))
            };
        }

        public static List<Accion> AccionesAuto2()
        {
            float k = 1f;
            return new List<Accion>
            {
                // new("escalar", 16, 1, 2f),
                // new("escalar", 3, 1, -2),
                new("posicionar", 1, Vector3.Zero, 5 * k, new Vector3(0, 0, -21)),

                new("posicionar", 6 * k, new Vector3(0, 0, -21), 1.5f * k, new Vector3(-2, 0, -23)),
                new("rotar", 6f * k, Vector3.Zero, 1.5f * k, new Vector3(0, 90, 0)),

                new("posicionar", 8f * k, new Vector3(-2, 0, -23), 5 * k, new Vector3(-27, 0, -23)),

                new("posicionar", 12.5f * k, new Vector3(-27, 0, -23), 1.5f * k, new Vector3(-27, 0, -19)),
                new("rotar", 12.5f * k, Vector3.Zero, 1.5f * k, new Vector3(0, 90, 0)),

                new("posicionar", 14f * k, new Vector3(-27, 0, -19), 5 * k, new Vector3(-27, 0, 0))
            };
        }

        public static List<Animacion> ListaAnimaciones(ObjetoGrafico auto1, ObjetoGrafico auto2)
        {
            return new List<Animacion>
            {
                new(auto1, AccionesAuto1()),
                new(auto2, AccionesAuto2())
            };
        }

        public static Escena GetEscena(ObjetoGrafico auto1, ObjetoGrafico auto2)
        {
            Escena escena = new Escena();
            escena.Animaciones = ListaAnimaciones(auto1, auto2);
            return escena;
        }


    }
}