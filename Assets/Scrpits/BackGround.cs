using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
   [SerializeField] float speed;
   Material bg;


   private void Start(){
      bg = GetComponent<Renderer>().material;
   }


private void Update(){
    bg.mainTextureOffset += new Vector2(speed ,0f) *Time.deltaTime;
}
   
}
