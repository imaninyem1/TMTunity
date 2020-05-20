using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public GameObject BG;
    public int time;
    public float zero_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
        BG.SetActive(true);
    }

    public void bar_off() 
    {
        LeanTween.scaleX(bar, 0, zero_time);
        BG.SetActive(false);
    }
}
