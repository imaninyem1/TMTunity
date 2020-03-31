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

    // Update is called once per frame
    void Update() {

        string painStatus = patient.healthStatus;
        animator = gameObject.GetComponent<Animator>();


        float health = patient.health;
        if (health <= 100 && health > 75) {
            animator.SetInteger("painStatus", 0);
            if (stableWounded.time == 0) {  
                stableWounded.Play(0); //play audio
            }
        }
        else if (health <= 75 && health > 50) {
            animator.SetInteger("painStatus", 1);
            if (moderatelyWounded.time == 0) {
                moderatelyWounded.Play(0);
            }
        }
        else if (health <= 50 && health > 25) {
            animator.SetInteger("painStatus", 2);
            if (severelyWounded.time == 0) {
                severelyWounded.Play(0);
            }
        }
        else if (health <= 25 && health > 0) {
            animator.SetInteger("painStatus", 3); 
            if (deadlyWounded.time == 0) {
                deadlyWounded.Play(0);
            }
        }
        else {
            animator.SetInteger("painStatus", 4);
            if (dead.time == 0) {
                dead.Play(0);
            }
        }
        

    }
}
