using UnityEngine;
using System.Collections.Generic;

public class PlanetData : MonoBehaviour
{
    public static PlanetData instance { get; private set; } = null;
    private Dictionary<string, string> planetDictionary;
    
    //Making sure that there's always only one instance of PlanetData
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    //Saving planet data as key-value-pairs
    private void Start()
    {
        planetDictionary = new Dictionary<string, string>
        {
            {"Sun", "1.392.684 km"},
            {"Mercury", "4.879,4 km"},
            {"Venus", "12.103,6 km"},
            {"Earth", "12.756,27 km"},
            {"Mars", "6.792,4 km"},
            {"Jupiter", "142.984 km"},
            {"Saturn", "120.536 km"},
            {"Uranus", "51.118 km"},
            {"Neptune", "49.528 km"}
        };
    }

    //Retrieving size of a planet with a certain name
    public string GetPlanetSize(string name)
    {
        return planetDictionary[name];
    }
}
