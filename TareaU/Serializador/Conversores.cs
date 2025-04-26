using OpenTK.Mathematics;
using TareaU;
//DataTransferObject
public static class ObjetoMapper
{
    public static Objeto ConvertirAObjeto(ObjetoDTO dto)
    {
        var partes = new Dictionary<string, Parte>();

        foreach (var parteEntry in dto.Partes)
        {
            var caras = new Dictionary<string, Cara>();

            foreach (var caraEntry in parteEntry.Value.Caras)
            {
                var verts = caraEntry.Value.Vertices;
                var cara = new Cara(
                    new Color4(verts["p1"].Color[0], verts["p1"].Color[1], verts["p1"].Color[2], verts["p1"].Color[3]),
                    new Vector3(verts["p1"].Posicion[0], verts["p1"].Posicion[1], verts["p1"].Posicion[2]),
                    new Vector3(verts["p2"].Posicion[0], verts["p2"].Posicion[1], verts["p2"].Posicion[2]),
                    new Vector3(verts["p3"].Posicion[0], verts["p3"].Posicion[1], verts["p3"].Posicion[2]),
                    new Vector3(verts["p4"].Posicion[0], verts["p4"].Posicion[1], verts["p4"].Posicion[2])
                );

                caras[caraEntry.Key] = cara;
            }

            var parte = new Parte(parteEntry.Key, caras)
            {
                Posicion = new Vector3(parteEntry.Value.Posicion[0], parteEntry.Value.Posicion[1], parteEntry.Value.Posicion[2]),
                Escala = new Vector3(parteEntry.Value.Escala[0], parteEntry.Value.Escala[1], parteEntry.Value.Escala[2]),
                Rotacion = new Vector3(parteEntry.Value.Rotacion[0], parteEntry.Value.Rotacion[1], parteEntry.Value.Rotacion[2]),
            };

            partes[parteEntry.Key] = parte;
        }

        var objeto = new Objeto(dto.Nombre, partes)
        {
            Posicion = new Vector3(dto.Posicion[0], dto.Posicion[1], dto.Posicion[2]),
            Escala = new Vector3(dto.Escala[0], dto.Escala[1], dto.Escala[2]),
            Rotacion = new Vector3(dto.Rotacion[0], dto.Rotacion[1], dto.Rotacion[2]),
        };

        return objeto;
    }

    public static ObjetoDTO ConvertirADTO(ObjetoGrafico objeto)
    {
        var partesDTO = new Dictionary<string, ParteDTO>();

        foreach (var parteEntry in objeto.Partes)
        {
            var carasDTO = new Dictionary<string, CaraDTO>();

            foreach (var caraEntry in parteEntry.Value.Caras)
            {
                var vertsDTO = new Dictionary<string, VerticeDTO>();

                foreach (var vertEntry in caraEntry.Value.Vertices)
                {
                    vertsDTO[vertEntry.Key] = new VerticeDTO
                    {
                        Posicion = new float[] {
                            vertEntry.Value.posicion.X,
                            vertEntry.Value.posicion.Y,
                            vertEntry.Value.posicion.Z
                        },
                        Color = new float[] {
                            vertEntry.Value.Color.R,
                            vertEntry.Value.Color.G,
                            vertEntry.Value.Color.B,
                            vertEntry.Value.Color.A
                        }
                    };
                }

                carasDTO[caraEntry.Key] = new CaraDTO
                {
                    Vertices = vertsDTO
                };
            }

            partesDTO[parteEntry.Key] = new ParteDTO
            {
                Posicion = new float[] {
                    parteEntry.Value.Posicion.X,
                    parteEntry.Value.Posicion.Y,
                    parteEntry.Value.Posicion.Z
                },
                Escala = new float[] {
                    parteEntry.Value.Escala.X,
                    parteEntry.Value.Escala.Y,
                    parteEntry.Value.Escala.Z
                },
                Rotacion = new float[] {
                    parteEntry.Value.Rotacion.X,
                    parteEntry.Value.Rotacion.Y,
                    parteEntry.Value.Rotacion.Z
                },
                Caras = carasDTO
            };
        }

        return new ObjetoDTO
        {
            Nombre = objeto.Nombre,
            Posicion = new float[] { objeto.Posicion.X, objeto.Posicion.Y, objeto.Posicion.Z },
            Escala = new float[] { objeto.Escala.X, objeto.Escala.Y, objeto.Escala.Z },
            Rotacion = new float[] { objeto.Rotacion.X, objeto.Rotacion.Y, objeto.Rotacion.Z },
            Partes = partesDTO
        };
    }
}
