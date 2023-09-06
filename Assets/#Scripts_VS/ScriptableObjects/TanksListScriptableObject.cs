using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TanksList", menuName = "ScriptableObjects/TanksList")]
public class TanksListScriptableObject : ScriptableObject
{
    public TankScriptableObject[] tankScriptableObjectsList;
}
