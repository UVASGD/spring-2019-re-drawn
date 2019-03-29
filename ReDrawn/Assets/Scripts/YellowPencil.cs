using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPencil : WritingUtensil
{
    private static YellowPencil instance = new YellowPencil();

    public static YellowPencil getInstance() {
        return instance;
    }

    public YellowPencil() {
        this.maxAmount = 10.0f;
        this.currentAmount = this.maxAmount;
        this.lineDensity = 0.05f;
        this.lineThickness = 0.25f;
        this.color = new Color32(255, 210, 0, 255);
    }
}
