using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag =="Bird" || target.tag == "Destructible" || target.tag == "Pig")
        {
            Destroy(target.gameObject);
        }
    }
}
