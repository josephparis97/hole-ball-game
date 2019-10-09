using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private int playerlevel;

    public Player()
    {
        playerlevel = 0;
    }

    public void setPlayerlevel(int level)
    {
        this.playerlevel = level;
    }
    public int getPlayerLevel()
    {
        return this.playerlevel;
    }
}
