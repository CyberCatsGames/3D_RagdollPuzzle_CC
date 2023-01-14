using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class SceneLoader : MonoBehaviour
    {
        private Curtain _curtain;

        public SceneLoader Instance => this;

        private void Awake()
        {
            _curtain = FindObjectOfType<Curtain>();
        }

        public void Load(string sceneName) =>
        StartCoroutine(LoadScene(sceneName));

        private IEnumerator LoadScene(string sceneName) {
            AsyncOperation waitToLoad = SceneManager.LoadSceneAsync(sceneName);

            while (waitToLoad.isDone != true) {
                yield return null;
            }

             _curtain.FadeIn();
        }
    }
}