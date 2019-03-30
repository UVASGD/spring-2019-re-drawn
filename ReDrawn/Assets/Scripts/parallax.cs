using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    Transform cameraPosition;
    Vector3 lastCameraPosition;
    public float parallaxScale = .5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = GameObject.Find("Main Camera").transform;
        lastCameraPosition = cameraPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-(lastCameraPosition - cameraPosition.position) * parallaxScale);
        lastCameraPosition = cameraPosition.position;
    }
}
