using OpenTK.Mathematics;
using TareaU;
class Escenario : ObjetoGrafico
{
    public List<ObjetoGrafico> Objetos; // Lista de objetos en el escenario

    public Escenario()
    {
        Objetos = new List<ObjetoGrafico>();
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var objeto in Objetos)
        {
            objeto.Dibujar(shader);
        }
    }

    public override void Actualizar()
    {
        foreach (var objeto in Objetos)
        {
            objeto.Actualizar();
        }
    }

    public void AgregarObjeto(ObjetoGrafico objeto)
    {
        Objetos.Add(objeto);
    }

    public override void Rotar(Vector3 rotacion)
    {
        this.Rotacion = rotacion;
        foreach (var objeto in Objetos)
        {
            objeto.Rotacion = Rotacion;
        }
    }

    public override void Mover(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var objeto in Objetos)
        {
            objeto.Posicion = Posicion;
        }
    }

    public override void Escalar(Vector3 escala)
    {
        Escala = escala;
        foreach (var objeto in Objetos)
        {
            objeto.Escala = Escala;
        }
    }




}