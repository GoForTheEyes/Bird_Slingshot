using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables {

    public static float minVelocity = 0.09f;  //if the bird is ever moving with a velocity < minVelocity we will destroy the gameObject

    public static float birdColliderRadiusNormal = 0.54f;
    public static float birdColliderRadiusBig = 0.64f;  //The collider will expand when the user is throwing it to improve UX
                                                        //it will go down to normal in flight.

    public static float minCameraX = 0f;
    public static float maxCameraX = 19f;

    public static float minCameraY = 0f;
    public static float maxCameraY = 1.8f;






}
