using UnityEngine;

[CreateAssetMenu(fileName = "Platforms", menuName = "CreatePlatformList", order = 52)]
public class PlatformContainer : ScriptableObject
{
    [SerializeField] public GameObject[] platforms;
}
