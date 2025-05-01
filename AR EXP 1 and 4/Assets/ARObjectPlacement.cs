using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARObjectPlacement : MonoBehaviour
{
    public GameObject objectToPlace; // The object to place on the detected plane
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>(); // Find AR Raycast Manager
    }

    void Update()
    {
        if (Input.touchCount > 0) // If the user touches the screen
        {
            touchPosition = Input.GetTouch(0).position; // Get touch position
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            // Raycast against detected planes
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose; // Get the hit pose (where the ray hits)
                objectToPlace.transform.position = hitPose.position; // Place the object at the hit location
            }
        }
    }
}
