using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
    public bool rotating = false;
    public float curAngle;
    public float rotSpeed = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.CompareTag("Player"))
        {
            GameController.instance.BirdScored();
        }
        
    }
}
