using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Название уровня")]
    public string levelName;

    [Header("Названия животных")] 
    public string[] animalName = new string[3];

    [Header("Длительность анимаций")]
    public float[] durationsAnimations = new float[3];
}
