using UnityEngine;
using UnityEngine.UI;

public class PencilBarController : MonoBehaviour
{
    public Slider pencilSlider;
    Drawing2 drawingObject;

    // Start is called before the first frame update
    void Start()
    {
        drawingObject = FindObjectOfType<Drawing2>();
    }

    public void updateAppearance() {
        pencilSlider.value = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].currentAmount;
    }

    public void updatePencilType() {
        initializeBar();
        pencilSlider.fillRect.GetComponent<Image>().color = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].color;
        pencilSlider.handleRect.GetComponent<Image>().color = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].color;
    }

    public void initializeBar() {
        pencilSlider.maxValue = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].maxAmount;
        pencilSlider.value = Drawing2.writingUtensils[drawingObject.currentWritingUtensil].currentAmount;
    }
}
