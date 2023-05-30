using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenuAttribute(fileName = "Troll", menuName = "ScriptableObjects/Troll", order = 0)]
public class TrollData : EnemyData
{
    public EnemyType enemyRace;
    public WeaponType weaponType;
}
