using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRefrenceHolder : GenericSingleton<WorldRefrenceHolder>
{
    public List<EnemyTankView> allEnemyTanks;
    public Transform EnvironmentParent;
}
