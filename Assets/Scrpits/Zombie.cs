using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemey
{
   

   private void Update(){
      
      if(!enmeyColideToPlayer){

          if(player.transform.position.x >= transform.position.x)
      {
          transform.localScale = new Vector2(1,transform.localScale.y);
      transform.Translate(Vector2.right * speed*Time.deltaTime );
      }else if(player.transform.position.x+1f <= transform.position.x){
          transform.localScale = new Vector2(-1,transform.localScale.y);
              transform.Translate(Vector2.left * speed*Time.deltaTime );
      }
      }
      
   }


    
}
