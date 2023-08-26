using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private CameraScaller cameraScaller;

    private void Start()
    {
        cameraScaller.Initialize();
    }
}
