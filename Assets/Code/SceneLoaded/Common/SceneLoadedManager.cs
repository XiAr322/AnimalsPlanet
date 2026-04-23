using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace Code.SceneLoaded
{
    public class SceneLoadedManager
    {
        private const string MAIN_SCENE = "MainMenu";
        private const string LEVEL_SCENE = "Simulation";

        public async UniTask LoadLevel()
        {
            await SwitchScene(MAIN_SCENE, LEVEL_SCENE);
        }

        private async UniTask LoadScene(string sceneName)
        {
            var loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            if (loadOperation != null)
            {
                loadOperation.allowSceneActivation = true;
                while (!loadOperation.isDone)
                {
                    var progress = Mathf.Clamp01(loadOperation.progress / 0.9f) * 100f;
                    Debug.Log($"Loading scene {sceneName}: {progress:F0}%");
                    await UniTask.NextFrame();
                }
                Debug.Log($"Loading scene {sceneName}: 100%");
            }
        }

        private async UniTask UnloadScene(string sceneName)
        {
            var unloadOperation = SceneManager.UnloadSceneAsync(sceneName);
            if (unloadOperation != null)
            {
                while (!unloadOperation.isDone)
                {
                    var progress = Mathf.Clamp01(unloadOperation.progress) * 100f;
                    Debug.Log($"Unloading scene {sceneName}: {progress:F0}%");
                    await UniTask.NextFrame();
                }
                Debug.Log($"Unloading scene {sceneName}: 100%");
            }

            await Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }

        private async UniTask SwitchScene(string currentSceneName, string newSceneName)
        {
            await UnloadScene(currentSceneName);

            await LoadScene(newSceneName);
        }

        private void HandleSceneError(string operation, string sceneName, System.Exception e)
        {
            Debug.LogError($"Error during {operation} of scene {sceneName}: {e.Message}");
        }

        public async UniTask SafeSwitchScene(string currentSceneName, string newSceneName)
        {
            try
            {
                await SwitchScene(currentSceneName, newSceneName);
            }
            catch (System.Exception e)
            {
                HandleSceneError("switching", newSceneName, e);
                throw;
            }
        }
    }
}