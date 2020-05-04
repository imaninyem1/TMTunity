using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressure : MonoBehaviour

{   
    public Bar BarScript;
    public GameObject BG;
    public GameObject Bar;
    public GameObject SigPattern;
    public GameObject SigPattern_Zoomed;
    public GameObject ZoomedCamera;
    public float applytime = 3.0f;
    public float timer = 0f;
    public bool on_target;

    // Start is called before the first frame update
    void Start()
    {
        SigPattern.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Incorrect";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        on_target = true;

        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            BG.SetActive(true);
            SigPattern.SetActive(true);
            if (ZoomedCamera.activeInHierarchy)
            {
                SigPattern_Zoomed.SetActive(true);
            }
            BarScript.AnimateBar();
        }

        else if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer > applytime)
            {
                GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Correct";
                GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.green;
                GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f; 
            }
        }

    }

    void OnMouseExit()
    {
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Incorrect";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
        BarScript.bar_off();
        SigPattern.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        on_target = false;
    }

    void Update()
    {
        if (on_target == false)
            if (Input.GetMouseButtonDown(0))
            {
                timer = 0f;
                BG.SetActive(true);
                BarScript.AnimateBar();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                BarScript.bar_off();
            }

    }
           
}
