using OpenTK.Mathematics;

public class Animacion
{
    public List<Accion> Acciones { get; set; }
    public ObjetoGrafico ObjetoGrafico;
    public Animacion(List<Accion> acciones, ObjetoGrafico objetoGrafico)
    {
        Acciones = acciones;
        ObjetoGrafico = objetoGrafico;
    }

    public void Play(float tiempoGlobal, float tiempoFrame){
        foreach (var accion in Acciones)
        {
            Vector3 mover = accion.Mover(tiempoGlobal, tiempoFrame);
            //Vector3 escalar = ...
            //Vector3 rotar = ...

            ObjetoGrafico.Posicionar(mover);
            //ObjetoGrafico.Escalar(escalar);
            //ObjetoGrafico.Rotar(rotar);
            
        }
    }

    public void Stop()
    {
        //Creo que aqui tengo que detener el hilo?
        //Nota, tal vez play y stop no deben ir aqui si no en el ejecutor
        //... Por lo tanto, stop se elimina y play se cambia de nombre
    }


}