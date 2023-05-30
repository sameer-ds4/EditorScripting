using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Orc", menuName = "ScriptableObjects/Orc", order = 1)]
public class OrcData : EnemyData
{
    public EnemyType enemyRace = EnemyType.Orc;
    public WeaponType weaponType;
}
