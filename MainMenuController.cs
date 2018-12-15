    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    private LineRenderer teleportLine;
    public GameObject controller;
    public GameObject player;
    private RaycastHit hit;
    private Vector3 positionToTeleport;
    private float range = 300;
    // Use this for initialization
    void Start () {
        teleportLine = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GvrControllerInput.AppButton)
        {
            teleportLine.enabled = true;
            List<Vector3> positions = curvedRaycast(controller.transform.position, controller.transform.forward, 2, 60);
            teleportLine.positionCount = positions.Count + 1;
            teleportLine.SetPosition(0, controller.transform.position);

            for (int i = 0; i < positions.Count; ++i)
            {
                if (positions[i] != null)
                    teleportLine.SetPosition(i + 1, positions[i]);
            }

        }
        if (GvrControllerInput.AppButtonUp)
        {
            Vector3 currPos = player.transform.position;
            Vector3 teleportPos = positionToTeleport;
            teleportPos.y = currPos.y;
            teleportLine.enabled = false;
            player.transform.position = teleportPos;
        }
    }
    private List<Vector3> curvedRaycast(Vector3 start, Vector3 direction, int velocity, int numberOfIterations)
    {
        RaycastHit hit;
        List<Vector3> positions = new List<Vector3>();
        Ray ray = new Ray(start, direction);
        for (int i = 0; i < numberOfIterations; ++i)
        {
            //If it hits, return
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.tag != "Untagged")
                    positionToTeleport = hit.collider.transform.position;
                Debug.Log(hit.collider.tag);
                return positions;
            }
            ray = new Ray(ray.origin + ray.direction, ray.direction + (Physics.gravity / numberOfIterations / velocity));
            positions.Add(ray.origin);
        }
        return positions;

    }
}
