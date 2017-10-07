using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [HideInInspector]
    public Vector3 startingPosition;



    [HideInInspector]
    public bool isFollowing;

    [HideInInspector]
    public Transform birdToFollow;

    private void Awake()
    {
        startingPosition = transform.position;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing)
        {
            if(birdToFollow != null)
            {
                var birdPosition = birdToFollow.position;
                float x = Mathf.Clamp(birdPosition.x, GameVariables.minCameraX, GameVariables.maxCameraX);
                transform.position = new Vector3(x, startingPosition.y, startingPosition.z);
            } else
            {
                isFollowing = false;
            }

        }
	}
}
