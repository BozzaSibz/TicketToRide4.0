using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Destination : ScriptableObject
{
    public enum City1
    {
        Vancouver,
        Seattle,
        Calgary,
        Portland,
        Helena,
        Omaha,
        SaltLakeCity,
        SanFrancisco,
        LosAngeles,
        LasVegas,
        Phoenix,
        ElPaso,
        Denver,
        SantaFe,
        Winnipeg,
        Duluth,
        SaultStMarie,
        Toronto,
        Montreal,
        Boston,
        NewYork,
        Washington,
        Pittsburgh,
        Chicago,
        SaintLouis,
        Detroit,
        Buffalo,
        Charleston,
        Miami,
        Raleigh,
        Houston,
        Nashville,
        LittleRock,
        OklahomaCity,
        NewOrleans,
        Dallas,
    }

    public enum City2
    {
        Vancouver,
        Seattle,
        Calgary,
        Portland,
        Helena,
        Omaha,
        SaltLakeCity,
        SanFrancisco,
        LosAngeles,
        LasVegas,
        Phoenix,
        ElPaso,
        Denver,
        SantaFe,
        Winnipeg,
        Duluth,
        SaultStMarie,
        Toronto,
        Montreal,
        Boston,
        NewYork,
        Washington,
        Pittsburgh,
        Chicago,
        SaintLouis,
        Detroit,
        Buffalo,
        Charleston,
        Miami,
        Raleigh,
        Houston,
        Nashville,
        LittleRock,
        OklahomaCity,
        NewOrleans,
        Dallas, 
    }


    public Sprite imageD;
    public int points;
    public int index;
    public City1 city1;
    public City2 city2; 
}
