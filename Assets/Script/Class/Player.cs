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

    private DEBUF debufplayer;

    public AZIONICOMBATTIMENTO action;
    public AZIONIINVENTARIO azioneinventario;
    private AZIONIMOVIMENTO movimento;
    
    public AZIONIMOVIMENTO movimentoesposto = AZIONIMOVIMENTO.STAI;
    AZIONIMOVIMENTO movimentoprecedente =  AZIONIMOVIMENTO.STAI;

    AZIONIINVENTARIO azioneinventarioprecedente = AZIONIINVENTARIO.NULLA;

    public Enemy enemy;
    public Rooms rooms;
    public Traps traps;
    //public Tesoro tesoro;
    public Inventario inventario;



    //FUNZIONI

    public bool SièMosso()
    {
        //creo un confronto per capire se si è mosso, mettendo a confronto il dato stai con la variabile movimento

        if (movimento != movimentoprecedente && movimento != AZIONIMOVIMENTO.STAI)
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
    public AZIONIMOVIMENTO BloccaMovimento()
    {
   
            if (enemy != null && !enemy.morto)
            {
                movimento = AZIONIMOVIMENTO.STAI;

            }
            else
            {
                movimento = movimentoesposto;

            }


            return movimento;
            
    }


    //public void PrendoPozione()
    //{


    //    if (azioneinventario == AZIONIINVENTARIO.PRENDOPOZIONECURA)
    //    {
    //        if (inventario.TrovaPozioniCura().Count != 0 )
    //        {

    //            vita += vita;
    //            Debug.Log("Hai preso una pozione ora la tua vita è " + vita);
               
    //        }
            
    //        else
    //        {

    //            Debug.Log("Non hai pozioni di cura");

    //        }
              
    //        Inventario.HoLaPozione();
    //    }


    //}



    public bool AffrontoLaTrappola()
    {
        if (traps != null) 
        {

            if (agility < traps.Getpunteggiotrappola())
            {
                //Debug.Log("oh no,Non hai schivato la trappola");
                DannoTrappola();
                traps = null;
            }
            else
            {
                Debug.Log("Complimenti!!! Hai schivato la trappola!");
                traps = null;
            }


            return true;

        }

 
        //Debug.Log("Nessuna trappola da affrontare.");
         return false;
    }
    public void DannoTrappola()
    {
        vita = vita - traps.Getdannotrappola();
        Debug.Log("Non hai schivato la trappola!!! hai subito " + traps.Getdannotrappola() + " danni, la tua vita ora è " + vita);
    }



    public bool Combattimento()
    {
        if (enemy == null || enemy.morto)
        {
            if (enemy != null && enemy.morto)
            {
                AcquistoPuntiEsperienza();
                enemy = null;

                if (action != AZIONICOMBATTIMENTO.FERMO)
                {
                    Debug.Log("Sei fuori dalla modalità combattimento!");
                    action = AZIONICOMBATTIMENTO.FERMO;
                    enemy = null;
                }



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
            if (movimento != AZIONIMOVIMENTO.STAI)
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

            AZIONICOMBATTIMENTO azione = action;


            switch (azione)
            {
                case (AZIONICOMBATTIMENTO.ATTACCA):
                    int schivata = enemy.schivata + Random.Range(0, 10);
                    int newprecisione = precisione + Random.Range(1, 10);
                    if (schivata < newprecisione)
                    {
                        enemy.morto = enemy.Damaged(this);
                        if (!enemy.morto)
                        {
                            AttaccoNemico();
                        }

                    }
                    else
                    {
                        Debug.Log("Hai Lisciato il Nemico!");
                        AttaccoNemico();
                    }
                    action = AZIONICOMBATTIMENTO.FERMO;

                    break;


                case (AZIONICOMBATTIMENTO.FUGGI):

                    if (agility >= enemy.agility)
                    {
                        Debug.Log("Sei Scappato");
                        enemy = null;
                    }
                    else
                    {
                        Debug.Log("non sei scappato");
                        AttaccoNemico();
                    }
                    action = AZIONICOMBATTIMENTO.FERMO;
                    break;


                default:
                    action = AZIONICOMBATTIMENTO.FERMO;
                    enemy.morto = enemy.DeathCheck();
                    break;

            }


        }
        else
        {

            Debug.Log("sono morto");
            action = AZIONICOMBATTIMENTO.FERMO;
            return;
        }
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
    public void AttaccoNemico()
    {
        vita -= enemy.GetAttack();
        Debug.Log("Il nemico ti ha preso infliggendoti " + enemy.GetAttack() + "ora la tua vita è " + vita);
    }



    public void AcquistoPuntiEsperienza()
    {
        Debug.Log("complimenti hai guadagnato " + enemy.GetExpValue());
        experience += enemy.GetExpValue();
        IncrementaLivello();
        Debug.Log("Hai Ucciso il nemico! Ora vai avanti!");
        enemy = null;
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
