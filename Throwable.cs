using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Throwable : MonoBehaviour {

    UnityEvent eventPickUp = new UnityEvent();
    UnityEvent eventThrow = new UnityEvent();

    private Vector3 throwVelocity, previousPosition;
    const int samples = 3;
    // Use this for initialization
    void Start () {
        eventPickUp.AddListener(Hold);
        eventThrow.AddListener(Release);
    }
	
	// Update is called once per frame
	void Update () {
        //Based on previous position
        Vector3 frameVelocity = (transform.position - previousPosition) / Time.deltaTime;
        throwVelocity = throwVelocity * (samples - 1) / samples + frameVelocity / samples;
        previousPosition = transform.position;
        if (GvrControllerInput.ClickButton == true)
        {
            eventPickUp.Invoke();
        }
        if (GvrControllerInput.ClickButtonUp == true)
        {
            eventThrow.Invoke();
        }
	}

    public void Hold ()
    {
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;
        transform.SetParent(pointerTransform, false);
        transform.localPosition = new Vector3(0, 0, 1);
        //Don't want the object to interact with other colliders just yet
        //GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Release ()
    {
        transform.SetParent(null, true);
        Rigidbody rb = GetComponent<Rigidbody>();
        //Reset velocity
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        rb.AddForce(throwVelocity, ForceMode.VelocityChange);
    }


}
