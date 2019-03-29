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
    private Vector3 mouseVelocity = new Vector3(0, 0, 0);
    private GameObject pencilBar;
    public static List<WritingUtensil> writingUtensils = new List<WritingUtensil>();
    public int currentWritingUtensil;


    private List<Vector2> polygonPointsStart = new List<Vector2>();
    private List<Vector2> polygonPointsEnd = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        pencilBar = GameObject.Find("PencilBar");
        InitializeWritingUtensils();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            SwitchToPencil(BluePencil.getInstance().index);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SwitchToPencil(YellowPencil.getInstance().index);
        }
        //print("Current Writing Utensil " + writingUtensils[currentWritingUtensil].color);
        mouseVelocity = Input.mousePosition - lastPos;
        lastPos = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            currentDrawing = Instantiate(DrawingPrefab);
            currentDrawing.transform.position = Vector3.zero;
            currentDrawing.GetComponent<LineRenderer>().startWidth = writingUtensils[currentWritingUtensil].lineThickness;
            currentDrawing.GetComponent<LineRenderer>().endWidth = writingUtensils[currentWritingUtensil].lineThickness;
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
                print(currentWritingUtensil + ", " + writingUtensils.Count);
                polygonPointsStart.Add(tempPos + offset * writingUtensils[currentWritingUtensil].lineThickness * .5f);
                polygonPointsEnd.Add(tempPos + offset * writingUtensils[currentWritingUtensil].lineThickness * -.5f);
                UsePencil();
            }
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            PolygonCollider2D temp = currentDrawing.GetComponent<PolygonCollider2D>();
            Vector2[] colliderPoints = new Vector2[polygonPointsStart.Count * 2];
            for (int x = 0; x < colliderPoints.Length / 2; x++)
            {
                colliderPoints[x] = polygonPointsStart[x];
                colliderPoints[colliderPoints.Length - x - 1] = polygonPointsEnd[x];
            }
            temp.points = colliderPoints;
            Rigidbody2D rb = currentDrawing.GetComponent<Rigidbody2D>();
            rb.simulated = true;
            polygonPointsStart.Clear();
            polygonPointsEnd.Clear();
        }
    }

    public bool UsePencil() {
        bool ret = writingUtensils[currentWritingUtensil].Use();
        pencilBar.GetComponent<PencilBarController>().updateAppearance();
        return ret;
    }

    private void InitializeWritingUtensils() {
        currentWritingUtensil = YellowPencil.getInstance().index;
        pencilBar.GetComponent<PencilBarController>().updatePencilType();
    }

    private bool SwitchToPencil(int index) {
        // TODO: add a check to make sure you have access
        currentWritingUtensil = index;
        print(index + " " + writingUtensils.Count);
        pencilBar.GetComponent<PencilBarController>().updatePencilType();
        return true;
    }
}
