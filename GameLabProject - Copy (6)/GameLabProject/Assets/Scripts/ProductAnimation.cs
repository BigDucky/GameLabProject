using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductAnimation : MonoBehaviour {

    public float maxRayDistance = 25;

    private void FixedUpdate()
    {   
        if(Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.gameObject.tag == "Money")
                {
                    Debug.Log("Add money to the player");
                }
                
            }
        }
    }

}
