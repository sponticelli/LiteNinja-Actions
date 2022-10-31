using System.Collections.Generic;
using LiteNinja.SOA.Events;
using UnityEngine;

namespace LiteNinja.Actions
{
  [AddComponentMenu("LiteNinja/Actions/PlaySound")]
  public class PlaySound : MonoBehaviour
  {
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioClipEvent _audioClipEvent;
        
    [SerializeField] private bool _waitForPreviousSound;
    
    private readonly Queue<int> _clipIndexQueue = new();
    private float _delay = 0f;
    
    public void Play()
    {
      if (_audioClips.Length == 0)
      {
        return;
      }

      _clipIndexQueue.Enqueue(Random.Range(0, _audioClips.Length));
    }
    
    private void Update()
    {
      if (_clipIndexQueue.Count == 0)
      {
        _delay = 0f;
        return;
      }
      
      if (_delay > 0f)
      {
        _delay -= Time.deltaTime;
        return;
      }
      
      var clipIndex = _clipIndexQueue.Dequeue();
      _audioClipEvent.Raise(_audioClips[clipIndex]);
      _delay = _waitForPreviousSound ? _audioClips[clipIndex].length : 0f;
    }

  }
}