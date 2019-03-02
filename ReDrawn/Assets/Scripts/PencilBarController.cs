using UnityEngine;
using UnityEngine.UI;

public class PencilBarController : MonoBehaviour
{
    public Slider pencilSlider;
    float maxValue = 10.0f;
    float currentValue;
    float amount = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue;
        pencilSlider.maxValue = maxValue;
        pencilSlider.value = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool usePencil() {
        if (currentValue - amount >= 0)
        {
            print("hello!");
            currentValue -= amount;
            updateAppearance();
            return true;
        }
        else {
            return false;
        }
    }

    void updateAppearance() {
        pencilSlider.value = currentValue;
    }
}
