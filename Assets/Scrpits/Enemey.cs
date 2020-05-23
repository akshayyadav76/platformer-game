using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject bar;
    public float decressHalthBarValue;
    public int playerDamageAmount;
    EffectsAudio effectsAudio;

    [HideInInspector]
    public bool enmeyColideToPlayer = false;

    [SerializeField] GameObject explodeParticals;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Player player;
    private Transform[] allChilder;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        allChilder = player.GetComponentsInChildren<Transform>();
        effectsAudio = FindObjectOfType<EffectsAudio>();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            effectsAudio.enemyExplod();
            Instantiate(explodeParticals, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

    public void healthBar()
    {
        bar.transform.localScale = new Vector2(bar.transform.localScale.x - decressHalthBarValue, 1.2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("workng");
            enmeyColideToPlayer = true;
            
            foreach (Transform Child in allChilder)
            {
                if (Child.tag == "parts")
                {
                    Child.gameObject.SetActive(false);
                }
            }
          //  player.transform.position = new Vector2(player.transform.position.x +1f,player.transform.position.y);
            StartCoroutine(damagePlayer());
        }
enmeyColideToPlayer = false;
    }

    IEnumerator damagePlayer()
    {
        player.damagePlayer(playerDamageAmount);
        yield return new WaitForSeconds(0.3f);
        foreach (Transform Child in allChilder)
        {
            if (Child.tag == "parts")
            {
                Child.gameObject.SetActive(true);
            }
        }
        
    }


}
