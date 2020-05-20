using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

    public Patient patient;
    public AudioClip[] clips; //array 
    public AudioClip[] stableClips; 
    public AudioClip[] moderateClips;
    public AudioClip[] severeClips;
    public AudioClip[] deadlyClips;
    public AudioClip[] deadClips;
    public AudioMixerGroup output;
    public string prevStatus;

    // Update is called once per frame
    void Update() {


        string healthStatus = patient.healthStatus;


           if (healthStatus != prevStatus) {
               switch (healthStatus) {
                    case "Stable Wounded":
                        PlaySound(stableClips);
                        break;
                    case "Moderately Wounded":
                        PlaySound(moderateClips);
                        break;
                    case "Severly Wounded":
                        PlaySound(severeClips);
                        break;
                    case "Deadly Wounded":
                        PlaySound(deadlyClips);
                        break;
                    case "Dead":
                        PlaySound(deadClips);
                        break;
                }
           }
           prevStatus = healthStatus; 
    }

       void PlaySound(AudioClip[] clips) {
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
