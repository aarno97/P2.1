using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int colPoolSize = 10;
    public GameObject colPrefab;
    public float spawnRate = 4f;
    public float min = -2.2f;
    public float max = 3f;
    
    private Vector2 objectPoolPos = new Vector2 (-15, -25);  //start columns off screen
    private GameObject[] cols;
    private float timeSinceLastSpawned;
    private float spawnX = 25f;
    private int currentCol = 0;
    // Start is called before the first frame update
    void Start()
    {
        cols = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            cols[i] = (GameObject) Instantiate(colPrefab, objectPoolPos, Quaternion.identity);
        }

        //place first 3 cols
        /*
        float spawnY = Random.Range(-2f, 3f);
        cols[0].transform.position = new Vector2 (10f, spawnY);
        spawnY = Random.Range(-2f, 3f);
        cols[1].transform.position = new Vector2 (20f, spawnY);
        spawnY = Random.Range(-2f, 3f);
        cols[2].transform.position = new Vector2 (30f, spawnY);
        */
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate) { //check if game over here later?

            timeSinceLastSpawned = 0;
            float spawnY = Random.Range(-2f, 3f);
            //Debug.Log("min: " + min + " max: " + max + "\n");

            cols[currentCol].transform.position = new Vector2 (spawnX, spawnY);
            Debug.Log(spawnY + "\n");
            currentCol++;
            if (currentCol >= 10) {  //back to first column if at last column
                currentCol = 0;
            }
        }
    }
}
