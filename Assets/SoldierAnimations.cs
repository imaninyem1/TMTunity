using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimations : MonoBehaviour {

    public Animator animator;
    public Patient patient; //reference to Patient script in scene


    // Update is called once per frame
    void Update() {

        string painStatus = patient.healthStatus;
        animator = gameObject.GetComponent<Animator>();


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
        

    }
}
