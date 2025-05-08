using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;


public class MyMonoscript : MonoBehaviour
{

    public Player player;
    public string playername;
    private Rooms room;
   

    public ACTION action;
    public MOVIMENTO movimento;

    // public Player player2;

    
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        player.Name = playername;
        player.GetMovimento();
        room = new Rooms();
        room.player = player;

 
    }

    // Update is called once per frame
    void Update()
    {
     
    

 

        player.movimentoesposto = movimento;
        player.action = action;


        player.GetMovimento();


        if (!player.vittoria() && !player.sconfitta())

        {


            //bool stanzaCreata = false;
            player.GetMovimento();


            if (player.SièMosso())
            {
                room.CreoStanza();
                //stanzaCreata = true;
            }

            player.Combattimento();  

        }
        else
        {

            for (int i = 0; i < 10; i++)
            {
                Debug.Log("GameOver");
            }


        }

        movimento = MOVIMENTO.STAI;
        action = ACTION.FERMO;
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