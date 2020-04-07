using System.Collections.Generic;
using UnityEngine;
using Obi;

class BloodModerator : MonoBehaviour
{
    public Patient patient;
    public ObiEmitter emitter;
    public Material[] bloodyBodyArray;
    private Material[] cleanBody;

    public void Start(){
        cleanBody = GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().materials;      
    }

    public void Update()
    {
        float bloodloss = patient.getBloodLoss();
        emitter.speed = 0.10f * bloodloss;
    // if statement to trigger Imani's bleeding visuals
        string healthStatus = patient.healthStatus;

        switch (healthStatus)
        {
            case "Stable Wounded":
                //GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().materials = cleanBody;
                break;
            case "Moderately Wounded":
                GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().materials = bloodyBodyArray;
                break;
            case "Severly Wounded":
                GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().materials = bloodyBodyArray;
                break;
            case "Deadly Wounded":
                break;
            case "Dead":
             
                break;
        }
    }

}