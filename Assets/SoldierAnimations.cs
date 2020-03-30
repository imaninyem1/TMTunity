using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimations : MonoBehaviour {

    public Animator animator;
    public Patient patient; //reference to Patient script in scene
    public AudioSource stableWounded;
    public AudioSource moderatelyWounded;
    public AudioSource severelyWounded;
    public AudioSource deadlyWounded;
    public AudioSource dead;
    //float painStatus; 
    
    // Update is called once per frame
    void Update() {
        /*animator.SetInteger("painStatus", gameObject.GetComponent<Patient>().getPain());*/
        string painStatus = patient.healthStatus;
        animator = gameObject.GetComponent<Animator>();


        float health = patient.health;
        if (health <= 100 && health > 75) {
            animator.SetInteger("painStatus", 0);  
            stableWounded.Play(0); //play audio
        }
        else if (health <= 75 && health > 50) {
            animator.SetInteger("painStatus", 1);
            moderatelyWounded.Play(0);
        }
        else if (health <= 50 && health > 25) {
            animator.SetInteger("painStatus", 2);
            severelyWounded.Play(0);
        }
        else if (health <= 25 && health > 0) {
            animator.SetInteger("painStatus", 3); 
            deadlyWounded.Play(0);
        }
        else {
            animator.SetInteger("painStatus", 4);
            dead.Play(0);
        }
        
        /* switch (painStatus) {
             case "Stable Wounded":
                 animator.SetInteger("painStatus", 0);
                 break;

             case "Moderately Wounded":
                 animator.SetInteger("painStatus", 1);
                 break;
                
             case "Severely Wounded":
                 animator.SetInteger("painStatus", 2);
                 break;
            
             case "Deadly Wounded":
                 animator.SetInteger("painStatus", 3);
                 break;

             case "Dead":
                 animator.SetInteger("painStatus", 4);
                 break;

             default:
                 animator.SetInteger("painStatus", 0);
                 break;
         }*/
        /*        switch (painStatus) {
                    case "Low Pressure":
                        animator.SetInteger("painStatus", 0);
                        break;

            case "Dying":
                animator.SetInteger("painStatus", 1);
                break;
                
            case "High Pressure":
                animator.SetInteger("painStatus", 2);
                break;
            
            case "Stable Animation":
                animator.SetInteger("painStatus", 3);
                break;
        }*/

    }
}
