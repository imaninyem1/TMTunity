using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        TextAsset sensorData = Resources.Load<TextAsset>("sensorData");
        Debug.Log(sensorData);
        // creates an array in which we can see each element
        data = sensorData.text.Split(new char[] { '\n' });

        Debug.Log(data);

        // Debug.Log(data.Length);​
        StartCoroutine(doSomething());

        // for loop starting at second value, spliting each line by comma
    }

    IEnumerator doSomething() 
    {   
        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] {','});
            if (!_override)
            {
                Debug.Log(row[0]);
            }
            pressure_value = float.Parse(row[0]);

            // fixes divison by 0 error
            if (pressure_value == 0) {
                pressure_value = 0.1f;
            }

            yield return new WaitForSeconds(0.2f); //time for new data in csv file to read
        }
    }

    public float getPressure() 
    {
        return override_value;
    }
}
