using System.Collections.Generic;
using UnityEngine;
using Obi;

class BloodModerator : MonoBehaviour
{
    public Patient patient;
    public ObiEmitter emitter;

    void Update()
    {
    // if statement to trigger Imani's bleeding visuals
        string healthStatus = patient.healthStatus;

        switch (healthStatus)
        {
            case "Stable Wounded":
                emitter.NumParticles = 500;
                break;
            case "Moderately Wounded":
                emitter.NumParticles = 750;
                break;
            case "Severly Wounded":
                emitter.NumParticles = 1000;
                break;
            case "Deadly Wounded":
                emitter.NumParticles = 500;
                break;
            case "Dead":
                emitter.NumParticles = 50;
                break;
        }
    }

}