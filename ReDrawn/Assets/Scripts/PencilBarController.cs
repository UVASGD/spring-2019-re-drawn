using UnityEngine;
using UnityEngine.UI;

public class PencilBarController : MonoBehaviour
{
    public Slider pencilSlider;
    private WritingUtensil currentPencil;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void updateAppearance() {
        pencilSlider.value = currentPencil.currentAmount;
    }

    public void updatePencilType() {
        currentPencil = FindObjectOfType<Drawing2>().currentWritingUtensil;
        initializeBar();
        pencilSlider.fillRect.GetComponent<Image>().color = currentPencil.color;
        pencilSlider.handleRect.GetComponent<Image>().color = currentPencil.color;
    }

    public void initializeBar() {
        pencilSlider.maxValue = currentPencil.maxAmount;
        pencilSlider.value = currentPencil.currentAmount;
    }
}
