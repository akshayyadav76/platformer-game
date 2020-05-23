using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStay : Enemey
{
   
    private bool posLeft = true;
    
    private void Update()
    {
        if(posLeft){
         transform.localScale = new Vector2(1, transform.localScale.y);
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }else{
           transform.localScale = new Vector2(-1, transform.localScale.y);
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
    }

    
    void OnTriggerExit2D()
    {   
        posLeft = !posLeft;
    }
}
