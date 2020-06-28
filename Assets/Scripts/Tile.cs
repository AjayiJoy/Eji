using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{

    public float[] xPosition; //Position of the tiles on the tileset
    public float[] yPosition;
    public GameObject no2; //Game object containing the sprite to be generated
    public GameObject tile; //Original tile
    public List<Vector2> numberOfTimes; //List used to count the amount of times 2 is generated
    public float currentTime; //Counts the seconds of gameplay
    public GameObject youWonPanel;
    public GameObject youLosePanel; 
    public GameObject gamePanel; //Question field
    public GameObject timePanel;
    public Text countdown;
    public float timeLast = 5.1f;
    public int tl;
   

    void Start()
    {
        StartCoroutine(Spawn());
        countdown.text = " "+ tl; 
    }

    void Update()
    {
        timeLast -= Time.deltaTime;
        tl = (int)timeLast;
        countdown.text = " " + tl; //Display sountdown on the screen
        currentTime += Time.deltaTime; //Counts the amount of second spent in the game
        if (currentTime >= 5.0f)
        {
            CancelInvoke("Spawner");// stops the spawning
        }

        if (currentTime >= 5.1f)
        {
            CancelInvoke("CoverUp");
            gamePanel.SetActive(true);
            timePanel.SetActive(false); 
        }
    }
   

    private IEnumerator Spawn()
    {
        
        InvokeRepeating("Spawner", 0.04f, Random.Range(0.08f, 1)); //Spawns the number
        InvokeRepeating("CoverUp", 1.0f, Random.Range(0.08f, 1)); //Covers the number
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
        
       for (int i = 0; i < numberOfTimes.Count; i++)
       {
           Vector2 place = numberOfTimes[i];
           Instantiate(tile, place, Quaternion.identity);
       }
    }

   public void SubmitNumber()
   {
        string number = GameObject.Find("InputField").GetComponent<InputField>().text;
        int num = int.Parse(number);

        if(num == numberOfTimes.Count)
        {
            YouWon();
        }
        else
        {
            YouLose();
        }
    }

    void YouWon()
    {
        gamePanel.SetActive(false);
        youWonPanel.SetActive(true);
    }

    void YouLose()
    {
        SceneManager.LoadScene("MenuScene");
       // youLosePanel.SetActive(true);
        //gamePanel.SetActive(false);
        //isNumberEqual = false;
    }
}
