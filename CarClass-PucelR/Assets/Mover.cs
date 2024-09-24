using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mover : MonoBehaviour
{
    CarClass chosenCar = null;
    public TMP_Text currentSpeedText;
    public TMP_Text chosenMakeText;
    public TMP_Text chosenYearText;
    public TMP_Text instructions;
    public InputField chosenMake;
    public InputField chosenYear;
    private bool isBought; 
    public int minValue = 1886;      
    public int maxValue = 2024;
    public Button purchaseButton;

    void Awake()
    {
        isBought = false;
        
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        SpeedUp();
        SlowDown();
    }

    public void SpeedUp()
    {
        if (chosenCar == null) return;

        float verticalInput = Input.GetAxis("Vertical");
        float accelerationSpeed = 14.5f;

        if (verticalInput == 1 && chosenCar.CurrantSpeed < chosenCar.MaxSpeed)
        {
            chosenCar.CurrantSpeed += (accelerationSpeed * Time.deltaTime);
            int roundedSpeed = Mathf.RoundToInt(chosenCar.CurrantSpeed);
            Debug.Log(chosenCar.CurrantSpeed);
            currentSpeedText.text = "Speed - " + roundedSpeed + " MPH";
        }
    }

    public void SlowDown()
    {
        if (chosenCar == null) return;

        float verticalInput = Input.GetAxis("Vertical");
        float accelerationSpeed = 14.5f;

        if (verticalInput == -1 && chosenCar.CurrantSpeed > 0)
        {
            chosenCar.CurrantSpeed -= (accelerationSpeed * Time.deltaTime);
            int roundedSpeed = Mathf.RoundToInt(chosenCar.CurrantSpeed);
            Debug.Log(chosenCar.CurrantSpeed);
            currentSpeedText.text = "Speed - " + roundedSpeed + " MPH";
        }
    }

    public void GiveInput()
    {
        chosenCar = new CarClass();
        chosenCar.Year = chosenYear.text;
        chosenCar.Make = chosenMake.text;
        string input = chosenCar.Year;
        int parsedValue;
        bool success = int.TryParse(input, out parsedValue);
        if (success)
        {
            if (parsedValue >= 1886 && parsedValue <= 2024)
            {
                chosenYearText.text = chosenCar.Year;
                Debug.Log("Parsed Value: " + parsedValue);
                purchaseButton.interactable = false;
                chosenYearText.fontSize = 36;
                instructions.text = "DRIVE!<br>Arrow Keys or WASD";
                instructions.fontSize = 50;
            }
            else
            {
                chosenYearText.text = "Invalid input! Please enter a valid number.";
                Debug.Log("Invalid input! Please enter a valid number.");
                chosenYearText.fontSize = 17;
            }
        }
        else
        {
            chosenYearText.text = "Invalid input! Please enter a valid number.";
            Debug.Log("Invalid input! Please enter a valid number.");
            chosenYearText.fontSize = 17;
        }



        chosenMakeText.text = chosenCar.Make;
        isBought = true;
        Debug.Log(chosenYearText.text + " " + chosenMakeText.text);
    }
       
        
    

    
}

