using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{
    public string name;
    public float maxHealth;
    public float maxPower;
    public int enemyClass;
}

public enum EnemyType
{
    Troll,
    Orc,
    Centaur
}

public enum WeaponType
{
    Sword,
    Batton,
    Trident
}
