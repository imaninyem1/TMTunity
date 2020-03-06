using System.Collections.Generic;
using UnityEngine;
using Obi;

class BloodModerator : MonoBehaviour
{
    public Patient patient;
    public ObiEmitter emitter;

    void FixedUpdate()
    {
    // if statement to trigger Imani's bleeding visuals
        string bloodStatus = patient.bloodStatus;

        switch (bloodStatus)
        {
            case "Heaviest Bleeding":
                emitter.NumParticles = 3000;
                break;
            case "Heavy Bleeding":
                emitter.NumParticles = 2000;
                break;
            case "Moderate Bleeding":
                emitter.NumParticles = 1500;
                break;
            case "Low Bleeding":
                emitter.NumParticles = 650;
                break;
            case "Lowest Bleeding":
                emitter.NumParticles = 250;
                break;
            case "No Bleeding":
                emitter.NumParticles = 50;
                break;
        }
    }

}