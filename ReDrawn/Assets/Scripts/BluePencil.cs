using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePencil : WritingUtensil
{
    private static BluePencil instance = null;

    public static BluePencil GetInstance()
    {
        if (instance == null)
        {
            instance = new BluePencil();
        }
        return instance;
    }

    public BluePencil()
    {
        this.maxAmount = 12.0f;
        this.currentAmount = this.maxAmount;
        this.lineDensity = 0.2f;
        this.lineThickness = 0.25f;
        this.color = new Color32(0, 169, 255, 255);
        this.texture = Resources.Load<Texture2D>("Blue Pencil Sprite");
    }
}
