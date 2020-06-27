using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float[] xPosition; //Position of the tiles on the tileset
    public float[] yPosition;
    public GameObject no2; //Game object containing the sprite to be generated
    public GameObject tile; //Original tile
    public List<Vector2> numberOfTimes; //List used to count the amount of times 2 is generated
    public float currentTime;
   

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        currentTime += Time.deltaTime; //Counts the amount of second spent in the game
        if (currentTime >= 5.0f)
        {
            CancelInvoke("Spawner");// stops the spawning
        }

        if (currentTime >= 5.1f)
        {
            CancelInvoke("CoverUp");
        }
    }
   

    private IEnumerator Spawn()
    {
        
        InvokeRepeating("Spawner", 0.04f, 1); //Spawns the number
        InvokeRepeating("CoverUp", 1.0f, 1); //Covers the number
        yield return null;
    }
    void Spawner()
    { 
        int randRow = Random.Range(0, xPosition.Length); //Random generation for the row
        int randColumn = Random.Range(0, yPosition.Length); //Random generation for the column
        Instantiate(no2,  new Vector2(xPosition[randRow], yPosition[randColumn]), Quaternion.identity); //creating clones of no2 tile
        numberOfTimes.Add( new Vector2(xPosition[randRow], yPosition[randColumn]));
        //Debug.Log(numberOfTimes);
    }

    void CoverUp()
    {
        //if (numberOfTimes.Count == 1) 
        //{
        //    Vector2 place = numberOfTimes[0];
        //    Instantiate(tile, place, Quaternion.identity);
        //}
        //else 
        //{
            for (int i = 0; i < numberOfTimes.Count; i++)
            {
                Vector2 places = numberOfTimes[i];
                Instantiate(tile, places, Quaternion.identity);
            }
       // }



    }

}
