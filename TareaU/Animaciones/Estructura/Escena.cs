public class Escena
{
    public List<Animacion> Animaciones { get; set; }
    public Escena(List<Animacion> animaciones)
    {
        Animaciones = animaciones;
    }

    public void Play(float tiempoGlobal, float tiempoFrame)
    {
        foreach (var animacion in Animaciones)
        {
            animacion.Play(tiempoGlobal, tiempoFrame);
        }
    }

}