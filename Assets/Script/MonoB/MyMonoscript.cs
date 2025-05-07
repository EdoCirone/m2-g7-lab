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
        player.movimento = MOVIMENTO.STAI;
        room = new Rooms();
        room.player = player;

        player.movimento = movimento; // Sincronizza con Inspector
        player.action = action;       // Idem per azione
    }

    // Update is called once per frame
    void Update()
    {
         if (!player.vittoria() && !player.sconfitta())

        {

            
            //bool stanzaCreata = false;

            if (player.SièMosso())
            {
                room.CreoStanza();
                player.movimento = MOVIMENTO.STAI;
                //stanzaCreata = true;
            }

            player.EntrataInCombattimento();  

        }
        else
        {

            for (int i = 0; i < 10; i++)
            {
                Debug.Log("GameOver");
            }


        }


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