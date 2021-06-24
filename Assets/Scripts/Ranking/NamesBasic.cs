using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesBasic
{
    private List<string> NameCollection = new List<string>{
        "Jorge",
        "Gabriel",
        "Samanta",
        "Emiliano",
        "Rodrigo",
        "Federico",
        "Carla",
        "Mariana",
        "Esteban",
        "Sofia",
        "Lucia",
        "Lucila",
        "Martin",
        "Alejandro",
        "Edgar"
    };

    public string GetRandomName()
    {
        return NameCollection[Random.Range(0, NameCollection.Count)];
    }
}
