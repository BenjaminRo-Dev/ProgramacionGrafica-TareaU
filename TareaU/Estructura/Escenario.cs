using OpenTK.Mathematics;
using TareaU;
class Escenario : ObjetoGrafico
{
    public List<ObjetoGrafico> Objetos; // Lista de objetos en el escenario
    
    public Escenario()
    {
        Objetos = new List<ObjetoGrafico>();
        Centro = new Vector3(0, 0, 0);
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
        // CalcularCentroDeMasa();
        Centro = Posicion;
        Rotacion = rotacion;
        foreach (var objeto in Objetos)
        {
            objeto.setCentro(Centro - objeto.Posicion);
            // objeto.setRotacion(objeto.Rotacion + Rotacion);
            objeto.setRotacion(Rotacion);
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

    public override void CalcularCentroDeMasa()
    {
        Centro = Posicion;
    }

    public override void setPosicion(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var objeto in Objetos)
        {
            objeto.setPosicion(Posicion);
        }
    }

    public override void setEscala(Vector3 escala)
    {
        Escala = escala;
        foreach (var objeto in Objetos)
        {
            objeto.setEscala(Escala);
        }
    }

    public override void setRotacion(Vector3 rotacion)
    {
        Rotacion = rotacion;
        foreach (var objeto in Objetos)
        {
            objeto.setRotacion(Rotacion);
        }
    }

    public override void setCentro(Vector3 centro)
    {
        Centro = centro;
        foreach (var objeto in Objetos)
        {
            objeto.setCentro(Centro);
        }
    }




}