using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGunController : MonoBehaviour {
    public Text timer;
    private float timePassed;
    public GameObject player;
    public GameObject gun;
    public GameObject endBarrel;
    //public GameObject bulletHole;
    private LineRenderer shootLine;
    //private RaycastHit hit;
    private bool shoot = true;
    private bool firstHit = false;
    public static bool notReachedEndpoint = false;

    // Use this for initialization
    void Start () {
        timePassed = 0;
        shootLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstHit == true && notReachedEndpoint == false) {
            timePassed += Time.deltaTime;
            timer.text = timePassed.ToString();
        }
        if (GvrControllerInput.ClickButton == true)
        {
            shootLine.enabled = true;
            //shootLine.SetPosition(0, endBarrel.transform.position);
            //Teleport 

            List<Vector3> positions = curvedRaycast(endBarrel.transform.position, gun.transform.forward, 2, 30);
            shootLine.positionCount = positions.Count + 1;
            shootLine.SetPosition(0, endBarrel.transform.position);
            
            for (int i = 0; i < positions.Count; ++i)
            {
                if (positions[i] != null)
                    shootLine.SetPosition(i + 1, positions[i]);
            }
        }
        if (GvrControllerInput.ClickButtonUp == true)
        {
            shootLine.enabled = false;
            WaterLevelManager.shooting = false;
        }
        }
    //TODO: Doesn't start from gun 
    //https://answers.unity.com/questions/1464706/is-there-way-to-curve-raycast.html
    private List<Vector3> curvedRaycast (Vector3 start, Vector3 direction, int velocity, int numberOfIterations)
    {
        RaycastHit hit;
        List<Vector3> positions = new List<Vector3>();
        Ray ray = new Ray(start, direction);
        //shootLine.SetPosition(0, ray.origin);
        int count = 0;
        for (int i = 0; i < numberOfIterations; ++i)
        {
            //If it hits, return
            if (Physics.Raycast(ray, out hit, 1f))
            {
                Debug.Log(hit.collider.tag);
                //Mark where it is hitting -- FOr game
                if (hit.collider.tag == "WaterGameBullseye")
                {
                    if (firstHit == false)
                    {
                        firstHit = true;
                    }
                    WaterLevelManager.shooting = true;
                }
                else
                    WaterLevelManager.shooting = false;
                return positions;
            }
         
            //Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            ray = new Ray(ray.origin + ray.direction, ray.direction + (Physics.gravity / numberOfIterations / velocity));
            positions.Add(ray.origin);
        }
        Debug.Log(positions);
        return positions;

    }
}
