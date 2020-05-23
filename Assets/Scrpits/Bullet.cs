using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] int bullteDamageAmount;
    [SerializeField] GameObject hitParticlas;
    [SerializeField] float distance;
    [SerializeField] Transform bulletGo;
    [SerializeField] GameObject hitRock;
    Player player;
    EffectsAudio effectsAudio;
 
    void Start()
    {
        player = FindObjectOfType<Player>();
        effectsAudio = FindObjectOfType<EffectsAudio>();
        
    }


    void Update()
    {
        //Debug.Log("roate"+ transform.localPosition);

        if (transform.rotation.z < -0f)
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
       else if (transform.rotation.z > 0f)
        {
             transform.rotation = Quaternion.Euler(0,0,90);
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }


        Destroy(this.gameObject, distance);

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (player.tag == "player")
        {
            return;
        }
        if (other.tag == "enmey")
        {
         effectsAudio.hitEnemey();
         Instantiate(hitParticlas, transform.position, transform.rotation);

            
           var getEnemy= other.GetComponent<Enemey>();
            getEnemy.healthBar();
            getEnemy.takeDamage(bullteDamageAmount);
            Destroy(this.gameObject);
        }
        if(other.tag == "rock"){
        effectsAudio.hitEnemey();
        Instantiate(hitRock, transform.position, transform.rotation);
        Destroy(this.gameObject);
        }

    }


   
}
