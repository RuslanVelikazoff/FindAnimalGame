using UnityEngine;

namespace Data
{
    public class StartData : MonoBehaviour
    {
        public bool _fullGame;

        private const string saveKey = "mainSave";

        public void Initialize()
        {
            Load();

            Debug.Log("Data initialized");
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                Save();
            }
        }

        private void OnDisable()
        {
            Save();
        }

        private void Load()
        {
            var data = SaveManager.Load<GameData>(saveKey);

            _fullGame = data.fullGame;
        }

        private void Save()
        {
            SaveManager.Save(saveKey, GetSaveSnapshot());
            PlayerPrefs.Save();
        }

        public GameData GetSaveSnapshot()
        {
            var data = new GameData()
            {
                fullGame = _fullGame
            };

            return data;
        }
    }
}
