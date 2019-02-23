using UnityEngine;
using UnityEngine.UI;


public class SliderBehavior : MonoBehaviour
{
    public float currentDrawing = 100f;
    public float maxDrawing = 100f;
    // Start is called before the first frame update
    void Start()
    {
        drawingBar.value = drawingBarPercent();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            currentDrawing -= Time.deltaTime*60;
        }
        drawingBar.value = drawingBarPercent();
    }

    public Slider drawingBar;
    float drawingBarPercent()
    {
        return currentDrawing / maxDrawing;
    }
}
