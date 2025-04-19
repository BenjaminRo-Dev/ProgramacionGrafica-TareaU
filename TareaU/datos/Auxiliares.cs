using OpenTK.Mathematics;

public class ObjetoData
{
    public float[] posicion { get; set; }
    public float[] escala { get; set; }
    public float[] rotacion { get; set; }
    public List<ParteData> partes { get; set; }
}

public class ParteData
{
    public float[] posicion { get; set; }
    public float[] escala { get; set; }
    public float[] rotacion { get; set; }
    public List<float[]> vertices { get; set; }
    public List<CaraData> caras { get; set; }
}

public class CaraData
{
    public string color { get; set; }
    public List<int> indices { get; set; }
}
