using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MyMonoscript : MonoBehaviour
{
    
    public Player player;
    // public Player player2;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null && player2 == null)
        {
            player = new Player();
            player.Name = "antonio";

            Player.Stampapunteggio(player);
            Player.Incrementapunteggio(player);
            Player.Stampapunteggio(player);
        }
        else
        {
            Debug.Log("Serve un personaggio");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


/*    void Start() ESERCIZIO 02
    {
        if (player == null)
        {
            player = new Player();
            player.Name = "antonio";
            player.Score = 33;

            Player.Stampapunteggio(player);
            Player.Incrementapunteggio(player);
            Player.Stampapunteggio(player);
        }
        else
        {
            Debug.Log("Serve un personaggio");
        }
    }
  
 
 void Start() ESERCIZIO 01
    {
        if (player == null && player2 == null)
        {
            player = new Player();
            player.Name = "antonio";
            player.Score = 22;

            player2 = new Player();
            player2.Name = "giorgio";
            player2.Score = 32;

            Player.Stampapunteggio(player);
            Player.Stampapunteggio(player2);
        }
        else
        {
            Debug.Log("Serve un personaggio");
        }
    } */