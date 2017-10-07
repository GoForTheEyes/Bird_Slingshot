using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour {

    public BirdState birdState { set; get; }

    private TrailRenderer trailRenderer;
    private Rigidbody2D myBody;
    private CircleCollider2D myCollider;
    private AudioSource audioSource;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        trailRenderer.enabled = false;
        trailRenderer.sortingLayerName = "Foreground";
        myBody.isKinematic = true;
        myCollider.radius = GameVariables.birdColliderRadiusBig;
        birdState = BirdState.BeforeThrown;

    }

    IEnumerator DestroyAfterDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }



    public void OnThrow()
    {
        audioSource.Play();
        trailRenderer.enabled = true;
        myBody.isKinematic = false;
        myCollider.radius = GameVariables.birdColliderRadiusNormal;
        birdState = BirdState.Thrown;
    }


	// Update is called once per frame
	void FixedUpdate () {
		if (birdState == BirdState.Thrown && myBody.velocity.sqrMagnitude <= GameVariables.minVelocity)
        {
            StartCoroutine(DestroyAfterDelay(2f));
        }
	}
}
