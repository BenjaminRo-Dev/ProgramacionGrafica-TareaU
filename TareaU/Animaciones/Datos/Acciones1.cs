using OpenTK.Mathematics;
using System.Collections.Generic;

public class Acciones1
{
    private List<Accion> listaAcciones;

    public Acciones1(ObjetoGrafico objetoGrafico)
    {
        listaAcciones = new List<Accion>();

        // Acción 1: Mover el objeto de (0, 0, 0) a (10, 0, 0) en 5 segundos
        listaAcciones.Add(new Accion(1, objetoGrafico.Posicion, 5, new Vector3(10, 0, 0)));

        // Acción 2: Mover el objeto de (10, 0, 0) a (10, 10, 0) en 2 segundos
        listaAcciones.Add(new Accion(6, new Vector3(10, 0, 0), 2, new Vector3(10, 10, 0)));

        // Acción 2: Mover el objeto de (10, 0, 0) a (10, 10, 0) en 5 segundos
        listaAcciones.Add(new Accion(9, new Vector3(0, 0, 0), 2, new Vector3(-10, 0, 0)));


    }

    public List<Accion> ObtenerAcciones()
    {
        return listaAcciones;
    }
}