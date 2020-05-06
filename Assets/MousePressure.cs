using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressure : MonoBehaviour

{   
    public Bar BarScript;
    public GameObject Torniquet;
    public GameObject BG;
    public GameObject Bar;
    public GameObject SigPattern;
    public GameObject SigPattern_Zoomed;
    public GameObject ZoomedCamera;
    public GameObject CorrectLocation;
    public float applytime = 3.0f;
    public float timer = 0f;
    public bool on_target;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("DistanceText").GetComponent<Renderer>().enabled = true;
        GameObject.Find("DistanceNumber").GetComponent<Renderer>().enabled = true;
        SigPattern.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        //GameObject.Find("indicator_zoom").SetActive(false);
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Place Torniquet";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Place Torniquet";
        //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        on_target = true;

        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Applying Torniquet...";
            GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.yellow;
            //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Applying Torniquet...";
            //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().color = Color.yellow;
            BG.SetActive(true);
            SigPattern.SetActive(true);
            BarScript.AnimateBar();
            if (ZoomedCamera.activeInHierarchy)
            {
                SigPattern_Zoomed.SetActive(true);
                //GameObject.Find("indicator_zoom").SetActive(true);
                GameObject.Find("correct/incorrect").transform.localScale = new Vector3(0.05f, 0.05f, 0.1f);
                GameObject.Find("correct/incorrect").transform.position = new Vector3(0.76f, -0.18f, -0.16f);
            }
            else if (!ZoomedCamera.activeInHierarchy)
            {
                GameObject.Find("correct/incorrect").transform.localScale = new Vector3(0.15f, 0.15f, 0.1f);
                GameObject.Find("correct/incorrect").transform.position = new Vector3(-0.22f, -0.18f, -1.37f);
            }

        }

        else if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer > applytime)
            {
                CorrectLocation.SetActive(true);
                GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Torniquet Correctly Applied! Check wound.";
                GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.green;
                //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Torniquet Correctly Applied! Check wound.";
                //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().color = Color.green;
                GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f; 
            }
        }

    }

    void OnMouseExit()
    {
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Place Torniquet";
        GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
        //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Place Torniquet";
        //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
        BarScript.bar_off();
        SigPattern.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        on_target = false;
    }

    void Update()
    {
        float distance = Vector3.Distance (Torniquet.transform.position, transform.position);
        GameObject.Find("DistanceNumber").GetComponent<TextMesh>().text = distance.ToString();

        if (on_target == false)
            if (Input.GetMouseButtonDown(0))
            {
                timer = 0f;
                timer += Time.deltaTime;
                BG.SetActive(true);
                BarScript.AnimateBar();
                GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Applying Torniquet...";
                //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Applying Torniquet...";
                if (timer > applytime)
                {
                    GameObject.Find("correct/incorrect").GetComponent<TextMesh>().text = "Torniquet Incorrectly Applied. Check wound.";
                    GameObject.Find("correct/incorrect").GetComponent<TextMesh>().color = Color.red;
                    //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().text = "Torniquet Incorrectly Applied. Check wound.";
                    //GameObject.Find("indicator_zoom").GetComponent<TextMesh>().color = Color.red;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                BarScript.bar_off();
            }

    }
           
}
