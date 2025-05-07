
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy
{
    public TIPODINEMICO tipo;

    public int life;

    private int expvalue;

    private int precisione;

    public int schivata;

    private int attack;

    public int agility;

    public bool morto;

    Player player;

    public void SetEnemy(Player player)
    {
       
        tipo = TypeEnemy(out life, out precisione, out attack, out agility, out schivata, out expvalue);
    }


    public bool Damaged(Player player)
    {

            life -= player.GetAttack();
            Debug.Log("Ho subito " + player.GetAttack() + " ora la mia vita è " + life);

        return DeathCheck();
    }

    private TIPODINEMICO TypeEnemy(out int life, out int precisione, out int attack, out int agility, out int schivata, out int expvalue)
    {
        life = 0;
        precisione = 0;
        attack = 0;
        agility = 0;
        schivata = 0;
        expvalue = 0;

        TIPODINEMICO tipo = (TIPODINEMICO)Random.Range(0, 0);

        switch (tipo)
        {
            case TIPODINEMICO.DEBOLE:
                life = 5;
                precisione = 3;
                attack = 1;
                agility = 1;
                schivata = 1;
                expvalue = 30;
                break;

            case TIPODINEMICO.MEDIO:
                life = 10;
                precisione = 6;
                attack = 2;
                agility = 2;
                schivata = 2;
                expvalue = 60;
                break;

            case TIPODINEMICO.FORTE:
                life = 15;
                precisione = 9;
                attack = 3;
                agility = 3;
                schivata = 3;
                expvalue = 100;
                break;

        }

        Debug.Log(tipo + " la mia vita è " + life + " la mia precisione è " + precisione + " il mio attacco è " + attack);
        return tipo;
    }

    public void AttaccoNemico(Player player)
    {
        Debug.Log("il nemico si prepara ad attaccare");
        
        if (precisione < player.agility)
        {
            player.vita -= attack;

            Debug.Log("Il nemico ti ha colpito infliggendoti " + attack + "danni");
            Debug.Log("Ora la tua vita è: " + player.vita);
        }
        else
        {
            Debug.Log("hai schivato il colpo!");
        }
    }

    public bool DeathCheck()
    {
        if (life > 0)
        {
            morto = false;
        }
        else if (life < 0)
        {
            life = 0;
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
