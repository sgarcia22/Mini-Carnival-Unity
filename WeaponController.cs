using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject player;
    public GameObject gun;
    public GameObject endBarrel;
    //public GameObject bulletHole;
    private LineRenderer teleportLine;
    private float range = 300;
    [SerializeField]
    private float distance = 100f;
    private RaycastHit hit;
    private bool shoot = true;
    // Use this for initialization
    void Start () {
        teleportLine = GetComponent<LineRenderer>();
	}

    // Update is called once per frame
    void Update()
    {

        if (GvrControllerInput.ClickButtonDown == true && shoot == true)
        {
            shoot = false;
            Quaternion controllerQuad = GvrController.Orientation;
            Vector3 controllerForward = controllerQuad * Vector3.forward;

            GameObject go = Instantiate(endBarrel, endBarrel.transform.position, endBarrel.transform.rotation) as GameObject;
            go.transform.SetParent(gameObject.transform);
            go.SetActive(true);
            go.GetComponent<Rigidbody>().AddForce(controllerForward * 2000);
            gun.GetComponent<Animation>().Play();
        }
        if (GvrControllerInput.ClickButtonUp == true)
        {
            shoot = true;
        }
        /*if (GvrControllerInput.AppButton)
        {
            teleportLine.enabled = true;
            teleportLine.SetPosition(0, endBarrel.transform.position);
            //Teleport 
            Debug.Log("Pressing Button");
            //Quaternion controllerQuad = GvrController.Orientation;
           // Vector3 controllerForward = controllerQuad * Vector3.forward;
            if (Physics.Raycast(endBarrel.transform.position, gun.transform.forward, out hit, range))
            {
                teleportLine.SetPosition(1, hit.point);
            }
            else
            {
                teleportLine.SetPosition(1, gun.transform.forward * range);
                
            }

        }
        if (GvrControllerInput.AppButtonUp)
        {
            Vector3 currPos = player.transform.position;
            Vector3 teleportPos = hit.point;
            teleportPos.y = currPos.y;
            teleportLine.enabled = false;
            player.transform.position = teleportPos;
        }
        */
            //Home Button Down -- Menu
        }
}
