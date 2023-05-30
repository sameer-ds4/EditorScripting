using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Centaur", menuName = "ScriptableObjects/Centaur", order = 2)]
public class CentaurData : EnemyData
{
    public EnemyType enemyRace = EnemyType.Centaur;
    public WeaponType weaponType;
}
