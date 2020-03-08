/**
 * This class gets weather data from local host
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System;
using System.Threading.Tasks;
//using Newtonsoft;

public class WeatherData : MonoBehaviour
{
    HttpClient client;
    Uri siteUri;
    public Text text;
    private WeatherForecast data;
    private string dataString;

    private static string rain, snow, recommendedClothes;
    private static float temp, fahrenheit, celsius, windSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        dataString = "";
        client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };

        GetDataAsync();
    }

    // gets data from server as a string
    async Task GetDataAsync()
    {
        try
        {
            var response = await client.GetAsync("weatherforecast/omaha");
            var json = await response.Content.ReadAsStringAsync(); // contains string from web server
            dataString = json;
            updateVariables();
            Debug.Log(json);
            // data = JsonConvert.DeserializeObject<WeatherForecast>(json);
        }
        catch (Exception e)
        {

        }
    }

    public string getData()
    {
        return dataString;
    }

    // updates the variables to display data from server
    public void updateVariables()
    {
        try
        {
            GetDataAsync();

            string[] str = dataString.Split(',', ':');

            fahrenheit = float.Parse(str[8]);
            celsius = float.Parse(str[6]);
            windSpeed = float.Parse(str[45]);
            rain = str[54];
            snow = str[56];
            recommendedClothes = str[85];
            recommendedClothes = recommendedClothes.Trim('}', '"');
            recommendedClothes = recommendedClothes.Replace(@"\", "");
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }


    public bool isRain()
    {
        if (rain.CompareTo("null") == 0)
        {
            return false;
        }
        else
            return true;
    }

    public bool isSnow()
    {
        if (snow.CompareTo("null") == 0)
        {
            return false;
        }
        else
            return true;
    }

    public float getFahrenheit() { return fahrenheit; }

    public void setFahrenheit(float t)
    {
        fahrenheit = t;
    }

    public float getCelsius() { return celsius; }

    public float getWindSpeed() { return windSpeed; }

    public string getRecommendedClothes() { return recommendedClothes; }

    // Update is called once per frame
    void Update()
    {
        //  text.text = JsonUtility.ToJson(data);
    }
}
