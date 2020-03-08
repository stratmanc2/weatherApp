/**
 * This class will act like the server class that gets weather data,
 * but it will not connect to the server
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalWeatherData
{
    private static string atmosphere, recommendedClothes;
    private static float temp, fahrenheit, celsius;

    // gets a random atmosphere condition, since cannot connect to server
    public static string getAtmosphere()
    {
        atmosphere = "Clear";
        int i = Random.Range(0, 4);

        switch (i)
        {
            // rain
            case 0:
                if (fahrenheit >= 40)
                    atmosphere = "Rain";
                break;
            // snow
            case 1:
                if (fahrenheit <= 32)
                    atmosphere = "Snow";
                break;
            // fog
            case 2:
                if (fahrenheit <= 50)
                    atmosphere = "Fog";
                break;
            // wind
            case 3:
                atmosphere = "Windy";
                break;
        }

        return atmosphere;
    }

    // updates temperature based off of server, if it worked, so instead randomly pick a temperature
    public static void updateTemp()
    {
        fahrenheit = Random.Range(20f, 90f);
        celsius = Random.Range(-5, 32);
    }

    public static float getFahrenheit()
    {
        return fahrenheit;
    }

    public static string getRecommendedClothes()
    {
        if (fahrenheit <= 30)
        {
            recommendedClothes = "Full body suit. Do not spend long outside.";
        }
        else if (fahrenheit <= 40)
        {
            recommendedClothes = "Warm onsie and sweater or jacket.";
        }
        else if (fahrenheit <= 50)
        {
            recommendedClothes = "Long sleeved onsie with pants.";
        }
        else if  (fahrenheit <= 60)
        {
            recommendedClothes = "Long sleeved shirt with pants and a jacket.";
        }
        else if (fahrenheit <= 70)
        {
            recommendedClothes = "Long sleeved shirt and pants.";
        }
        else if (fahrenheit <= 80)
        {
            recommendedClothes = "T shirt and pants.";
        }
        else
        {
            recommendedClothes = "T shirt and shorts.";
        }

        return recommendedClothes;
    }



    // sets the temperature in fahrenheit
    public static void setTempF(float t)
    {
        fahrenheit = t;
    }

    // sets the temp in fahrenheit based off of celsius
    private static void setTempF()
    {
        fahrenheit = 32 + (celsius / 0.5556f);
    }

    // sets the temperature in celsius
    public static void setTempC(float t)
    {
        celsius = t;
    }

    // sets the temp in celsius based off of fahrenheit
    private static void setTempC()
    {
        celsius = 0.5556f * (fahrenheit - 32f);
    }
}
