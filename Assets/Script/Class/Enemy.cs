
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy
{
    public TIPODINEMICO tipo;

    public int vita;

    private int expvalue;

    public int precisione;

    public int schivata;

    private int attack;

    public int agility;

    public bool morto;

    public Player player;
    public Rooms rooms;

    public void SetEnemy()
    {
       
        tipo = TypeEnemy();
    }


    public bool Damaged(Player player)
    {

            vita -= player.GetAttack();
            Debug.Log("Ho subito " + player.GetAttack() + " ora la mia vita è " + vita);

        return DeathCheck();
    }

    private TIPODINEMICO TypeEnemy()
    {
      
        TIPODINEMICO tipo = (TIPODINEMICO)Random.Range(0, 0);

        switch (tipo)
        {
            case TIPODINEMICO.DEBOLE:
                vita = 5;
                precisione = 3;
                attack = 1;
                agility = 1;
                schivata = 1;
                expvalue = 30;
                break;

            case TIPODINEMICO.MEDIO:
                vita = 10;
                precisione = 6;
                attack = 2;
                agility = 2;
                schivata = 2;
                expvalue = 60;
                break;

            case TIPODINEMICO.FORTE:
                vita = 15;
                precisione = 9;
                attack = 3;
                agility = 3;
                schivata = 3;
                expvalue = 100;
                break;

        }

        Debug.Log(tipo + " la mia vita è " + vita + " la mia precisione è " + precisione + " il mio attacco è " + attack);
        return tipo;
    }

    public void AttaccoNemico(Player player)
    {
        Debug.Log("il nemico si prepara ad attaccare");
    }


    public bool DeathCheck()
    {
        if (vita > 0)
        {
            morto = false;
        }
        else if (vita < 0)
        {
            vita = 0;
            morto = true;
        }
        else
        {
            Debug.Log("sono morto");
            morto = true;
        }
        return morto;
    }


    public int GetExpValue()
    {
        return expvalue;
    }

}
