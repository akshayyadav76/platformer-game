using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] int incressHealth;

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
           other.GetComponent<Player>().healthPich(incressHealth);
            Destroy(this.gameObject);
        }
       
    }
}
