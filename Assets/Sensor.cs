using System.Collections.Generic;
using UnityEngine;

class Sensor : MonoBehaviour {
    // min optimal pressure and max optimal pressure signify the range in which the pressure should be
    // bluetooth sensor is a class written by adrian to return the pressure value
    // pressure values is a list of the pressure values. Will be used to analyze final statement of treatment

    public float minOptimalPressure;
    public float maxOptimalPressure;
    public float currentPressure;
    public const float maxPressure = 100;

    // adrian's bluetooth sensor
    // has one function we use, float getPressure(), which returns the current pressure value for the sensor
    public BluetoothSensor bluetoothSensor;

    List<float> pressureValues = null;

    void FixedUpdate() {
        if (pressureValues == null)
            pressureValues = new List<float>();
        // updates list of pressure values with current pressure value
        currentPressure = bluetoothSensor.getPressure();
        pressureValues.Add(currentPressure);
    }
}