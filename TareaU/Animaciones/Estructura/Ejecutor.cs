using System.Threading;

public class Ejecutor
{
    private CancellationTokenSource cts = new CancellationTokenSource();
    private ManualResetEventSlim sincronizador = new ManualResetEventSlim(false);

    Escena Escena;
    private float TiempoActual, TiempoFrame;
    private bool enPausa = false;

    public Ejecutor(Escena escena)
    {
        Escena = escena;
    }

    public async Task Iniciar()
    {
        while (!cts.Token.IsCancellationRequested)
        {
            sincronizador.Wait();
            sincronizador.Reset();

            if (!enPausa)
            {
                Escena.Play(TiempoActual, TiempoFrame);
            }

            // await Task.Delay((int)(TiempoFrame * 1000));
        }

        Console.WriteLine("Tarea finalizada.");
    }

    public void ActualizarTiempos(float tiempoActual, float tiempoFrame)
    {
        TiempoActual = tiempoActual;
        TiempoFrame = tiempoFrame;
        sincronizador.Set();
    }

    public void Pausar() => enPausa = true;
    public void Reanudar() => enPausa = false;
    public void Detener()
    {
        cts.Cancel();
        sincronizador.Set();
    }
}