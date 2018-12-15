using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bulletHole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //Spawn Quad with bullet Hole

        Quaternion rot;//? = Quaternion.LookRotation(collision.contacts[0].normal);
        rot = Quaternion.FromToRotation(collision.contacts[0].normal, Vector3.forward) * Quaternion.Euler(90, 0, 0);
        //GameObject go = Instantiate(bulletHole, collision.contacts[0].point + collision.contacts[0].normal * .01f, rot);

        //Destroy bullet
        Destroy(gameObject);
    }

}
