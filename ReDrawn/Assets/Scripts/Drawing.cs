using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public float nextPlaceTime = 0;
    public float secondsBetweenPlacement = 1;
    public GameObject lineSegmentPrefab;
    private Vector3 lastPos;
    public Vector3 mouseVelocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseVelocity = Input.mousePosition - lastPos;
        lastPos = Input.mousePosition;
        print(mouseVelocity);

        if (Input.GetButton("Fire1") && mouseVelocity.sqrMagnitude > 0)
        {
            if (nextPlaceTime < Time.time)
            {
                GameObject temp = Instantiate(lineSegmentPrefab);
                Vector3 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                temp.transform.position = new Vector3(tempPos.x, tempPos.y);
                float angle = Mathf.Atan2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * Mathf.Rad2Deg;
                temp.transform.Rotate(0, 0, angle);
                nextPlaceTime = Time.time + secondsBetweenPlacement;
            }
        }
    }
}
