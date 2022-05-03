using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : BaseState
{
    public int enemies = 5;
    public bool combatStart = false;
    public bool attacking;
}