using OpenTK.Mathematics;

public class Animacion
{
    public ObjetoGrafico ObjetoGrafico;
    public List<Accion> Acciones { get; set; }
    public Animacion(ObjetoGrafico objetoGrafico, List<Accion> acciones)
    {
        ObjetoGrafico = objetoGrafico;
        Acciones = acciones;
    }

    public void Play(float tiempoGlobal, float tiempoFrame){
        foreach (var accion in Acciones)
        {
            // Vector3 acc = accion.Transformar(tiempoGlobal, tiempoFrame);

            if (accion.Tipo == "posicionar")
                ObjetoGrafico.Posicionar(accion.Transformar(tiempoGlobal, tiempoFrame));

            if (accion.Tipo == "rotar")
                ObjetoGrafico.Rotar(accion.Transformar(tiempoGlobal, tiempoFrame));

            if (accion.Tipo == "escalar")
                ObjetoGrafico.Escalar(accion.Escalar(tiempoGlobal, tiempoFrame));
            //ObjetoGrafico.Escalar(escalar);
            // Console.WriteLine("Animacion:" + tiempoFrame, ObjetoGrafico.Nombre);
        }
    }

    public void Stop()
    {
        //Creo que aqui tengo que detener el hilo?
        //Nota, tal vez play y stop no deben ir aqui si no en el ejecutor
        //... Por lo tanto, stop se elimina y play se cambia de nombre
    }


}