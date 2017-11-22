using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEngine : MonoBehaviour {

    private Vector3 newPos; 

    //Making the camera pixel perfect
        public static float RoundToNearestPixel(float unityUnits, Camera viewingCamera)
        {
            float valueInPixels = (Screen.height / (viewingCamera.orthographicSize * 2)) * unityUnits;
            valueInPixels = Mathf.Round(valueInPixels);
            float adjustedUnityUnits = valueInPixels / (Screen.height / (viewingCamera.orthographicSize * 2));
            return adjustedUnityUnits;
        }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 roundPos = new Vector3(RoundToNearestPixel(newPos.x, GetComponent<Camera>()), RoundToNearestPixel(newPos.y, GetComponent<Camera>()), newPos.z);
        transform.position = roundPos;
    }

    
}
