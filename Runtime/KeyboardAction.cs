using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.Actions
{
  [AddComponentMenu("LiteNinja/Actions/Keyboard Action")]
  public class KeyboardAction : MonoBehaviour
  {
    [SerializeField] private KeyCode _key;
    [SerializeField] private UnityEvent _onKeyDown;
    [SerializeField] private UnityEvent _onKeyUp;
        
    private void Update()
    {
      if (Input.GetKeyDown(_key))
      {
        _onKeyDown?.Invoke();
      }
      else if (Input.GetKeyUp(_key))
      {
        _onKeyUp?.Invoke();
      }
    }
  }
}