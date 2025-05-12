using OpenTK.Mathematics;

public class Accion{

    private float TInicial, TDuracion, TTranscurrido;
    private Vector3 Destino;
    private float velocidad;

    private Vector3 direccion;
    float distancia;

    Vector3 PosActual;
    



    public Accion(float tInicial,float tDuracion, Vector3 destino, Vector3 posActual)
    {
        TInicial = tInicial;
        TDuracion = tDuracion;
        Destino = destino;
        PosActual = posActual;

        TTranscurrido = 0f;
        
        direccion = Vector3.Normalize(Destino - PosActual);
        distancia = Vector3.Distance(Destino, PosActual);
        velocidad = distancia / tDuracion;
    }

    public Vector3 Mover(float tiempoGlobal, float tFrame)
    {
        if(tiempoGlobal >= TInicial)
        {
            if(TTranscurrido < TDuracion){
                float distanciaFrame = velocidad * tFrame;
                PosActual = direccion * distanciaFrame;
                TTranscurrido += tFrame;
            }
            else{
                return Vector3.Zero;
            }
        }
        return PosActual;
    }
}