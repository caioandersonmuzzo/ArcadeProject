using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListEsquinas
{
    static List<Transform> esquinas = new List<Transform>();

    public static void Register(Transform esquina)
    {
        esquinas.Add(esquina);
    }

    public static void Unregister(Transform esquina)
    {
        esquinas.Remove(esquina);
    }

    public static List<Transform> GetPath()
    {
        return esquinas;
    }
}
