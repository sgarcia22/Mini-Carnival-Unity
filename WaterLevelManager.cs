using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelManager : MonoBehaviour {

    public static bool shooting = false;
    private Vector3 originalPos;
	// Use this for initialization
	void Start () {
        originalPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (originalPos.y > 2.5f + gameObject.transform.position.y)
        {
            WaterGunController.notReachedEndpoint = true;
            return;
        }
		if (shooting)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y -= .5f * Time.deltaTime;
            gameObject.transform.position = pos;
        }
	}
}
