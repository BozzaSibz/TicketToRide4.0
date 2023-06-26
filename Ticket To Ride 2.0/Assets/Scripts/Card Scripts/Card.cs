using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public enum Colour
    {
        Red, 
        Blue,
        Green, 
        Orange,
        Yellow, 
        Pink, 
        Black,
        White,
        Locomotive, 
    }

    //card template 
    public string title;
    public Colour colour;
    public Sprite image;
}
