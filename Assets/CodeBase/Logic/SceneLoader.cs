using System.Collections;
using CodeBase.Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class SceneLoader : MonoBehaviour
    {
        private Curtain _curtain;

        public static SceneLoader Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            _curtain = FindObjectOfType<Curtain>();
        }

        public void Load(string sceneName) =>
            StartCoroutine(LoadScene(sceneName));

        private IEnumerator LoadScene(string sceneName)
        {
            CurrentSceneManager.Instance.IncreaseLevel();

            AsyncOperation waitToLoad = SceneManager.LoadSceneAsync(sceneName);

            while (waitToLoad.isDone != true)
            {
                yield return null;
            }

            _curtain.FadeIn();
        }
    }
}