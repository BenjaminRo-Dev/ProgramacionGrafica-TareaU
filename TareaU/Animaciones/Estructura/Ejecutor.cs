public class Ejecutor
{
    Escena Escena;
    private float TiempoActual, TiempoFrame, TiempoHilo;

    public Ejecutor(Escena escena)
    {
        Escena = escena;
    }

    private CancellationTokenSource cts = new CancellationTokenSource();
    private bool enPausa = false;

    public async Task Iniciar()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            if (!enPausa)
            {
                Escena.Play(TiempoActual, TiempoFrame);
            }
        }
        // await Task.Delay(16); // Aproximadamente 60 FPS
        // await Task.Delay((int) (TiempoFrame * 1000));
        //Nota: Aqui al convertir a entero, es cero por lo tanto no funciona

        Console.WriteLine("Tarea finalizada.");
    }

    public void ActualizarTiempos(float tiempoActual, float tiempoFrame)
    {
        TiempoActual = tiempoActual;
        TiempoFrame = tiempoFrame;
        // Console.WriteLine(tiempoActual);
    }

    public void Pausar() => enPausa = true;
    public void Reanudar() => enPausa = false;
    public void Detener() => cts.Cancel();
    

}