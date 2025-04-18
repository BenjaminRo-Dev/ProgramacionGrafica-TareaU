using TareaU;
class Escenario : ObjetoGrafico
{
    public List<ObjetoGrafico> Objetos; // Lista de objetos en el escenario

    public Escenario()
    {
        Objetos = new List<ObjetoGrafico>();
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var objeto in Objetos)
        {
            objeto.Dibujar(shader);
        }
    }

    public override void Actualizar()
    {
        foreach (var objeto in Objetos)
        {
            objeto.Actualizar();
        }
    }

    public void AgregarObjeto(ObjetoGrafico objeto)
    {
        Objetos.Add(objeto);
    }




}