using OpenTK.Mathematics;

public class AccionesAuto
{
    private List<Accion> ListaAcciones;

    public AccionesAuto()
    {
        ListaAcciones = new List<Accion>();
        // Accion 1: Mover de 0 a 10 en 5 segs
        ListaAcciones.Add(new Accion(1, Vector3.Zero, 5, new Vector3(0, 0, -23)));
        // Accion 2: Mover de 10 a 10,10 en 2 segs
        ListaAcciones.Add(new Accion(6, new Vector3(0,0,-23), 2, new Vector3(-23, 0, -23)));
        // // Accion 3: Mover de 10,10 a -10,10 en 2 segs
        ListaAcciones.Add(new Accion(8, new Vector3(-23,0, -23), 2, new Vector3(-23, 0, 0)));

        // ListaAcciones.Add(new Accion(10, new Vector3(-10, 10, 0), 2, new Vector3(-10, 0, 0)));
        
        // ListaAcciones.Add(new Accion(12, new Vector3(-10, 0, 0), 2, new Vector3(0, 0, 0)));
    }

    public List<Accion> ObtenerAcciones() => ListaAcciones;
    
}