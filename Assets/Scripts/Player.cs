using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // initializing variables 
    public float speed = 2f;
    public GameObject NpcText;
    public GameObject ParentsText;
    public GameObject SpeechBubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// player movement //// 
        // initilize position variable 
        Vector3 newPos = transform.position;

        // WASD controller 
        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;
        }

        // setting the new position 
        transform.position = newPos;
    }

    // Colliding with Items that I can kind of pass through
    void OnTriggerEnter2D(Collider2D other)
    {
        // collects the pizza when collided with it 
        if (other.gameObject.name == "Pizza")
        {
            Destroy(other.gameObject);
        }

        // talk to the NPC rat & parents 
        if (other.gameObject.name == "NPC")
        {
            SpeechBubble.SetActive(true);
            NpcText.SetActive(true);
        } 
        else if (other.gameObject.name == "Parents")
        {
            // if you don't have the wand and walk over the chicken, the chicken talks to you 
            SpeechBubble.SetActive(true);
            ParentsText.SetActive(true);
        }
    }

    // when leaving the NPC or Parents, the text disappears 
    void OnTriggerExit2D(Collider2D other)
    {
        // stop talking to the NPC rat & parents 
        if (other.gameObject.name == "NPC")
        {
            SpeechBubble.SetActive(false);
            NpcText.SetActive(false);
        }
        else if (other.gameObject.name == "Parents")
        {
            // if you don't have the wand and walk over the chicken, the chicken talks to you 
            SpeechBubble.SetActive(false);
            ParentsText.SetActive(false);
        }
    }
}
