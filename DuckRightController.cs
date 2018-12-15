using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckRightController : MonoBehaviour {

    private Vector3 origPosition;
    private float move = 1f;
    // Use this for initialization
    void Start()
    {
        origPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
        if (gameObject.transform.position.x < origPosition.x - 15f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "duck")
        {
            DuckHuntManager.Score += 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
