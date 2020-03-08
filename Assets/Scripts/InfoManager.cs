using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public WeatherData data;
    public Text Ftext, Ctext, RecommendedText, AtmosphereText;
    public InputField userInput;

    // Start is called before the first frame update
    void Start()
    {
        data.updateVariables();
        updateText();
    }

    // update text to display info from weather data class
    public void updateText()
    {
        userInput.text = "Enter Temperature";
        Ftext.text = string.Format("{0:0.0}",data.getFahrenheit());
        Ctext.text = data.getCelsius().ToString();
        RecommendedText.text = data.getRecommendedClothes();

        string str = "";

        if (data.isRain())
        {
            str = "Rain";
        }
        else if (data.isSnow())
        {
            str = "Snow";
        }
        else
            str = "Clear";

        AtmosphereText.text = str;
    }

    // this method is called when the user enters the data in the text field
    public void enterUserInput()
    {
 //       string text = userInput.text;
 //       if (float.Parse(text) < 999)
  //      {
            // temperature reading
  //          data.setFahrenheit(float.Parse(text));
   //     }
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
