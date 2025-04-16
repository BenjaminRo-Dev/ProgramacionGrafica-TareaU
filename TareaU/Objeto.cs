using OpenTK.Mathematics;
using System.Collections.Generic;
using TareaU;

// public class Objeto : ObjetoGrafico
// {
//     private List<Parte> partes;

//     public Objeto(Vector3 posicion, Vector3 rotacion, Vector3 escala)
//         : base(posicion, rotacion, escala)
//     {
//         partes = new List<Parte>();
//     }

//     public Objeto()
//     {
//         partes = new List<Parte>();
//     }

//     public void AgregarParte(Parte parte)
//     {
//         partes.Add(parte);
//     }

//     public static Objeto CrearObjetoGenerico(Vector3 posicion, Vector3 rotacion, Vector3 escala)
//     {
//         Objeto objeto = new Objeto(posicion, rotacion, escala);

//         objeto.AgregarParte(new Parte(
//             posicion + new Vector3(-escala.X / 2, 0, 0), // Parte izquierda
//             rotacion + Vector3.Zero,
//             new Vector3(escala.X / 8, escala.Y, escala.Z / 12)
//         ));

//         objeto.AgregarParte(new Parte(
//             posicion + new Vector3(escala.X / 2, 0, 0), // Parte derecha
//             rotacion + Vector3.Zero,
//             new Vector3(escala.X / 8, escala.Y, escala.Z / 12)
//         ));

//         objeto.AgregarParte(new Parte(
//             posicion + new Vector3(-escala.X / 2, 0, 0), // Parte inferior
//             rotacion + Vector3.Zero,
//             new Vector3(escala.X, escala.Y / 4, escala.Z / 12)
//         ));

//         return objeto;
//     }

//     public override void Dibujar(int vertexBufferObject, int elementBufferObject)
//     {
//         foreach (var parte in partes)
//         {
//             // Guardar las transformaciones originales
//             Vector3 posicionOriginal = parte.Posicion;
//             Vector3 rotacionOriginal = parte.Rotacion;

//             // Aplicar la posición y rotación global del objeto a cada parte
//             parte.Posicion += Posicion;
//             parte.Rotacion += Rotacion;

//             // Dibujar la parte
//             parte.Dibujar(vertexBufferObject, elementBufferObject);

//             // Restaurar las transformaciones originales
//             parte.Posicion = posicionOriginal;
//             parte.Rotacion = rotacionOriginal;
//         }
//     }

//     public override void Actualizar(double tiempo)
//     {
//         foreach (var parte in partes)
//         {
//             parte.Actualizar(tiempo);
//         }
//     }
// }