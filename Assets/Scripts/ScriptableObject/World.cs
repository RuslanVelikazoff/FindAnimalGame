using UnityEngine;

[CreateAssetMenu (fileName = "World", menuName = "World")]
public class World : ScriptableObject
{
    [Header("Уровни")]
    public Level[] levels;
}
