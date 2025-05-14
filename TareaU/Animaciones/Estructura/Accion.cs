using OpenTK.Mathematics;

public class Accion{

    private float TInicial, TDuracion, TTranscurrido;
    private Vector3 Destino;
    private float velocidad;

    private Vector3 direccion;
    float distancia;

    Vector3 PosActual;
    



    public Accion(float tInicial, Vector3 posActual, float tDuracion, Vector3 destino)
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

    /*Nota: 
    hay un error actualmente, la posición inicial o final no la esta tomando en cuenta,
    solo suma la posicion actual a la posicion del destino, no la asigna
    creo que es porque la estoy llamando desde onUpdate,
    asi que puede que se solucione al hacer la llamada desde el hilo 2
    */

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
        }else{
            return Vector3.Zero;
        }
        return PosActual;
    }
}