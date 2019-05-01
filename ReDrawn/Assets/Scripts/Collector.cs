using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public int numTotal, numCollect;
    public Text countText;
    private GameObject box;
    private bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        numTotal = GameObject.FindGameObjectsWithTag("Collectable").Length;
        numCollect = numTotal;
        countText = GameObject.Find("CollectableCounter").GetComponent<Text>();
        setCountText();
        box = GameObject.FindGameObjectWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        if (!collected && numCollect <= 0)
        {
            box.GetComponent<Animator>().SetBool("allCollected", true);
            collected = true;
        }
    }
    public void setCountText()
    {
        countText.text = "Collected: " + (numTotal-numCollect).ToString() + "/" +numTotal.ToString();
    }
}
