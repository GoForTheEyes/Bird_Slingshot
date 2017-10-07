using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip clip;

    public float health = 150f;
    public Sprite spriteShownWhenHurt;
    private float changeSpriteHealth;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        clip = audioSource.clip;
        changeSpriteHealth = health - 30f;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            return;
        } 

        if (collision.gameObject.tag =="Bird")
        {
            audioSource.Play();
            Destroy(gameObject);
        } else
        {
            float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;
            if (damage >= 10) AudioSource.PlayClipAtPoint(clip, transform.position);
            health -= damage;
            if (health < changeSpriteHealth) gameObject.GetComponent<SpriteRenderer>().sprite = spriteShownWhenHurt;
            if (health <= 0) Destroy(gameObject);
        }
    }
    
}
