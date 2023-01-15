using UnityEngine;

namespace CodeBase.Enemies
{
    public class CurrentSceneManager : MonoBehaviour
    {
        private static CurrentSceneManager _instance;

        public int Level { get; private set; }

        public static CurrentSceneManager Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }

        public void IncreaseLevel()
        {
            Level++;
        }
    }
}