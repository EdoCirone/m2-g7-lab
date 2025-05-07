using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Rendering.Universal;
[SerializeField]

public class Player
{

    //FIELDS

    public string Name;
    private int experience;
    private int agility = 5;

    private int attack = 5;
    private bool morto;
    private int precisione = 1;
    private int livello;
    private int vita = 100;

    public ACTION action;
    private MOVIMENTO movimento;
    public MOVIMENTO movimentoesposto;
    MOVIMENTO movimentoprecedente = MOVIMENTO.STAI;

    public Enemy enemy;
    public Rooms rooms;



    //FUNZIONI

    public bool SièMosso()
    {
        //creo un confronto per capire se si è mosso, mettendo a confronto il dato stai con la variabile movimento

        if (movimento != movimentoprecedente && movimento != MOVIMENTO.STAI)
        {
            movimentoprecedente = movimento;
            return true;
        }
        else
        {
            movimentoprecedente = movimento;
            return false;
        }
    }
    public bool Combattimento()
    {
        if (enemy == null || enemy.morto)
        {
            if (enemy != null && enemy.morto)
            {
                AcquistoPuntiEsperienza();

                if (action != ACTION.FERMO)
                {
                    Debug.Log("Sei fuori dalla modalità combattimento!");
                    action = ACTION.FERMO;
                }

                enemy = null;


            }

            /*  if (movimento != MOVIMENTO.STAI)
              {

                  movimento = MOVIMENTO.STAI;

              }*/

            return false;
        }

        else
        {

            //player.action = action;
            if (movimento != MOVIMENTO.STAI)
            {
                Debug.Log("Non puoi muoverti finchè c'è un nemico");
                // movimento = MOVIMENTO.STAI;
            }

            FunzioneAttack();

            return true;

        }
    }
    public void FunzioneAttack()
    {

        if (enemy.morto == false)
        {

            ACTION azione = action;


            switch (azione)
            {
                case (ACTION.ATTACCA):
                    int schivata = enemy.schivata + Random.Range(0, 10);
                    int newprecisione = precisione + Random.Range(1, 10);
                    if (schivata < newprecisione)
                    {
                        enemy.morto = enemy.Damaged(this);
                        if (!enemy.morto)
                        {
                            enemy.AttaccoNemico(this);
                        }

                    }
                    else
                    {
                        Debug.Log("Hai Lisciato il Nemico!");
                        enemy.AttaccoNemico(this);
                    }
                    action = ACTION.FERMO;

                    break;


                case (ACTION.FUGGI):

                    if (agility >= enemy.agility)
                    {
                        Debug.Log("Sei Scappato");
                        enemy = null;
                    }
                    else
                    {
                        Debug.Log("non sei scappato");
                        enemy.AttaccoNemico(this);
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

    public void AcquistoPuntiEsperienza()
    {
        Debug.Log("complimenti hai guadagnato " + enemy.GetExpValue());
        experience += enemy.GetExpValue();
        IncrementaLivello();
        Debug.Log("Hai Ucciso il nemico! Ora vai avanti!");
        enemy = null;
    }

    public MOVIMENTO GetMovimento()
    {
        if (enemy != null && !enemy.morto)
        {
            movimento = MOVIMENTO.STAI;
            Debug.Log("il nemico non c'è o è morto");
        }
        else
        {
            movimento = movimentoesposto;
            Debug.Log("ecco il nemico");
        }

        return movimento;

    }

    public void ColpiscoIlNemico()
    {

        if (enemy.precisione < agility)
        {
            enemy.vita -= attack;

            Debug.Log("Il nemico ti ha colpito infliggendoti " + attack + "danni");
            Debug.Log("Ora la tua vita è: " + vita);
        }
        else
        {
        }

        Debug.Log("hai schivato il colpo!");

    }


    public bool CheckMorte()
    {
        if (vita == 0)
        { return true; }
        else if (vita < 0)
        {
            vita = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool vittoria()
    {

        if (livello >= 10)
        {
            Debug.Log("Complimenti hai vinto!!!");
            return true;
        }
        return false;
    }
    public bool sconfitta()
    {
        if (CheckMorte())
        {
            Debug.Log("mi dispiace sei morto");
            return true;
        }
        return false;
    }


    public int GetVita()
    {
        return vita;
    }

    public int GetAttack()
    {
        return attack;
    }

    public int GetAgility()
    {
        return agility;
    }

    public int GetExperience()
    {
        return experience;
    }

    public void IncrementaLivello()
    {
        if (experience > 100)
        {
            livello++;
            attack += 1;
            precisione += 1;
            agility += 1;
            experience = 0;
            Debug.Log("Complimenti" + Name + "sei salito di livello! ore sei livello " + livello);
        }

    }



}
/* ESERCIZIO 3 public class Player
{


    public string Name;
    private int Score;

    public int GetPunteggio(Player p)
    {
        return p.Score;
    }

    public void SetPunteggio(Player player, int score)
    {
        if (score < 0)
    {

        score = 0;

    }
        player.Score = score;
    }

    public static int Incrementapunteggio(Player p)
    {

        p.Score = p.Score + 10;
        return p.Score;
    }

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }
}



public class Player ESERCIZIO 2
{


    public string Name;
    public int Score;
    
    public static int Incrementapunteggio(Player p)
    {

        p.Score = p.Score + 10;
        return p.Score;
    }

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }



}

/*public class Player ESERCIZIO 01
{


    public string Name;
    public int Score;

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }



}*/
