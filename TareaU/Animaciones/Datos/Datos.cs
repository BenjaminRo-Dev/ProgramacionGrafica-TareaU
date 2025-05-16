using OpenTK.Mathematics;

public class Acciones1
{
    private List<Accion> ListaAcciones;

    public Acciones1()
    {
        ListaAcciones = new List<Accion>();
        // Accion 1: Mover de 0 a 10 en 5 segs
        ListaAcciones.Add(new Accion(1, Vector3.Zero, 5, new Vector3(10, 0, 0)));
        // Accion 2: Mover de 10 a 10,10 en 2 segs
        ListaAcciones.Add(new Accion(6, new Vector3(10, 0, 0), 2, new Vector3(10, 10, 0)));
        // Accion 3: Mover de 10,10 a -10,10 en 2 segs
        ListaAcciones.Add(new Accion(8, new Vector3(10, 10, 0), 2, new Vector3(-10, 10, 0)));

        ListaAcciones.Add(new Accion(10, new Vector3(-10, 10, 0), 2, new Vector3(-10, 0, 0)));
        
        ListaAcciones.Add(new Accion(12, new Vector3(-10, 0, 0), 2, new Vector3(0, 0, 0)));
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