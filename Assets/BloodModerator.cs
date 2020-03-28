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
                emitter.NumParticles = 3000;
                break;
            case "Moderately Wounded":
                emitter.NumParticles = 2000;
                break;
            case "Severly Wounded":
                emitter.NumParticles = 1500;
                break;
            case "Deadly Wounded":
                emitter.NumParticles = 650;
                break;
            case "Dead":
                emitter.NumParticles = 50;
                break;
        }
    }

}