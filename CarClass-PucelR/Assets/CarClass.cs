using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class CarClass
{
    private string make;
    private string year;
    private int maxSpeed = 100;
    private float currantSpeed;






    

    public string Year
    {
        get { return year; }
        set { year = value; }
    }
    public int MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }
    public string Make
    {
        get { return make; }
        set { make = value; }
    }

    public float CurrantSpeed
    {
        get { return currantSpeed; }
        set { currantSpeed = value; }
    }





}