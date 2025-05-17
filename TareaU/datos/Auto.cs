using OpenTK.Mathematics;
using TareaU;

public class Auto
{
    public static Vector3[] verticesU()
        {
            return new[]
            {

                // Chasis inferior
                new Vector3(-2, 1, 1),     //0
                new Vector3(-2, 1, -1),   //1
                new Vector3(2, 1, -1),   //2
                new Vector3(2, 1, 1),     //3

                //Chasis superior
                new Vector3(-2, 3, 1),     //0
                new Vector3(-2, 3, -1),   //1
                new Vector3(2,  3, -1),   //2
                new Vector3(2,  3, 1),     //3

               //Techo inferior
                new Vector3(-2, 3, 1),     //0
                new Vector3(-2, 3, -1),   //1
                new Vector3(1,  3, -1),   //2
                new Vector3(1,  3, 1),     //3

                //techo superior
                new Vector3(-2, 4, 1),     //0
                new Vector3(-2, 4, -1),   //1
                new Vector3(1,  4, -1),   //2
                new Vector3(1,  4, 1),     //3

                //Ventana1 inferior
                new Vector3(-1.9f, 3, 1.1f),     //0
                new Vector3(-1.9f, 3, -1.1f),   //1
                new Vector3(0,  3, -1.1f),   //2
                new Vector3(0,  3, 1.1f),     //3

                //Ventana1 superior
                new Vector3(-1.9f, 3.9f, 1.1f),     //0
                new Vector3(-1.9f, 3.9f, -1.1f),   //1
                new Vector3(0,  3.9f, -1.1f),   //2
                new Vector3(0,  3.9f, 1.1f),     //3

                //Ventana2 inferior
                new Vector3(0.1f, 3, 1.1f),     //24
                new Vector3(0.1f, 3, -1.1f),   //25
                new Vector3(0.9f,  3, -1.1f),   //26
                new Vector3(0.9f,  3, 1.1f),     //27

                //Ventana2 superior
                new Vector3(0.1f, 3.9f, 1.1f),     //28
                new Vector3(0.1f, 3.9f, -1.1f),   //29
                new Vector3(0.9f,  3.9f, -1.1f),   //30
                new Vector3(0.9f,  3.9f, 1.1f),     //31
            };
        }

    public static Dictionary<string, Cara> carasParte1()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
            { "delantera", new Cara(Color4.DarkGray, vertices[0], vertices[1], vertices[2], vertices[3]) }, // Indigo
            { "trasera", new Cara(Color4.DarkGray, vertices[4], vertices[5], vertices[6], vertices[7]) }, // Green
            { "superior", new Cara(Color4.DarkGray, vertices[3], vertices[2], vertices[6], vertices[7]) }, // Blue
            { "inferior", new Cara(Color4.DarkGray, vertices[0], vertices[1], vertices[5], vertices[4]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.DarkGray, vertices[0], vertices[3], vertices[7], vertices[4]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.DarkGray, vertices[1], vertices[2], vertices[6], vertices[5]) } // Magenta
        };
    }

    public static Dictionary<string, Cara> carasParte2()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
            { "delantera", new Cara(Color4.Gray, vertices[8], vertices[9], vertices[10], vertices[11]) }, // Indigo
            { "trasera", new Cara(Color4.Gray, vertices[12], vertices[13], vertices[14], vertices[15]) }, // Green
            { "superior", new Cara(Color4.Gray, vertices[11], vertices[10], vertices[14], vertices[15]) }, // Blue
            { "inferior", new Cara(Color4.Gray, vertices[8], vertices[9], vertices[13], vertices[12]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Gray, vertices[8], vertices[11], vertices[15], vertices[12]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Gray, vertices[9], vertices[10], vertices[14], vertices[13]) } // Magenta
        };
    }

    public static Dictionary<string, Cara> carasParte3()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
        { "delantera", new Cara(Color4.SkyBlue, vertices[16], vertices[17], vertices[18], vertices[19]) }, // Indigo
        { "trasera", new Cara(Color4.SkyBlue, vertices[20], vertices[21], vertices[22], vertices[23]) }, // Green
        { "superior", new Cara(Color4.SkyBlue, vertices[19], vertices[18], vertices[22], vertices[23]) }, // Blue
        { "inferior", new Cara(Color4.SkyBlue, vertices[16], vertices[17], vertices[21], vertices[20]) }, // Yellow
        { "lateralIzquierdo", new Cara(Color4.SkyBlue, vertices[16], vertices[19], vertices[23], vertices[20]) }, // Cyan
        { "lateralDerecho", new Cara(Color4.SkyBlue, vertices[17], vertices[18], vertices[22], vertices[21]) } // Magenta
        };
    }

    public static Dictionary<string, Cara> carasParte4()
    {
        var vertices = verticesU();

        return new Dictionary<string, Cara>
        {
            { "delantera", new Cara(Color4.SkyBlue, vertices[24], vertices[25], vertices[26], vertices[27]) }, // Indigo
            { "trasera", new Cara(Color4.SkyBlue, vertices[28], vertices[29], vertices[30], vertices[31]) }, // Green
            { "superior", new Cara(Color4.SkyBlue, vertices[27], vertices[26], vertices[30], vertices[31]) }, // Blue
            { "inferior", new Cara(Color4.SkyBlue, vertices[24], vertices[25], vertices[29], vertices[28]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.SkyBlue, vertices[24], vertices[27], vertices[31], vertices[28]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.SkyBlue, vertices[25], vertices[26], vertices[30], vertices[29]) } // Magenta
        };
    }

    public static Dictionary<string, Parte> partesU()
    {
        var partes = new Dictionary<string, Parte>
        {
            { "parte1", new Parte("parte1", carasParte1()) },
            { "parte2", new Parte("parte2", carasParte2()) },
            { "parte3", new Parte("parte3", carasParte3()) },
            { "parte4", new Parte("parte4", carasParte4()) }
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