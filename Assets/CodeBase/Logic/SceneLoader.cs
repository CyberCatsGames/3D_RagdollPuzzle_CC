using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Logic
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;

        public void Load(string sceneName) =>
            StartCoroutine(LoadScene(sceneName));

        private IEnumerator LoadScene(string sceneName)
        {
            AsyncOperation waitToLoad = SceneManager.LoadSceneAsync(sceneName);

            while (waitToLoad.isDone != true)
            {
                yield return null;
            }

            _curtain.FadeIn();
        }
    }
}