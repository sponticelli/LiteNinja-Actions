using System.Collections;
using LiteNinja.SOA.References;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LiteNinja.Actions
{
  [AddComponentMenu("LiteNinja/Actions/LoadScene")]
  public class LoadScene : MonoBehaviour
  {
    [SerializeField] private StringRef _sceneName;
    [SerializeField] private bool _isAdditive;
    [SerializeField] private bool _allowDuplicate;
    [SerializeField] private bool _unloadCurrentScene;
    [SerializeField] private bool _setAsActiveScene = true;
    [SerializeField] private float _delay = 0f;


    public void Load()
    {
      StartCoroutine(Execute());
    }
    


    private IEnumerator Execute()
    {
      yield return new WaitForSeconds(_delay);
      
      var currentScene = SceneManager.GetActiveScene();
      var alreadyLoaded = SceneManager.GetSceneByName(_sceneName).isLoaded;
      var loadSceneMode = _isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;
      
      if (_unloadCurrentScene)
      {
        if (!_allowDuplicate && currentScene.name == _sceneName)
        {
          alreadyLoaded = false;
        }
        SceneManager.UnloadSceneAsync(currentScene);
      }
      
      if (_allowDuplicate || !alreadyLoaded)
      {
        var asyncOperation = SceneManager.LoadSceneAsync(_sceneName, loadSceneMode);
        asyncOperation.allowSceneActivation = true;
        yield return asyncOperation;
      }
      if (_setAsActiveScene) SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));

    }
  }
}