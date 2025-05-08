using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class Rooms
{
    private TIPODISTANZA tipo;
    public Player player;
    //public Enemy enemy;

    public void CreoStanza()
    {
        AssegnoTipoStanza();
    }

    private void AssegnoTipoStanza()
    {
        tipo =  (TIPODISTANZA)  Random.Range(0,4);

        switch (tipo)
        {
            case TIPODISTANZA.STANZANEMICO:

                Enemy enemy = CreoNemico();
                player.enemy = enemy;

                TIPODINEMICO tiponemico = enemy.tipo;

                Debug.Log("Hai trovato un " + tiponemico);
                player.Combattimento();
                player.GetMovimento();
                break;

            case TIPODISTANZA.STANZATRAPPOLA:

                Debug.Log("hai trovato una trappola");
                int vita = player.GetVita() ;
                vita--;
                player.GetMovimento();

                break;


            case TIPODISTANZA.STANZAVUOTA:

                Debug.Log("hai trovato una stanza vuota");
                player.GetMovimento();

                break;


            case TIPODISTANZA.STANZATESORO:

                Debug.Log("hai trovato un tesoro");
                player.GetMovimento();

                break;

            default:
                break;
        }
    }

    private Enemy CreoNemico()
    {

        Enemy enemy = new Enemy();

        Debug.Log(" Creo un nuovo nemico...");

        enemy.SetEnemy();

        Debug.Log(" Nuovo nemico: " + enemy.tipo + " con " + enemy.vita + " HP");

        return enemy;
    }
}