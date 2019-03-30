using UnityEngine;
using UnityEngine.UI;

public class PencilBarController : MonoBehaviour
{
    public Slider pencilSlider;
    public Drawing2 drawingObject;

    public void updateAppearance()
    {
        pencilSlider.value = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].currentAmount;
    }

    public void updatePencilType()
    {
        initializeBar();
        pencilSlider.fillRect.GetComponent<Image>().color = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].color;
        pencilSlider.handleRect.GetComponent<Image>().color = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].color;
    }

    void initializeBar()
    {
        pencilSlider.maxValue = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].maxAmount;
        pencilSlider.value = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].currentAmount;
    }
}
