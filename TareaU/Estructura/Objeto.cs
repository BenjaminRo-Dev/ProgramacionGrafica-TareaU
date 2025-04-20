using OpenTK.Mathematics;
using TareaU;

public class Objeto : ObjetoGrafico
{
    public List<Parte> Partes;

    public Objeto(Vector3 posicion, Vector3 escala, Vector3 rotacion, List<Parte> partes)
        : base(posicion, escala, rotacion)
    {
        Partes = partes;

        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
        }
    }


    public override void Dibujar(Shader shader)
    {
        foreach (var parte in Partes)
        {
            parte.Dibujar(shader);
        }
    }

    public override void Actualizar()
    {
        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
            parte.Centro = Centro;
            parte.Actualizar();
        }
    }

    public override void Rotar(Vector3 rotacion)
    {
        CalcularCentroDeMasa();
        Rotacion = rotacion;
        foreach (var parte in Partes)
        {
            parte.setCentro(Centro);
            parte.setRotacion(Rotacion);
        }
    }

    public override void Mover(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
        }
    }

    public override void Escalar(Vector3 escala)
    {
        Escala = escala;
        foreach (var parte in Partes)
        {
            parte.Escala = Escala;
        }
    }

    public override void CalcularCentroDeMasa()
    {
        Vector3 suma = Vector3.Zero;
        int totalVertices = 0;

        foreach (var parte in Partes)
        {
            foreach (var cara in parte.Caras)
            {
                foreach (var vertice in cara.Vertices)
                {
                    suma += vertice.posicion;
                    totalVertices++;
                }
            }
        }

        Centro = suma / totalVertices;
        //Asignar el centro de masa a cada parte y cara
        foreach (var parte in Partes)
        {
            parte.Centro = Centro;
            foreach (var cara in parte.Caras)
            {
                cara.Centro = Centro;
            }
        }
    }

    public override void setPosicion(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var parte in Partes)
        {
            parte.setPosicion(Posicion);
        }
    }

    public override void setEscala(Vector3 escala)
    {
        Escala = escala;
        foreach (var parte in Partes)
        {
            parte.setEscala(Escala);
        }
    }

    public override void setRotacion(Vector3 rotacion)
    {
        Rotacion = rotacion;
        foreach (var parte in Partes)
        {
            parte.CalcularCentroDeMasa();
            parte.setRotacion(Rotacion);
        }
    }

    public override void setCentro(Vector3 centro)
    {
        Centro = centro;
        foreach (var parte in Partes)
        {
            parte.setCentro(Centro);
        }
    }

}