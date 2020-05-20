using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BluetoothSensor : MonoBehaviour
{
    public float pressure_value;
    public bool _override;
    public float override_value;
    string[] data;
    // Start is called before the first frame update
    void Start()
    {
        // load csv as a text asset
        TextAsset sensorData = Resources.Load<TextAsset>("SignaturePattern_Correct");
      //  Debug.Log(sensorData);
        // creates an array in which we can see each element
        data = sensorData.text.Split(new char[] { '\n' });
      //  Debug.Log(data);
        // Debug.Log(data.Length);
        StartCoroutine(doSomething());
        // for loop starting at second value, spliting each line by comma
    }
    //function to split csv file to two columns
    IEnumerator doSomething() 
    {   
        var stopwatch = Stopwatch.StartNew();
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] {','});
            if (!_override)
            {
                //Debug.Log(row[0]);
            }
            float temp_pressure_value = float.Parse(row[1]);
            float time_value = float.Parse(row[0]);
            float elapsed_time = (stopwatch.ElapsedMilliseconds)/1000;
            if (time_value < elapsed_time){
                pressure_value = temp_pressure_value;  
            }
            else {                      //time for new data in csv file to read
                yield return new WaitForSeconds(time_value-elapsed_time);
                pressure_value = temp_pressure_value;
            }
            UnityEngine.Debug.Log(elapsed_time);
            // fixes divison by 0 error
            if (pressure_value == 0) {
                pressure_value = 0.1f;
            }
        }
    }
    public float getPressure() 
    {
        return override_value;
    }
}

