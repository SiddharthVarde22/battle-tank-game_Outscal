using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentParentScript : MonoBehaviour
{
    void Start()
    {
        WorldRefrenceHolder.Instance.EnvironmentParent = transform;
    }
}
