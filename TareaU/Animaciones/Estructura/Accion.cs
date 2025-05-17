using OpenTK.Mathematics;

public class Accion
{

    private float TInicial, TDuracion, TTranscurrido;
    private Vector3 Destino;
    private float Velocidad;
    private Vector3 Direccion;
    float Distancia;
    Vector3 PosActual;
    float Escala;
    public string Tipo;

    public Accion(string tipo, float tInicial, Vector3 posActual, float tDuracion, Vector3 destino)
    {
        Tipo = tipo;
        TInicial = tInicial;
        TDuracion = tDuracion;
        Destino = destino;
        PosActual = posActual;

        TTranscurrido = 0f;

        Direccion = Vector3.Normalize(Destino - PosActual);
        Distancia = Vector3.Distance(Destino, PosActual);
        Velocidad = Distancia / tDuracion;
    }

    public Accion(string tipo, float tInicial, float tDuracion, float escala)
    {
        Tipo = tipo;
        TInicial = tInicial;
        Escala = 0.0001f / escala;
        TDuracion = tDuracion;

        Velocidad = Escala / TDuracion;
    }

    public Vector3 Transformar(float tiempoGlobal, float tFrame)
    {
        if (tiempoGlobal >= TInicial)
        {
            if (TTranscurrido < TDuracion)
            {
                float distanciaFrame = Velocidad * tFrame;
                PosActual = Direccion * distanciaFrame;
                TTranscurrido += tFrame;
            }
            else return Vector3.Zero;
        }
        else return Vector3.Zero;

        return PosActual;
    }

    public float Escalar(float tiempoGlobal, float tFrame)
    {
        if (tiempoGlobal >= TInicial)
        {
            if (TTranscurrido < TDuracion)
            {
                float progreso = TTranscurrido / TDuracion;
                Escala = 1 + (Velocidad * progreso);
                TTranscurrido += tFrame;
            }
            else return 1;
        }
        else return 1;

        return Escala;
    }


}