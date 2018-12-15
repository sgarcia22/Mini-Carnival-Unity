using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckHuntManager : MonoBehaviour {

    public static int Score = 0;
    public Text scoreText;
    public GameObject leftDuck;
    public GameObject rightDuck;
    private float randomSpawnTime;
    private float time;
    private float totalTime = 0;
    [SerializeField]
    private int rangeOfSpawn = 5;
    // Use this for initialization
    void Start () {
        Instantiate(leftDuck);
        randomSpawnTime = 1;
        Debug.Log(randomSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        totalTime = Time.time;
        if (totalTime > 60)
        {
            return;
        }
        scoreText.text = Score.ToString();
        if (time > randomSpawnTime)
        {
            randomSpawnTime = Random.Range(0, 3);
            time = 0;
            if (Random.Range(0,2) == 1)
            {
                GameObject go = Instantiate(rightDuck);
                Vector3 pos = go.transform.position;
                if (Random.Range(0, 2) == 1)
                {
                    pos.y -= Random.Range(0, rangeOfSpawn) % 10;
                }
                else
                {
                    pos.y += Random.Range(0, rangeOfSpawn) % 10;
                }
                go.transform.position = pos;
            }
            else
            {
                GameObject go = Instantiate(leftDuck);
                Vector3 pos = go.transform.position;
                if (Random.Range(0, 2) == 1)
                {
                    pos.y -= Random.Range(0, rangeOfSpawn) % 10;
                }
                else
                {
                    pos.y += Random.Range(0, rangeOfSpawn) % 10;
                }
                go.transform.position = pos;
            }
        }
	}
}
