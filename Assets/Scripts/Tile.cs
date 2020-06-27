using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float[] xPosition; //Position of the tiles on the tileset
    public float[] yPosition;
    public GameObject no2; //Game object containing the sprite to be generated
    public List<Vector2> numberOfTimes; //List used to count the amount of times 2 is generated
    public float currentTime;
    
    void Start()
    {
        // Invoke("Spawner", Random.Range(0, 12));
        Spawner();
       // StartCoroutine(Spawn());
    }

    void Update()
    {
       //Spawner();
        //while(numberOfTimes.Count == 5)
        //{
        //    Spawner();
        //}
        //currentTime -= Time.deltaTime ;
        //if(currentTime <=0)//for (int i = 12; i <= currentTime; i--)
        //{
        //    Spawner();
        //}
    }

    //private IEnumerator Spawn()
    //{
    ////StopCoroutine(Spawn());
    //Spawner();
    //yield return new WaitForSeconds(3);
    //}
    void Spawner()
    { 
        int randRow = Random.Range(0, xPosition.Length); //Random generation for the row
        int randColumn = Random.Range(0, yPosition.Length); //Random generation for the column
        Instantiate(no2,  new Vector2(xPosition[randRow], yPosition[randColumn]), Quaternion.identity); //creating clones of no2 tile
        numberOfTimes.Add( new Vector2(xPosition[randRow], yPosition[randColumn]));
        Debug.Log(numberOfTimes);

        //Invoke("Spawner", Random.Range(0, 12));
    }

}
