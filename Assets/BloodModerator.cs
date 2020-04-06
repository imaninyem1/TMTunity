using System.Collections.Generic;
using UnityEngine;
using Obi;

class BloodModerator : MonoBehaviour
{
    public Patient patient;
    public ObiEmitter emitter;

    void Update()
    {
        float bloodloss = patient.getBloodLoss();
        emitter.speed = 0.25f * bloodloss;
    // if statement to trigger Imani's bleeding visuals
        string healthStatus = patient.healthStatus;

        /*switch (healthStatus)
        {
            case "Stable Wounded":

                emitter.speed = 0.5f;
                break;
            case "Moderately Wounded":
                emitter.speed = 0.4f;
                break;
            case "Severly Wounded":
                emitter.speed = 0.3f;
                break;
            case "Deadly Wounded":
                emitter.speed = 0.2f;
                break;
            case "Dead":
                emitter.speed = 0.1f;
                break;
        }*/
    }

}