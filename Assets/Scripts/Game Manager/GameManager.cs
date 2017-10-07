using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public CameraFollow cameraFollow;
    public GameplayController gamePlayController;

    int currentBirdIndex;

    public SlingShot slingShot;

    [HideInInspector]
    public static GameState gameState;

    private List<GameObject> objects;
    private List<GameObject> birds;
    private List<GameObject> pigs;
    private bool endMenu;

    private void Awake()
    {
        gameState = GameState.Start;
        slingShot.enabled = false;
        slingShot.slingshotLineRenderer1.enabled = false;
        slingShot.slingshotLineRenderer2.enabled = false;
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Destructible"));
        birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bird"));
        pigs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pig"));

    }

    private void OnEnable()
    {
        slingShot.birdThrown += SlingShotBirdThrown;
    }

    private void OnDisable()
    {
        slingShot.birdThrown -= SlingShotBirdThrown;
    }

	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.Start:
                if (Input.GetMouseButtonUp(0))
                {
                    gameState = GameState.BirdMovingToSlingShot;
                    AnimateBirdToSlingshot(); //Moves GameState to BirdMovingToSlingShot
                }
                break;

            case GameState.BirdMovingToSlingShot:

                //This is taken care in AnimateBirdToSlingshot()

                break;

            case GameState.Playing:

                if (slingShot.slingshotState == SlingshotState.BirdFlying)
                {
                    slingShot.enabled = false;
                    slingShot.slingshotLineRenderer1.enabled = false;
                    slingShot.slingshotLineRenderer2.enabled = false;
                    bool birdThrownResolved = ObjectsBirdsPigsStoppedMoving();
                    if (birdThrownResolved)                 //if bird was flying and no object is moving
                    {
                        gameState = GameState.BirdMovingToSlingShot;
                        AnimateCameraToStartPosition(); //Moves GameState to BirdMovingToSlingShot
                    }
                }
                
                break;

            case GameState.Won:

                if (Input.GetMouseButtonDown(0))
                {
                    if (!endMenu)
                    {
                        gamePlayController.GameOver(true);
                        endMenu = true;
                    }
                    
                }
                break;


            case GameState.Lost:

                if (Input.GetMouseButtonDown(0))
                {
                    gamePlayController.GameOver(false);
                    endMenu = true;
                }
                break;


        }
	}

    void AnimateBirdToSlingshot()
    {
        
        birds[currentBirdIndex].transform.positionTo(Vector2.Distance(birds[currentBirdIndex].transform.position / 10,
            slingShot.birdWaitPosition.position) / 10, slingShot.birdWaitPosition.position).
            setOnCompleteHandler((x) =>
           {
               x.complete();
               x.destroy(); //Complete tween and "destroy" tween animation
               gameState = GameState.Playing;
               slingShot.enabled = true;
               slingShot.slingshotLineRenderer1.enabled = true;
               slingShot.slingshotLineRenderer2.enabled = true;
               slingShot.birdToThrow = birds[currentBirdIndex];
               slingShot.slingshotState = SlingshotState.Idle;
           });
    }

    bool ObjectsBirdsPigsStoppedMoving()
    {
        foreach(var item in objects.Union(birds).Union(pigs) )
        {
            if (item != null && item.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > GameVariables.minVelocity)
            {
                return false;
            }
        } 
        return true;
    }

    private bool AllPigsAreDestroyed ()
    {
        return pigs.TrueForAll(x => x == null);
    }

    private void AnimateCameraToStartPosition()
    {
        float duration = Vector2.Distance(Camera.main.transform.position, cameraFollow.startingPosition) / 10f;
        if (duration == 0.0f)
            duration = 0.1f;

        Camera.main.transform.positionTo(duration, cameraFollow.startingPosition).
            setOnCompleteHandler((x) =>
            {
                cameraFollow.isFollowing = false;
                if (AllPigsAreDestroyed())
                {
                    gameState = GameState.Won;
                    GameWon();
                }
                else if (currentBirdIndex == 2)
                {
                    gameState = GameState.Lost;
                }
                else
                {
                    slingShot.slingshotState = SlingshotState.Idle;
                    currentBirdIndex++;
                    gameState = GameState.BirdMovingToSlingShot;
                    AnimateBirdToSlingshot();
                }
            });
    }

    private void SlingShotBirdThrown()
    {
        cameraFollow.birdToFollow = birds[currentBirdIndex].transform;
        cameraFollow.isFollowing = true;
    }


    private void GameWon()
    {
        int currentStars = 3 - currentBirdIndex;
        Debug.Log(currentBirdIndex);
        Debug.Log(currentStars);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (currentStars > PlayerPrefsManager.Get_LEVEL1_STARS() )
            {
                PlayerPrefsManager.Set_LEVEL1_STARS(currentStars);
            }

            if (PlayerPrefsManager.Get_LEVEL2_UNLOCKED() == 0)
            {
                PlayerPrefsManager.Set_LEVEL2_UNLOCKED(1);
            }

        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (currentStars > PlayerPrefsManager.Get_LEVEL2_STARS())
            {
                PlayerPrefsManager.Set_LEVEL2_STARS(currentStars);
            }

            if (PlayerPrefsManager.Get_LEVEL3_UNLOCKED() == 0)
            {
                PlayerPrefsManager.Set_LEVEL3_UNLOCKED(1);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (currentStars > PlayerPrefsManager.Get_LEVEL3_STARS())
            {
                PlayerPrefsManager.Set_LEVEL3_STARS(currentStars);
            }
        }
    }

    


}
