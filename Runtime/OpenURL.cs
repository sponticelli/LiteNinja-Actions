using LiteNinja.SOA.References;
using UnityEngine;

namespace LiteNinja.Actions
{
  [AddComponentMenu("LiteNinja/Actions/OpenURL")]
  public class OpenURL : MonoBehaviour
  {
    [SerializeField] private StringRef _url;
        
    public void Open()
    {
      Application.OpenURL(_url.Value);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
      if (string.IsNullOrEmpty(_url.Value))
      {
        Debug.LogError("URL is empty");
      }
    }        
#endif
  }
}