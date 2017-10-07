using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip clip;

    public float health = 70f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clip = audioSource.clip;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            return;
        }

        float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;
        DealDamage(damage);



    }

    private void DealDamage(float damage)
    {
        if (damage > 10) AudioSource.PlayClipAtPoint(clip,transform.position);

        health -= damage;

        if (health <= 0) Destroy(gameObject);
    }


}
