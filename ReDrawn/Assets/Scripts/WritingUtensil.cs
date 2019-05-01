using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WritingUtensil
{
    public float maxAmount;
    public float currentAmount;
    public float lineDensity; // amount of pencil lead subtracted per unit distance of drawing
    public float lineThickness;
    public Color color;
    public Texture2D texture;
    public int index;
    static int count = 0;

    // other variables, potentially:

    // int maxUses; max number of times you can use it per level?
    // int remainingUses; remainin number of times you can use it per level?
    // bool hasRigidbody; whether it has mass?
    // visual material, somehow
    // physics material

    public WritingUtensil() {
        this.maxAmount = 0;
        this.currentAmount = 0;
        this.lineDensity = 0;
        this.lineThickness = 0;
        this.color = Color.white;
        this.texture = null; // defaults to whatever is set in LineTest prefab
        lock (Drawing2.writingUtensils)
        {
            this.index = count;
            Drawing2.writingUtensils.Add(this);
        }
        count++;
    }

    public void Use()
    {
        this.currentAmount = Mathf.Max(this.currentAmount - this.lineDensity, 0);
    }

    public void Reset()
    {
        this.currentAmount = maxAmount;
    }
}
