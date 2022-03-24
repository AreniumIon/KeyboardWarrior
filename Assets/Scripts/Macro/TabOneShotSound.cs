using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabOneShotSound : MonoBehaviour
{
    private AudioSource _audioSource = null;

    [Header("Object Pooling")]
    TabSoundPool _tabSoundPool = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    public void AssignTabSoundPool(TabSoundPool tabSoundPool)
    {
        _tabSoundPool = tabSoundPool;
    }

    public void OnEnable()
    {
        _audioSource.Play();
        StartCoroutine(WaitToRemoveSelf());
    }

    private IEnumerator WaitToRemoveSelf()
    {
        //yield return new WaitForSeconds(_audioSource.clip.length);
        yield return new WaitForSeconds(0.5f);
        RemoveSelf();
    }

    private void RemoveSelf()
    {
        if (_tabSoundPool != null)
        {
            //return to Pool, instead of Destroy
            _tabSoundPool.ReturnToPool(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
