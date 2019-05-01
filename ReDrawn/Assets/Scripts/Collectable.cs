using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public static int numTotal;
    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            if (this.tag == "Collectable")
            {
                other.GetComponent<Collector>().numCollect-=1;
                other.GetComponent<Collector>().setCountText();
                Destroy(gameObject);
            }
            else if (this.tag == "Box" && other.GetComponent<Collector>().numCollect <= 0)
            {
                print("You have all the things and have touched this box!");
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
    /*void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }*/
}
