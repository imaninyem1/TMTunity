using System.Collections.Generic;
using UnityEngine;

class Patient : MonoBehaviour {
    // patient class has list of sensors, the wound, and a starting health of 100

    /*public Patient(List<Sensor> sensors, Wound wound) {
        this.sensors = sensors;
        this.wound = wound;
        this.health = 100;
    }*/

    public List<Sensor> sensors;
    public Wound wound;
    public float health;

    public string healthStatus;
    private int bloodMultiplierMultiplier;
    public string painStatus;

    public string bloodStatus;
    public Animator Animator;

    void FixedUpdate() {

        // updates health by multiplying blood loss rate by time step
        // if statements categorize health into five stages
        // each stage will have less animations and blood loss as base state
        // if pressure is being applied, more or less animations and blood can be triggered
        health -= getBloodLoss() * Time.deltaTime;

        if (health <= 100 && health > 75) {
            healthStatus = "Stable Wounded";
            bloodMultiplierMultiplier = 2;
        }
        else if (health <= 75 && health > 50) {
            healthStatus = "Moderately Wounded";
        }
        else if (health <= 50 && health > 25) {
            healthStatus = "Severely Wounded";
        }
        else if (health <= 25 && health > 0) {
            healthStatus = "Deadly Wounded";
        }
        else {
            healthStatus = "Dead";
        }

        // if statement to trigger Kaila's animations
        float pain = getPain();

        if (pain < 0) {
            painStatus = "Low Pressure";
        }
        else if (healthStatus == "Deadly Wounded") {
            painStatus = "Dying";
        }
        else if (pain > 0) {
            painStatus = "High Pressure";
        }
        else {
            painStatus = "Stable Animation";
        }

        // if statement to trigger Imani's bleeding visuals
        float bloodLoss = getBloodLoss();
        if (bloodLoss <= 1 && bloodLoss > 0.8) {
            bloodStatus = "Heaviest Bleeding";
        }
        else if (bloodLoss <= 0.8 && bloodLoss > 0.6) {
            bloodStatus = "Heavy Bleeding";
        }
        else if (bloodLoss <= 0.6 && bloodLoss > 0.4) {
            bloodStatus = "Moderate Bleeding";
        }
        else if (bloodLoss <= 0.4 && bloodLoss > 0.2) {
            bloodStatus = "Low Bleeding";
        }
        else if (bloodLoss <= 0.2 && bloodLoss > 0) {
            bloodStatus = "Lowest Bleeding";
        }
        else {
            bloodStatus = "No Bleeding";
        }
    }
    public float getPain() {
        // gets pain value by calculating pain from each sensor
        float pain = 0;
        foreach(Sensor sensor in sensors) {
            pain += calculatePain(sensor);
        }
        return pain / sensors.Count;
    }

    public float getBloodLoss() {
        // gets blood loss rate by calculating blood loss rate for each sensor
        float bloodLoss = 0;
        foreach(Sensor sensor in sensors) {
            bloodLoss += calculateBloodLoss(sensor);
        }
        return bloodLoss / sensors.Count;
    }

    private float calculatePain(Sensor sensor) {
        // uses minimum and max optimal pressure from Sensor class
        // if current pressure is below min or above max, will multiply the value by pain multiplier
        float minOpt = sensor.minOptimalPressure;
		float maxOpt = sensor.maxOptimalPressure;
		float current = sensor.currentPressure;
		float max = Sensor.maxPressure;

		float painBelow = 1 - (current/minOpt);
		float painAbove = (current-maxOpt) / (max-maxOpt);
		float painTotal = clamp01(Patient.max(painBelow, painAbove));
        if (painAbove < painBelow) {
            return -(painTotal * wound.painMultiplier);
        }
		else {
            return painTotal * wound.painMultiplier;
        }
        
    }

    private float calculateBloodLoss(Sensor sensor) {
        // only uses minimum optimal pressure since blood loss would occur only when pressure is low
        // gets ration of current pressure to mimum optimal pressure and multiplies it by blood multiplier
        float minOpt = sensor.minOptimalPressure;
        float current = sensor.currentPressure;

        float bloodLoss = clamp01(1 - (current / minOpt));
        return bloodLoss * wound.bloodMultiplier * bloodMultiplierMultiplier;
    }

    public static float clamp01(float a) {
        // keeps values for blood and pain calculations between 0 and 1
        if (a > 1) {
            return 1;
        }
        else if (a < 0) {
            return 0;
        }
        else return a;
    }

    public static float max(float a, float b) {
        return a > b ? a : b;
    }
}