using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Названия животных")] 
    public string[] animalName = new string[3];
}
