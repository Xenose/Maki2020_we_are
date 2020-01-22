using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioOut;

    [SerializeField] 
    public bool _random = false;
    [SerializeField] 
    public bool _mutte = false;
    [SerializeField] 
    private uint _trakNr = 0;
    [SerializeField] 
    private AudioClip[] _playList;

    void Start()
    {
        _audioOut = gameObject.AddComponent<AudioSource>();
    }

    void LateUpdate()
    {
        if (!_audioOut.isPlaying && !_mutte)
        {
            if (_playList.Length <= _trakNr)
                _trakNr = 0;

            _audioOut.clip = _playList[_trakNr++];
            _audioOut.Play(1);
        }
        else if (_mutte && _audioOut.isPlaying)
        {
            _audioOut.Stop();
        }
    }
}
