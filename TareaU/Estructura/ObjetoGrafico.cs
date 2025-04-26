using OpenTK.Mathematics;
using TareaU;

public abstract class ObjetoGrafico
{
    public string Nombre { get; set; }
    public virtual Vector3 Posicion { get; set; }
    public virtual Vector3 Escala { get; set; }
    public virtual Vector3 Rotacion { get; set; }
    public virtual Vector3 Centro { get; set;}

    public virtual Dictionary<string, Objeto> Objetos { get; set; }
    public virtual Dictionary<string, Parte> Partes { get; set; }
    public virtual Dictionary<string, Cara> Caras { get; set; }
    public virtual Dictionary<string, Vertice> Vertices { get; set; }
    
    public ObjetoGrafico()
    {
        Posicion = Vector3.Zero;
        Escala = Vector3.One;
        Rotacion = Vector3.Zero;
    }

    public abstract void Dibujar(Shader shader);
    public abstract void Posicionar(Vector3 posicion);
    public abstract void Escalar(float escala, Vector3? centro = null);
    public abstract void Rotar(Vector3 angulos, Vector3? centro = null);
    public abstract Vector3 CalcularCentro();

    public virtual void AgregarObjeto(Objeto objeto){}
    

    


    

    

}