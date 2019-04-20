using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSecretCheatCodes : MonoBehaviour
{

    private KeyCode[] konami = new KeyCode[]
                              {
                                KeyCode.UpArrow,
                                KeyCode.UpArrow,
                                KeyCode.DownArrow,
                                KeyCode.DownArrow,
                                KeyCode.LeftArrow,
                                KeyCode.RightArrow,
                                KeyCode.LeftArrow,
                                KeyCode.RightArrow,
                                KeyCode.B,
                                KeyCode.A
                              };
    private PlayerMovement playerMovement;
    public float timeBetweenKeyPress = 1f;
    public float timeForCode = 5f;
    private int index = 0;

    private float timeSinceStartCode = 0f, timeSinceLastKey = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStartCode += Time.deltaTime;
        timeSinceLastKey += Time.deltaTime;
        if (timeSinceStartCode >= timeForCode || timeSinceLastKey >= timeBetweenKeyPress)
        {
            index = 0;
        }
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konami[index]))
            {
                if (index == 0)
                {
                    timeSinceStartCode = 0;
                }
                timeSinceLastKey = 0;
                index++;
                if (index >= konami.Length)
                {
                    print("KONAMI CODE ACTIVATED");
                    playerMovement.paused = false;
                    index = 0;
                }
            }
            else
            {
                index = 0;
            }
        }
    }
}
