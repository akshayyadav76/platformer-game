using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
     [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] int health;
    [SerializeField] Slider healthBar;
    
    Rigidbody2D rb;
    Vector2 movementAmount;
    Animator animator;
    Collider2D myCollider2D;
    bool playerMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       animator =GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();

    }

    private void Update()
    {

        float movement = Input.GetAxis("Horizontal");
        movementAmount = new Vector2(movement * speed, rb.velocity.y);

        rb.velocity = movementAmount;
        playerMove = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerMove);
        flipSprite();
        jump();
          }

    private void jump()
    {
        //Debug.Log(rb.velocity);
        if(!myCollider2D.IsTouchingLayers(LayerMask.GetMask("fg"))){
             animator.SetBool("jump",true);
            return;}else{
             animator.SetBool("jump",false); 
            }
        if (Input.GetButtonDown("Jump"))
        {   
            Debug.Log("dfs");
            Vector2 jumpPlayer = new Vector2(0f, jumpSpeed);
            rb.velocity = jumpPlayer;

        }

       
    }
    private void flipSprite()
    {
   if (playerMove)
        {

            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    // private void FixedUpdate()
    // {

    //     //rb.MovePosition((Vector2)transform.position + (movementAmount *Time.deltaTime));
    //     //  rb.velocity = movementAmount;
    // }


    public void damagePlayer(int damageAmount){
        
        if(health <= 0){
            Debug.Log("Game Over");
        }else{
            
            health = health-damageAmount;
            healthBar.value= healthBar.value -damageAmount;
        }
        }

public void healthPich(int incress){
   
   if(health + incress >10){
       health = 10;
       healthBar.value = 10;
   }else{
    health = health +incress;
    healthBar.value = health; 
   }

}

}
