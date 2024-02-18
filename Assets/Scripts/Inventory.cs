using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Resource, int> items; 
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.GetType() == typeof(Resource))
        {
            items[col.collider.GetComponent<Resource>()]++; 
        }
    }
  
}
