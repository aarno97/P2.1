using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    // Movement Speed (0 means don't move)
    public float speed_v = 0;
    public float speed_h = 0;
    
    // Switch Movement Direction every x seconds
    public float switchTime = 2;
    private Rigidbody2D pipe;

    void Start() {
        pipe = GetComponent<Rigidbody2D> ();
        
        // Initial Movement Direction
        pipe.velocity = Vector2.up * speed_v;
        pipe.velocity = Vector2.left * speed_h;
        
        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }
    
    void Switch() {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
}