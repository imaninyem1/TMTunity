using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torniquet : MonoBehaviour
{
     public Transform moveThis;
     public LayerMask hitLayers;
    // Start is called before the first frame update
    void Start()
    {
       //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 mouse = Input.mousePosition;
         Ray castPoint = Camera.main.ScreenPointToRay(mouse);
         RaycastHit hit;
         if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
         {
             moveThis.transform.position = new Vector3(hit.point.x, 0.27f, hit.point.z);
             
         }

         
    }
}
