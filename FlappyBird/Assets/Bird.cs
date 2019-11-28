using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Movement speed
    public float speed = 2; 
    
    // Flap force
    public float force = 300; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right*speed; 
    }

    // Update is called once per frame
    void Update()
    {
        // Flap
        if (Input.GetKeyDown(KeyCode.Space)) 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force); 
    }
    
    void OnCollisionEnter2D(Collision2D coll) {
        //Restart
        Application.LoadLevel("Home Screen"); 
    }
}
