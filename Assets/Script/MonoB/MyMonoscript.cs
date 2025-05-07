using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;


public class MyMonoscript : MonoBehaviour
{

    public Player player;
    public string playername;
    private Enemy enemy;

    public ACTION action;
    public MOVIMENTO movimento;

    // public Player player2;
    private void CreoNemico()
    {
        Debug.Log(" Creo un nuovo nemico...");
        enemy = new Enemy();
        enemy.SetEnemy(player);
        Debug.Log(" Nuovo nemico: " + enemy.tipo + " con " + enemy.life + " HP");
    }
    private void FunzioneAttack()
    {
        //Debug.Log("Azione corrente: " + player.action);

        if (enemy.morto == false)
        {

            ACTION azione = player.action;


            switch (azione)
            {
                case (ACTION.ATTACCA):
                    int schivata = enemy.schivata + Random.Range(0, 10);
                    int precisione = player.GetPrecision() + Random.Range(1, 10);
                    if (schivata < precisione)
                    {
                        enemy.morto = enemy.Damaged(player);
                        if (!enemy.morto)
                        {
                            enemy.AttaccoNemico(player);
                        }

                    }
                    else
                    {
                        Debug.Log("Hai Lisciato il Nemico!");
                        enemy.AttaccoNemico(player);
                    }
                    action = ACTION.FERMO;   
                    
                    break;
                    

                case (ACTION.FUGGI):

                    if (player.agility >= enemy.agility)
                    {
                        Debug.Log("Sei Scappato");
                        enemy = null;
                    }
                    else
                    {
                        Debug.Log("non sei scappato");
                        enemy.AttaccoNemico(player);
                    }
                    action = ACTION.FERMO;
                    break;


                default:
                    action = ACTION.FERMO;
                    enemy.morto = enemy.DeathCheck();
                    break;

            }


        }
        else
        {

            Debug.Log("sono morto");
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
        player.Name = playername;
        enemy = new Enemy();
        enemy.SetEnemy(player);



    }

    // Update is called once per frame
    void Update()
    {

        if (player.CheckMorte())
        {
            Debug.Log("mi dispiace sei morto");
        }
        else
        {

            if (player.livello >= 10)
            {
                Debug.Log("Complimenti hai vinto!!!");
            }

            else

            {
                player.movimento = movimento; // Sincronizza con Inspector
                player.action = action;       // Idem per azione




                if (enemy == null || enemy.morto)
                {
                    if (enemy != null && enemy.morto)
                    {
                        // movimento = MOVIMENTO.STAI;
                        Debug.Log("complimenti hai guadagnato " + enemy.GetExpValue());
                        player.experience += enemy.GetExpValue();
                        player.IncrementaLivello();
                        Debug.Log("Hai Ucciso il nemico! Ora vai avanti!");
                        enemy = null;


                        if (player.action != ACTION.FERMO)
                        {
                            Debug.Log("Non c'è nient'altro da fare qua, spostati!");
                            action = ACTION.FERMO;
                        }



                        return;
                    }

                    if (player.movimento != MOVIMENTO.STAI)
                    {
                        CreoNemico();
                        movimento = MOVIMENTO.STAI;
                    }


                }


                if (enemy != null && !enemy.morto)
                {

                    //player.action = action;
                    if (player.movimento != MOVIMENTO.STAI)
                    {
                        Debug.Log("Non puoi muoverti finchè c'è un nemico");
                        movimento = MOVIMENTO.STAI;
                    }
                    FunzioneAttack();

                }
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