using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   void Update() {
       FinalScoreScript.scoreValue = ScoreScript.scoreValue;
        if (Input.GetKeyDown(KeyCode.Space)) {
            Play(); 
        }
     }
    void OnMouseDown() {
        Play(); 
    }
    void Play() {
        SceneManager.LoadScene("Home Screen"); 
    }
}
