using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
   void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Play(); 
        }
     }
    void OnMouseDown() {
        Play(); 
    }
    void Play() {
        Application.LoadLevel("Home Screen"); 
    }
}
