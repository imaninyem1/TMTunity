using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

    public Patient patient;
    public AudioClip[] clips; //array 
    public AudioMixerGroup output;
    public string prevStatus;

    // Update is called once per frame
    void Update() {


        string healthStatus = patient.healthStatus;


           if (healthStatus != prevStatus) {
               switch (healthStatus) {
                    case "Stable Wounded":
                        PlaySound();
                        break;
                    case "Moderately Wounded":
                        PlaySound();
                        break;
                    case "Severly Wounded":
                        PlaySound();
                        break;
                    case "Deadly Wounded":
                        PlaySound();
                        break;
                    case "Dead":
                        PlaySound();
                        break;
                }
           }
           prevStatus = healthStatus; 
    

        if (Input.GetKeyDown("space")) {
            PlaySound(); 
        }
    }

       void PlaySound() {
            //Randomize 
            int randomClip = Random.Range (0,clips.Length);

            //Create an AudioSource component on object
            AudioSource source = gameObject.AddComponent<AudioSource>();

            //Load clip into the AudioSource to play sound
            source.clip = clips[randomClip];

            //Set the output for AudioSource
            source.outputAudioMixerGroup = output;

            //Play the clip
            source.Play(0);
            //source.PlayOneShot(); 

            //Destroy the AudioSource after length of audio clip is done playing
            Destroy(source, clips[randomClip].length);
        }

}
