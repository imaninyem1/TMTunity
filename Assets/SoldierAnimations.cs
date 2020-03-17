using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimations : MonoBehaviour {

    public Animator animator;
    public Patient patient; //reference to Patient script in scene

    //float painStatus; 
    
    // Update is called once per frame
    void Update() {
        /*animator.SetInteger("painStatus", gameObject.GetComponent<Patient>().getPain());*/
        string painStatus = patient.healthStatus;
        animator = gameObject.GetComponent<Animator>();
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

        float health = patient.health;
        if (health <= 100 && health > 75) {
            animator.SetInteger("painStatus", 0);  
        }
        else if (health <= 75 && health > 50) {
            animator.SetInteger("painStatus", 1);
        }
        else if (health <= 50 && health > 25) {
            animator.SetInteger("painStatus", 2);
        }
        else if (health <= 25 && health > 0) {
            animator.SetInteger("painStatus", 3); 
        }
        else {
            animator.SetInteger("painStatus", 4);
        }

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
