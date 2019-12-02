using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    Text score;
   
    void Start() {
       score = GetComponent<Text>();
    }
    
   void Update() {
       score.text = "Final Score: " + ScoreScript.scorevalue;
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
