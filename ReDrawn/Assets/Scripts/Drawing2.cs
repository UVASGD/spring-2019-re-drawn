using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing2 : MonoBehaviour
{
    public float nextPlaceTime = 0;
    public float secondsBetweenPlacement = 1;
    public GameObject DrawingPrefab;
    public GameObject currentDrawing;
    private Vector3 lastPos;
    public Vector3 mouseVelocity = new Vector3(0, 0, 0);
    public float lineThickness = .25f;

    public List<Vector2> polygonPointsStart = new List<Vector2>();
    public List<Vector2> polygonPointsEnd = new List<Vector2>();

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

        if (Input.GetButtonDown("Fire1"))
        {
            currentDrawing = Instantiate(DrawingPrefab);
            Vector3 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDrawing.transform.position = new Vector3(tempPos.x, tempPos.y);
        }

        else if (Input.GetButton("Fire1") && mouseVelocity.sqrMagnitude > 0)
        {
            if (nextPlaceTime < Time.time)
            {
                Vector3 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                tempPos = new Vector3(tempPos.x, tempPos.y);
                LineRenderer temp = currentDrawing.GetComponent<LineRenderer>();
                temp.positionCount += 1;
                temp.SetPosition(temp.positionCount - 1, tempPos);
                nextPlaceTime = Time.time + secondsBetweenPlacement;

                Vector3 offset = Vector3.Cross(mouseVelocity, Vector3.forward).normalized;
                polygonPointsStart.Add(tempPos + offset * lineThickness * .5f);
                polygonPointsEnd.Add(tempPos + offset * lineThickness * -.5f);
            }
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            print("asdfadfasf");
            PolygonCollider2D temp = currentDrawing.GetComponent<PolygonCollider2D>();
            Vector2[] colliderPoints = new Vector2[polygonPointsStart.Count * 2];
            for (int x = 0; x < colliderPoints.Length / 2; x++)
            {
                colliderPoints[x] = polygonPointsStart[x];
                colliderPoints[colliderPoints.Length - x] = polygonPointsEnd[x];
            }

            temp.points = colliderPoints;
        }
    }
}
