using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffZone : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        player.transform.position = initialPosition;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject[] drawings = GameObject.FindGameObjectsWithTag("Drawing");
        foreach(GameObject drawing in drawings)
        {
            GameObject.Destroy(drawing);
        }
        player.GetComponent<Drawing2>().ResetPencils();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Reset();
        }
    }
}
