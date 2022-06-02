using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Vector3 startPos;
    private static float cameraZ;
    private float dragSpeed = 0.3f;

    private void Start()
    {
        cameraZ = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch mostRecentTouch = Input.GetTouch(Input.touchCount-1);


            if (mostRecentTouch.phase == TouchPhase.Began)
            {
                startPos = Camera.main.ScreenToWorldPoint(mostRecentTouch.position);
            }
            else if (mostRecentTouch.phase == TouchPhase.Moved)
            {
                Vector3 touchWorldSpacePos = Camera.main.ScreenToWorldPoint(mostRecentTouch.position);

                Vector3 offset = touchWorldSpacePos - startPos;

                transform.position += new Vector3(-offset.x * dragSpeed, 0, 0);
            }
        }
    }
}
