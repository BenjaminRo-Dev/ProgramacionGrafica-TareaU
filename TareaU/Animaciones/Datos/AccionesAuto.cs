using OpenTK.Mathematics;

public class AccionesAuto
{
    private List<Accion> ListaAcciones;

    public AccionesAuto()
    {
        ListaAcciones = new List<Accion>();
        float k = 1.5f;

        //recta 1
        ListaAcciones.Add(new Accion("escalar", 16, 1, 2f));
        // ListaAcciones.Add(new Accion("escalar", 3, 1, -2));

        ListaAcciones.Add(new Accion("posicionar", 1*k, Vector3.Zero, 5*k, new Vector3(0, 0, -19)));

        ListaAcciones.Add(new Accion("posicionar", 6*k, new Vector3(0, 0, -19), 1.5f*k, new Vector3(-2, 0, -21)));
        ListaAcciones.Add(new Accion("rotar", 6f*k, Vector3.Zero, 1.5f*k, new Vector3(0, 90, 0)));
        
        //recta 2
        ListaAcciones.Add(new Accion("posicionar", 7.5f*k, new Vector3(-2,0,-21), 5*k, new Vector3(-20, 0, -21)));

        ListaAcciones.Add(new Accion("posicionar", 12.5f*k, new Vector3(-20,0,-21), 1.5f*k, new Vector3(-22, 0, -19)));
        ListaAcciones.Add(new Accion("rotar", 12.5f*k, Vector3.Zero, 1.5f*k, new Vector3(0, 90, 0)));
        
        //recta3
        ListaAcciones.Add(new Accion("posicionar", 14f*k, new Vector3(-22,0, -19), 5*k, new Vector3(-22, 0, 0)));
    }

    public List<Accion> ObtenerAcciones() => ListaAcciones;
    
}