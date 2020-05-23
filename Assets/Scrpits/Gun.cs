using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform  shootPoint;
    [SerializeField] GameObject flashParticlas;
    [SerializeField] float timeBetweenShoot;

    private float shootTime;

    
    

    private void Update(){
     
     if(Input.GetMouseButtonDown(0)){
     if(Time.time >= shootTime){
         Debug.Log("this must be "+ shootPoint.eulerAngles);
         Instantiate(flashParticlas,shootPoint.position,shootPoint.transform.rotation);
         Instantiate(bullet,shootPoint.position,shootPoint.transform.rotation);
         shootTime = Time.time+timeBetweenShoot;
     }

    }
    }
}

// 



