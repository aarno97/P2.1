using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class Bird : MonoBehaviour
{
    //microphone variables
    AudioClip microphoneInput;
    bool micInitialized;
    public float sens;
    public bool can_flap = true;
    public DateTime lastFlapped;

    // Movement speed
    // Flap force
    public float force = 500;
    public static int x;

    //bird var
    private Rigidbody2D bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D> ();

        //init mic
        if (Microphone.devices.Length>0){
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            micInitialized = true;
        }

        lastFlapped = DateTime.Now;
        ScoreScript.scoreValue = 0;
 
        x = 0;
 
        //Fly towards the right
        //bird.velocity = Vector2.right*speed;
    }
 
    // Update is called once per frame
    void Update()
    {
        //get input volume
        int d = 128;
        float[] waveData = new float[d];
        int micPos = Microphone.GetPosition(null)-(d+1);
        microphoneInput.GetData(waveData, micPos);

        //get audio peak
        float max = 0;
        for (int i = 0; i < d; i++) {
            float peak = waveData[i] * waveData[i];
            if (max < peak) {
                max = peak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(max));

        DateTime t = DateTime.Now;
        TimeSpan elapsed = t.Subtract(lastFlapped);

        if (elapsed.TotalSeconds >= 0.25) {
            can_flap = true;
        }


        // Flap
        if ((Input.GetKeyDown(KeyCode.Space) || (level > 0.7)) && can_flap) {
            bird.velocity = new Vector2(0,0);
            bird.AddForce(Vector2.up * force);

            lastFlapped = DateTime.Now;
            can_flap = false;
        }


        // figure out how it passes through the pipes
        if (x == 600)
        {
            ScoreScript.scoreValue += 1;
            x = 375;
        }
 
        else
        {
            x++;
        }
    }
   
    void OnCollisionEnter2D(Collision2D coll) {
        //Restart
        SceneManager.LoadScene("GameOver");
    }
}