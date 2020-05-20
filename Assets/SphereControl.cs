using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) 
        {
            print("hello");
            gameObject.SetActive(true);
        }
        // if (Input.GetKeyUp(key))
        // {
        //    gameObject.SetActive(false);
        // }
        
    }
}
