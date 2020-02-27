using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Wound
{
    // has location (selected in start menu), pain multiplier (worse wounds = more pain), and blood multiplier (worse wounds = higher blood loss rate)
​
    public Wound(string loc, float blood, float pain)
    {
        this.location = loc;
        this.bloodMultiplier = blood;
        this.painMultiplier = pain;
    }
​
    public string location;
    public float bloodMultiplier;
    public float bloodMultiplierMultiplier;
    public float painMultiplier;
}
​
class Sensor : MonoBehaviour
{
    // min optimal pressure and max optimal pressure signify the range in which the pressure should be
    // bluetooth sensor is a class written by adrian to return the pressure value
    // pressure values is a list of the pressure values. Will be used to analyze final statement of treatment
​
    public Sensor(float minOpt, float maxOpt, BluetoothSensor bts)
    {
        this.minOptimalPressure = minOpt;
        this.maxOptimalPressure = maxOpt;
        this.bluetoothSensor = bts;
        this.pressureValues = new List<float>();
    }
​
    public float minOptimalPressure;
    public float maxOptimalPressure;
    public float currentPressure;
    public const float maxPressure = 100;
​
    // adrian's bluetooth sensor
    // has one function we use, float getPressure(), which returns the current pressure value for the sensor
    BluetoothSensor bluetoothSensor;
​
    List<float> pressureValues;
​
    void FixedUpdate()
    {
        // updates list of pressure values with current pressure value
        currentPressure = bluetoothSensor.getPressure();
        pressureValues.Add(currentPressure);
    }
}
​
class Patient : MonoBehaviour
{
    // patient class has list of sensors, the wound, and a starting health of 100
​
    public Patient(List<Sensor> sensors, Wound wound)
    {
        this.sensors = sensors;
        this.wound = wound;
        this.health = 100;
    }
​
    List<Sensor> sensors;
    Wound wound;
    public float health;
​
    public string healthStatus;
​
    public string painStatus;
​
    public string bloodStatus;
​
    void FixedUpdate()
    {
​
        // updates health by multiplying blood loss rate by time step
        // if statements categorize health into five stages
        // each stage will have less animations and blood loss as base state
        // if pressure is being applied, more or less animations and blood can be triggered
        health -= getBloodLoss() * Time.deltaTime;
        float currentPressure = sensor.currentPressure;
​
        if (health <= 100 && health > 75)
        {
            healthStatus = "Stable Wounded";
            bloodMultiplierMultiplier = 2;
            if (currentPressure = 0)
            {
                bloodStatus = "Heaviest Bleeding";
            }
        }
        else if (health <= 75 && health > 50)
        {
            healthStatus = "Moderately Wounded";
            if (currentPressure = 0)
            {
                bloodStatus = "Heavy Bleeding";
            }
        }
        else if (health <= 50 && health > 25)
        {
            healthStatus = "Severely Wounded";
            if (currentPressure = 0)
            {
                bloodStatus = "Moderate Bleeding";
            }
        }
        else if (health <= 25 && health > 0)
        {
            healthStatus = "Deadly Wounded";
            if (currentPressure = 0)
            {
                bloodStatus = "Low Bleeding";
            }
        }
        else
        {
            healthStatus = "Dead";
            bloodStatus = "No Bleeding";
        }
​
        // if statement to trigger Kaila's animations
        float pain = getPain();
        float currentPressure = sensor.currentPressure;
​
        if (pain < 0 && currentPressure != 0)
        {
            painstatus = "Low Pressure";
        }
        else if (healthStatus = "Deadly Wounded")
        {
            painStatus = "Dying";
        }
        else if (pain > 0 && currentPressure != 0)
        {
            painStatus = "High Pressure";
        }
        else
        {
            painStatus = "Stable Animation";
        }
​
        // if statement to trigger Imani's bleeding visuals
        float bloodLoss = getBloodLoss();
        float currentPressure = sensor.currentPressure;
        if (currentPressure != 0)
        {
            if (bloodLoss <= 1 && bloodLoss > 0.8)
            {
                bloodStatus = "Heaviest Bleeding";
            }
            else if (bloodLoss <= 0.8 && bloodLoss > 0.6)
            {
                bloodStatus = "Heavy Bleeding";
            }
            else if (bloodLoss <= 0.6 && bloodLoss > 0.4)
            {
                bloodStatus = "Moderate Bleeding";
            }
            else if (bloodLoss <= 0.4 && bloodLoss > 0.2)
            {
                bloodStatus = "Low Bleeding";
            }
            else if (bloodLoss <= 0.2 && bloodLoss > 0)
            {
                bloodStatus = "Lowest Bleeding";
            }
            else
            {
                bloodStatus = "No Bleeding";
            }
        }
​
​
    public float getPain()
    {
        // gets pain value by calculating pain from each sensor
        float pain = 0;
        foreach (Sensor sensor in sensors)
        {
            pain += calculatePain(sensor);
        }
        return pain / sensors.Count;
    }
​
    public float getBloodLoss()
    {
        // gets blood loss rate by calculating blood loss rate for each sensor
        float bloodLoss = 0;
        foreach (Sensor sensor in sensors)
        {
            bloodLoss += calculateBloodLoss(sensor);
        }
        return bloodLoss / sensors.Count;
    }
​
    private float calculatePain(Sensor sensor)
    {
        // uses minimum and max optimal pressure from Sensor class
        // if current pressure is below min or above max, will multiply the value by pain multiplier
        float minOpt = sensor.minOptimalPressure;
        float maxOpt = sensor.maxOptimalPressure;
        float current = sensor.currentPressure;
        float max = sensor.maxPressure;
​
		float painBelow = 1 - (current / minOpt);
        float painAbove = (current - maxOpt) / (max - maxOpt);
        float painTotal = clamp01(max(painBelow, painAbove));
        if (painAbove < painBelow)
        {
            return -(painTotal * wound.painMultiplier);
        }
        else
        {
            return painTotal * wound.painMultiplier;
        }

    }
​
    private float calculateBloodLoss(Sensor sensor)
    {
        // only uses minimum optimal pressure since blood loss would occur only when pressure is low
        // gets ratio of current pressure to mimum optimal pressure and multiplies it by blood multiplier
        float minOpt = sensor.minOptimalPressure;
        float current = sensor.currentPressure;
​
        float bloodLoss = clamp01(1 - (current / minOpt));
        return bloodLoss * wound.bloodMutliplier * bloodMultiplierMultiplier;
    }
​
    private float clamp01(float a)
    {
        // keeps values for blood and pain calculations between 0 and 1
        if (a > 1)
        {
            return 1;
        }
        else if (a < 0)
        {
            return 0;
        }
        else
        {
            return a;
        }
    }
}