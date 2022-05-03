using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : BaseState
{
    public static int distFromEnemy = 10;
    public static int enemyRange = 2;
    public static int enemyCount = 10;
    public static bool combatStart = false;
    public static bool enemyAttacking;
    public static bool healed = false;
}