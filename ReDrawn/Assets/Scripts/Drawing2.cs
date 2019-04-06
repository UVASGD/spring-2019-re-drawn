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
        // Delete this after MSE and stuff
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPencils();
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.Y)) // forward
        {
            currentWritingUtensil = Mathf.Min(currentWritingUtensil + 1, writingUtensils.Count - 1);
            SwitchToPencil(currentWritingUtensil);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.T)) // backwards
        {
            currentWritingUtensil = Mathf.Max(currentWritingUtensil - 1, 0);
            SwitchToPencil(currentWritingUtensil);
        }
        mouseVelocity = Input.mousePosition - lastPos;
        lastPos = Input.mousePosition;

        if (writingUtensils[currentWritingUtensil].currentAmount > 0)
        {
            // Have some amount of writing utensil to use
            if (Input.GetButtonDown("Fire1"))
            {
                currentDrawing = Instantiate(DrawingPrefab);
                currentDrawing.transform.position = Vector3.zero;
                currentDrawing.GetComponent<LineRenderer>().startWidth = writingUtensils[currentWritingUtensil].lineThickness;
                currentDrawing.GetComponent<LineRenderer>().endWidth = writingUtensils[currentWritingUtensil].lineThickness;
                if (writingUtensils[currentWritingUtensil].texture)
                {
                    currentDrawing.GetComponent<LineRenderer>().materials[0].mainTexture = writingUtensils[currentWritingUtensil].texture;
                }
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
                currentDrawing = null;
            }
        }
        // You're all out of writing utensil
        else if (currentDrawing != null)
        {
            // Can't hold onto current drawing anymore
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
            currentDrawing = null;
        }
    }

    public void UsePencil()
    {
        writingUtensils[currentWritingUtensil].Use();
        pencilBar.GetComponent<PencilBarController>().updateAppearance();
    }

    public void ResetPencils()
    {
        foreach(WritingUtensil utensil in writingUtensils){
            utensil.Reset();
        }
        pencilBar.GetComponent<PencilBarController>().updateAppearance();
    }
    
    private void InitializeWritingUtensils()
    {
        currentWritingUtensil = YellowPencil.GetInstance().index;
        pencilBar.GetComponent<PencilBarController>().updatePencilType();
        BluePencil.GetInstance();
    }

    private bool SwitchToPencil(int index)
    {
        // TODO: add a check to make sure you have access
        currentWritingUtensil = index;
        pencilBar.GetComponent<PencilBarController>().updatePencilType();
        return true;
    }
}
