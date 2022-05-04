using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : BaseState
{
    //the detectives distance from the enemy
    public static int distFromEnemy = 10;

    //the range to needed to fight the enemy
    public static int enemyRange = 2;

    //the no. of enemies to be eliminated
    public static int enemyCount = 10;

    //to check if combat has started
    public static bool combatStart = false;

    //check if the enemies are currently attacking
    public static bool enemyAttacking;

    //to check if the detective has been healed
    public static bool healed = false;
}