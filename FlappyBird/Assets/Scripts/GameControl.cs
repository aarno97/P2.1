using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float scrollSpeed = 0f;
    // Start is called before the first frame update
    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
