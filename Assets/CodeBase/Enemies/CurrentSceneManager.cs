using System;
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

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void IncreaseLevel()
        {
            Level++;
        }
    }
}