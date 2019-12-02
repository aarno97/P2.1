using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
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
        SceneManager.LoadScene("Main"); 
    }
}
