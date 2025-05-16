using OpenTK.Mathematics;
using TareaU;

public class Pista
{
    public static Vector3[] verticesU()
        {
            return new[]
            {

                // Rectangulo parado delantero izquierdo
                new Vector3(-10, 1, 10),     //0
                new Vector3(-10, 1, -10),   //1
                new Vector3(-15, 1, -10),   //2
                new Vector3(-15, 1, 10),     //3

                //Rect parado trasero izquierdo
                new Vector3(-10, -1, 10),        //4
                new Vector3(-10, -1, -10),      //5
                new Vector3(-15, -1, -10),      //6
                new Vector3(-15, -1, 10),        //7

                //Rectangulo acostado delantero
                new Vector3(15, 1, -10),              //8
                new Vector3(15, 1, -15),              //9
                new Vector3(-15,  1, -15),               //10
                new Vector3(-15,  1, -10),               //11

                // //Rectangulo acostado trasero
                new Vector3(15, -1, -10),              //8
                new Vector3(15, -1, -15),              //9
                new Vector3(-15,  -1, -15),               //10
                new Vector3(-15,  -1, -10),               //11

                //Rectangulo parado delantero derecho
                new Vector3(15, 1, 10),     //16
                new Vector3(15, 1, -10),   //17
                new Vector3(10, 1, -10),   //18
                new Vector3(10, 1, 10),     //19

                // //Rectangulo parado trasero derecho
                new Vector3(15, -1, 10),     //16
                new Vector3(15, -1, -10),   //17
                new Vector3(10, -1, -10),   //18
                new Vector3(10, -1, 10),     //19
            };
        }

    public static Dictionary<string, Cara> carasParte1()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
            { "delantera", new Cara(Color4.SandyBrown, vertices[0], vertices[1], vertices[2], vertices[3]) }, // Indigo
            { "trasera", new Cara(Color4.Coral, vertices[4], vertices[5], vertices[6], vertices[7]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[3], vertices[2], vertices[6], vertices[7]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[0], vertices[1], vertices[5], vertices[4]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[0], vertices[3], vertices[7], vertices[4]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[1], vertices[2], vertices[6], vertices[5]) } // Magenta
        };
    }

    public static Dictionary<string, Cara> carasParte2()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
            { "delantera", new Cara(Color4.Indigo, vertices[8], vertices[9], vertices[10], vertices[11]) }, // Indigo
            { "trasera", new Cara(Color4.Green, vertices[12], vertices[13], vertices[14], vertices[15]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[11], vertices[10], vertices[14], vertices[15]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[8], vertices[9], vertices[13], vertices[12]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[8], vertices[11], vertices[15], vertices[12]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[9], vertices[10], vertices[14], vertices[13]) } // Magenta
        };
    }

    public static Dictionary<string, Cara> carasParte3()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
        { "delantera", new Cara(Color4.Indigo, vertices[16], vertices[17], vertices[18], vertices[19]) }, // Indigo
        { "trasera", new Cara(Color4.Green, vertices[20], vertices[21], vertices[22], vertices[23]) }, // Green
        { "superior", new Cara(Color4.Blue, vertices[19], vertices[18], vertices[22], vertices[23]) }, // Blue
        { "inferior", new Cara(Color4.Yellow, vertices[16], vertices[17], vertices[21], vertices[20]) }, // Yellow
        { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[16], vertices[19], vertices[23], vertices[20]) }, // Cyan
        { "lateralDerecho", new Cara(Color4.Magenta, vertices[17], vertices[18], vertices[22], vertices[21]) } // Magenta
        };
    }

    public static Dictionary<string, Parte> partesU()
    {
        var partes = new Dictionary<string, Parte>
        {
            { "parte1", new Parte("parte1", carasParte1()) },
            { "parte2", new Parte("parte2", carasParte2()) },
            { "parte3", new Parte("parte3", carasParte3()) }
        };

        return partes;
    }

    public static Dictionary<string, Objeto> ObjetosU()
    {
        var objetos = new Dictionary<string, Objeto>
        {
            { "Pista", new Objeto("Pista", partesU()) }
        };

        return objetos;
    }

}