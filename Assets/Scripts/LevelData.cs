using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public int leverCount = 4;
    public float enemySpeed = 5f;
    public float levelTimeLimit = 90f;
}

