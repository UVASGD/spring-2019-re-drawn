using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private static int count;
    public Text countText;
    public static int numTotal;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText = GameObject.Find("CountText").GetComponent<Text>();
        setCountText();
        numTotal = GameObject.FindGameObjectsWithTag("Collectable").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Count: " + count);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (this.tag == "Collectable")
            {
                Destroy(gameObject);
                count++;
                setCountText();
                print("Count: " + count); //just testing some stuff
            }
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
