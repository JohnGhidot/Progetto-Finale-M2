using System;
[Serializable]

public struct Stats //contiene le variabili pubbliche
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;


    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva) //costruttore che assegna i valori
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }

    public static Stats Sum(Stats a, Stats b)  //funzione statica Sum, prende in input due Stats e restituisce uno Stats che abbia in ciascuna sua variabile la somma delle variabili dei due oggetti di partenza
    {
        return new Stats(
            a.atk + b.atk,
            a.def + b.def,
            a.res + b.res,
            a.spd + b.spd,
            a.crt + b.crt,
            a.aim + b.aim,
            a.eva + b.eva
            );
    }
}

