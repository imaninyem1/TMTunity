using System.Collections.Generic;
using UnityEngine;
using Obi;

class BloodModerator : MonoBehaviour
{
    public Patient patient;
    public ObiEmitter emitter;
    public Material[] bloodyBodyArray;
    private Material[] cleanBody;
    public SkinnedMeshRenderer skinnedMesh;
    void replaceMaterial(Material toReplace) {
        Material[] newMaterials = new Material[skinnedMesh.materials.Length];
        for (int I = 0; I < skinnedMesh.materials.Length; I++)
        {
            newMaterials[I] = toReplace;
        }
        skinnedMesh.materials = newMaterials;
    }


    public void Start(){
        cleanBody = GameObject.Find("Body").GetComponent<SkinnedMeshRenderer>().materials;      
    }

    public void Update()
    {
        float bloodloss = patient.getBloodLoss();
        emitter.speed = 0.06f * bloodloss;
    // if statement to trigger Imani's bleeding visuals
        string healthStatus = patient.healthStatus;

        switch (healthStatus)
        {
            case "Stable Wounded":
              
                replaceMaterial(bloodyBodyArray[0]);
                break;
            case "Moderately Wounded":
                replaceMaterial(bloodyBodyArray[1]);
                break;
            case "Severly Wounded":
                replaceMaterial(bloodyBodyArray[2]);
                break;
            case "Deadly Wounded":
                replaceMaterial(bloodyBodyArray[3]);
                break;
            case "Dead":
                replaceMaterial(bloodyBodyArray[4]);
                break;
        }
    }

}