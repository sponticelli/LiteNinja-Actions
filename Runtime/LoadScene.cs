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
    [SerializeField] private bool _unloadCurrentScene;
    [SerializeField] private float _delay = 0f;
    
    
    public void Load()
    {
      if (_delay == 0)
      {
        Execute();
      }
      else
      {
        StartCoroutine(DelayedExecute());
      }
      
    }
    
    private IEnumerator DelayedExecute()
    {
      yield return new WaitForSeconds(_delay);
      Execute();
    }

    private void Execute()
    {
      if (_unloadCurrentScene) SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
      SceneManager.LoadScene(_sceneName.Value, _isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }
  }
}