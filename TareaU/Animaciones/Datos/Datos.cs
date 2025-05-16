using OpenTK.Mathematics;

public class Acciones1
{
    private List<Accion> ListaAcciones;

    public Acciones1()
    {
        ListaAcciones = new List<Accion>();
        // Acción 1: Mover el objeto de (0, 0, 0) a (10, 0, 0) en 5 segundos
        ListaAcciones.Add(new Accion(1, Vector3.Zero, 5, new Vector3(10, 0, 0)));
        // Acción 2: Mover el objeto de (10, 0, 0) a (10, 10, 0) en 2 segundos
        ListaAcciones.Add(new Accion(6, new Vector3(10, 0, 0), 2, new Vector3(10, 10, 0)));
        // Acción 2: Mover el objeto de (10, 0, 0) a (10, 10, 0) en 5 segundos
        ListaAcciones.Add(new Accion(9, new Vector3(0, 0, 0), 2, new Vector3(-10, 0, 0)));
    }

    public List<Accion> ObtenerAcciones() => ListaAcciones;
    
}

//Nota: Esta solo podria ser una accion tambien y eliminar la lista de animaciones
public class Animaciones1
{
    private List<Animacion> ListaAnimaciones;
    
    public Animaciones1(ObjetoGrafico objetoGrafico, List<Accion> listaAcciones)
    {
        ListaAnimaciones = new List<Animacion>();
        ListaAnimaciones.Add(new Animacion(objetoGrafico, listaAcciones));
    }
    
    public List<Animacion> ObtenerAnimaciones() => ListaAnimaciones;
}

public class Escena1
{
    private Escena Escena;

    public Escena1(List<Animacion> listaAnimaciones)
    {
        Escena = new Escena(listaAnimaciones);
        Escena.Animaciones = listaAnimaciones;
    }

    public Escena1(Animacion animacion)
    {
        Escena = new Escena();
        Escena.AgregarAnimacion(animacion);
    }


}