using OpenTK.Mathematics;
using TareaU;
class Escenario : ObjetoGrafico
{
    public Dictionary<string, Objeto> Objetos;

    public Escenario()
    {
        Objetos = new Dictionary<string, Objeto>();
        Centro = new Vector3(0, 0, 0);
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var objeto in Objetos)
            objeto.Value.Dibujar(shader);
    }

    public override void Actualizar()
    {
        foreach (var objeto in Objetos.Values)
            objeto.Actualizar();
    }

    public void AgregarObjeto(Objeto objeto)
    {
        if (!Objetos.ContainsKey(objeto.Nombre))
            Objetos.Add(objeto.Nombre, objeto);
        else
            Console.WriteLine("El nombre del objeto ya existe en el escenario.");
    }

    public override void Rotar(Vector3 angulos, Vector3 centro)
    {
        Centro = centro;
        Rotacion = angulos;
        foreach (var objeto in Objetos.Values)
        {
            objeto.Rotar(Rotacion, Centro);
        }
    }

    public void Rotar2(Vector3 angulos, Vector3 centro)
    {
        foreach (var objeto in Objetos.Values)
        {
            objeto.Rotar2(angulos, Centro);
        }
    }

    public void Rotar3(Vector3 angulos)
    {
        foreach (var objeto in Objetos.Values)
        {
            foreach (var parte in objeto.Partes.Values)
            {
                foreach (var cara in parte.Caras.Values)
                {
                    cara.Rotar2(angulos, Centro);
                }
            }
        }
    }

    public void setRotacion(Vector3 angulos, Vector3 centro)
    {
        foreach (var objeto in Objetos.Values)
        {
            foreach (var parte in objeto.Partes.Values)
            {
                foreach (var cara in parte.Caras.Values)
                {
                    cara.Rotar(angulos, Centro - objeto.Posicion);//Desde el escenario
                    // cara.Rotacion += angulos;
                }
            }
        }
    }

    public override void Posicionar(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var objeto in Objetos.Values)
        {
            objeto.Posicion = Posicion;
        }
    }

    public override void Escalar(Vector3 escala)
    {
        Escala = escala;
        foreach (var objeto in Objetos.Values)
        {
            objeto.Escala = Escala;
        }
    }

    public override Vector3 CalcularCentro()
    {
        return Centro;
    }

}