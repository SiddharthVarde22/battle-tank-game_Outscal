
using UnityEngine;

public class EnvironmentParentScript : MonoBehaviour
{
    private void Start()
    {
        WorldRefrenceHolder.Instance.EnvironmentParent = transform;
    }
}
