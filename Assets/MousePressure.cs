using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressure : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Incorrect";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Correct";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.green;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f;
    }

    void OnMouseExit()
    {
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Incorrect";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
    }
}
