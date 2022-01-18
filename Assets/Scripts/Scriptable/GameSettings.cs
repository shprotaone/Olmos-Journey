using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "CreateGameSettings", order = 52)]
public class GameSettings : ScriptableObject
{
    public bool sfx;
    public bool music;
    public bool drunkedCam;

}
