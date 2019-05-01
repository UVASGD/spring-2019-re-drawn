using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public int numTotal, numCollect;
    public string nextLevel;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        numTotal = GameObject.FindGameObjectsWithTag("Collectable").Length;
        numCollect = numTotal;
        countText = GameObject.Find("CollectableCounter").GetComponent<Text>();
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (numTotal <= 0)
        {
            LoadLevel(nextLevel);
        }
    }
    public void setCountText()
    {
        countText.text = "Collected: " + (numTotal-numCollect).ToString() + "/" +numTotal.ToString();
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
