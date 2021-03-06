﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePressure : MonoBehaviour

{   
    public Bar BarScript;
    public StartMenu StartMenu;
    public Patient Patient;
    public GameObject Torniquet;
    public GameObject BG;
    public GameObject Bar;
    public GameObject SigPattern;
    public GameObject SigPattern_Zoomed;
    public GameObject ZoomedCamera;
    public GameObject CorrectLocation;
    public GameObject DistanceNumber;
    public GameObject DistanceLocation;
    public GameObject correct_incorrect; 
    public GameObject stage1_sigpattern;
    public GameObject stage1_sigpattern_zoomed;
    public GameObject stage2_sigpattern;
    public GameObject stage2_sigpattern_zoomed;
    public GameObject stage3_sigpattern;
    public GameObject stage3_sigpattern_zoomed;
    public GameObject stage4_sigpattern;
    public GameObject stage4_sigpattern_zoomed;
<<<<<<< HEAD
    public GameObject FinishButton;
    public GameObject RetryButton;
    public GameObject CheckWoundText;
    public GameObject ZoomOutText;
=======
>>>>>>> b000dc568a7dd5e15d6e06694f18dd812fa25f60
    public float applytime = 8.0f;
    public float timer = 0f;
    public float total_timer = 0f;
    public float end_timer = 0f;
    public bool on_target;
    public bool training_UI;
    

    // Start is called before the first frame update
    void Start()

    {
        SigPattern.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Place Torniquet";
        GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
    }

    public void toggle_changed(bool newValue)
    {
        training_UI = newValue;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        on_target = true;

        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Applying Torniquet...";
            GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.yellow;
            BG.SetActive(true);
            SigPattern.SetActive(true);
            BarScript.AnimateBar();


        }

        else if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (ZoomedCamera.activeInHierarchy)
            {
                SigPattern_Zoomed.SetActive(true);
                if (timer >= 1f)
                {
                    SigPattern_Zoomed.SetActive(false);
                    stage1_sigpattern_zoomed.SetActive(true);
                    if (timer >= 3f)
                    {
                        stage1_sigpattern_zoomed.SetActive(false);
                        stage2_sigpattern_zoomed.SetActive(true);
                        if (timer >= 5f)
                        {
                            stage2_sigpattern_zoomed.SetActive(false);
                            stage3_sigpattern_zoomed.SetActive(true);
                            if (timer >= 7f)
                            {
                                stage3_sigpattern_zoomed.SetActive(false);
                                stage4_sigpattern_zoomed.SetActive(true);
                            }
                        }
                    }
                }
                
            }
            if (timer >= 1f)
            {
               SigPattern.SetActive(false);
               stage1_sigpattern.SetActive(true);
               if (timer >= 3f)
               {
                   stage1_sigpattern.SetActive(false);
                   stage2_sigpattern.SetActive(true);
                   if (timer >= 5f)
                   {
                       stage2_sigpattern.SetActive(false);
                       stage3_sigpattern.SetActive(true);
                       if (timer >= 7f)
                       {
                         stage3_sigpattern.SetActive(false);
                         stage4_sigpattern.SetActive(true);  
                       }
                   }

               }

            }
            if (stage4_sigpattern.activeInHierarchy || stage4_sigpattern_zoomed.activeInHierarchy)
            {
                CorrectLocation.SetActive(true);
                GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Torniquet Correct";
                GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.green;
                GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f; 
            }
        }

    }

    void OnMouseExit()
    {
        GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Place Torniquet";
        GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.red;
        GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 0f;
        BarScript.bar_off();
        SigPattern.SetActive(false);
        stage1_sigpattern.SetActive(false);
        stage2_sigpattern.SetActive(false);
        stage3_sigpattern.SetActive(false);
        stage4_sigpattern.SetActive(false);
        stage1_sigpattern_zoomed.SetActive(false);
        stage2_sigpattern_zoomed.SetActive(false);
        stage3_sigpattern_zoomed.SetActive(false);
        stage4_sigpattern_zoomed.SetActive(false);
        SigPattern_Zoomed.SetActive(false);
        on_target = false;
    }

    void Update()
    {
<<<<<<< HEAD
        if (training_UI = false)
        {
            correct_incorrect.SetActive(false);
        }
        
=======
>>>>>>> b000dc568a7dd5e15d6e06694f18dd812fa25f60
        total_timer += Time.deltaTime;

        float distance = Vector3.Distance(Torniquet.transform.position, transform.position);
        float distance1 = distance/0.02f;
        GameObject.Find("DistanceNumber").GetComponent<Text>().text = ((int) distance1).ToString();
        if (distance1 < 11)
        {
            GameObject.Find("DistanceNumber").GetComponent<Text>().text = "Near";
        }

        if (on_target == false)
            if (Input.GetMouseButtonDown(0))
            {
                
                GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Torniquet Incorrect";
                GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.red;
                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Place Torniquet";
                GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.red;
            }
        if (CorrectLocation.activeInHierarchy)
        {
<<<<<<< HEAD
            //end_timer += Time.deltaTime;
            GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f;
            GameObject.Find("correct/incorrect").GetComponent<Text>().text = "Torniquet Correct";
            GameObject.Find("correct/incorrect").GetComponent<Text>().color = Color.green;
            FinishButton.SetActive(true);
            RetryButton.SetActive(true);
            CheckWoundText.SetActive(true);

=======
            end_timer += Time.deltaTime;
            GameObject.Find("Army3-final").GetComponent<BluetoothSensor>().override_value = 70f;
            if (end_timer >= 5)
            { 
                StartMenu.ChangeScenetoResults();
            }
>>>>>>> b000dc568a7dd5e15d6e06694f18dd812fa25f60
        }
        if (Patient.health <= 0)
        {
            StartMenu.ChangeScenetoDied();
        }
<<<<<<< HEAD
        if (ZoomedCamera.activeInHierarchy  || CorrectLocation.activeInHierarchy)
        {
            ZoomOutText.SetActive(true);
        }
=======
>>>>>>> b000dc568a7dd5e15d6e06694f18dd812fa25f60
    }
           
}
