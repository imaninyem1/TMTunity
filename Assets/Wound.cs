using UnityEngine;

class Wound : MonoBehaviour {
    // has location (selected in start menu), pain multiplier (worse wounds = more pain), and blood multiplier (worse wounds = higher blood loss rate)

    public Wound(string loc, float blood, float pain) {
        this.location = loc;
        this.bloodMultiplier = blood;
        this.painMultiplier = pain;
    }

    public string location;
    public float bloodMultiplier;
    public float bloodMultiplierMultiplier;
    public float painMultiplier;
}