using JetBrains.Annotations;
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
    private Traps trappola;
    private Mappa mappa;

    public AZIONICOMBATTIMENTO action;
    public AZIONIMOVIMENTO movimento;
    public AZIONIINVENTARIO azioniinventario;

    // public Player player2;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("BENVENUTI IN MyFirstAdventure!!!");
        Debug.Log("Un GDR testuale creato per fissare e applicare i concetti che gli autori stanno imparando nel corso di Epicode");
        Debug.Log("grazie al prezioso contributo dei docenti Jacopo Ziuliani e Luca Villanini. SI GIOCA TRAMITE INSPECTOR. UN GIOCO PIENO DI AVVENTURA,MISTERO E PARACULAGINE!!!");
        Debug.Log("sebbene il disordine degli script possa far sembrare che il gioco sia stato scritto da un chiwawa con tre zampe vi assicuriamo che siamo esseri umani");

        player = new Player();
        player.Name = playername;
        player.GetMovimento();
       
        trappola = new Traps();
        mappa = new Mappa();


    }

    // Update is called once per frame
    void Update()
    {


        player.movimentoesposto = movimento;
        player.action = action;

        player.GetMovimento();


        if (!player.vittoria() && !player.sconfitta())

        {


            player.GetMovimento();


            if (player.SièMosso())
            {
                room = new Rooms();
                room.player = player;

                room.CreoStanza();
                mappa.InseriscoStanzaInMappa(room);
                mappa.MostraMappa();

            }

            player.HoPresoLaPozione();
            player.AffrontoLaTrappola();
            player.Combattimento();

        }
        else
        {

            for (int i = 0; i < 10; i++)
            {
                Debug.Log("GameOver");
            }


        }

        azioniinventario = AZIONIINVENTARIO.NULLA;
        movimento = AZIONIMOVIMENTO.STAI;
        action = AZIONICOMBATTIMENTO.FERMO;
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