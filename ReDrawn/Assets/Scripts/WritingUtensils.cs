using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingUtensils : MonoBehaviour
{
    public WritingUtensil yellowPencil = new WritingUtensil();
    public WritingUtensil bluePencil = new WritingUtensil(); // this is just for testing

    void Awake()
    {
        // basic pencil
        yellowPencil.maxAmount = 10.0f;
        yellowPencil.currentAmount = yellowPencil.maxAmount;
        yellowPencil.lineDensity = 0.05f;
        yellowPencil.lineThickness = 0.25f;
        yellowPencil.color = new Color32(255, 210, 0, 255);

        // testing pencil
        bluePencil.maxAmount = 12.0f;
        bluePencil.currentAmount = yellowPencil.maxAmount;
        bluePencil.lineDensity = 0.2f;
        bluePencil.lineThickness = 0.25f;
        bluePencil.color = new Color32(0, 169, 255, 255);

        FindObjectOfType<Drawing2>().currentWritingUtensil = yellowPencil;
        FindObjectOfType<PencilBarController>().updatePencilType();
    }
}


