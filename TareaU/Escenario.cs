// class Escenario
// {
//     private List<ObjetoGrafico> objetos; // Lista de objetos en el escenario

//     public Escenario()
//     {
//         objetos = new List<ObjetoGrafico>();
//     }

//     public void AgregarObjeto(ObjetoGrafico objeto)
//     {
//         objetos.Add(objeto);
//     }

//     public void Actualizar(double tiempo)
//     {
//         foreach (var objeto in objetos)
//         {
//             objeto.Actualizar(tiempo);
//         }
//     }

//     public void Dibujar(int vertexBufferObject, int elementBufferObject)
//     {
//         foreach (var objeto in objetos)
//         {
//             objeto.Dibujar(vertexBufferObject, elementBufferObject);
//         }
//     }
// }