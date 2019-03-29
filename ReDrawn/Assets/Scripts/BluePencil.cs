using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePencil : WritingUtensil
{
    private static BluePencil instance = new BluePencil();

    public static BluePencil getInstance() {
        return instance;
    }

    public BluePencil() {
        this.maxAmount = 12.0f;
        this.currentAmount = this.maxAmount;
        this.lineDensity = 0.2f;
        this.lineThickness = 0.25f;
        this.color = new Color32(0, 169, 255, 255);
    }
}
