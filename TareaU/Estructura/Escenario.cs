using OpenTK.Mathematics;
using TareaU;
public class Escenario : ObjetoGrafico
{

    public Escenario(string nombre)
    {
        Nombre = nombre;
        Objetos = new Dictionary<string, Objeto>();
        Centro = new Vector3(0, 0, 0);
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var objeto in Objetos)
            objeto.Value.Dibujar(shader);
    }

    public override void AgregarObjeto(Objeto objeto)
    {
        if (!Objetos.ContainsKey(objeto.Nombre))
            Objetos.Add(objeto.Nombre, objeto);
        else
        {
            Console.WriteLine("El nombre del objeto ya existe en el escenario.");
        }
    }


    public override void Rotar(Vector3 angulos, Vector3? centro = null)
    {
        foreach (var objeto in Objetos.Values)
        {
            objeto.Rotar(angulos, Centro);
        }
    }

    public override void Posicionar(Vector3 posicion)
    {
        foreach (var objeto in Objetos.Values)
        {
            objeto.Posicionar(posicion);
        }
    }

    public override void Escalar(float escala, Vector3? centro = null)
    {
        foreach (var objeto in Objetos.Values)
        {
            objeto.Escalar(escala, null);
        }
    }

    public override Vector3 CalcularCentro()
    {
        return Centro;
    }

}