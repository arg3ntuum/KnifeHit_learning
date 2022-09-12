using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private KnifeSpawner _knifeSpawner;
    [SerializeField] private AudioSource _audioStacked;
    [SerializeField] private AudioSource _audioBackground;
    private void Start()
    {
        _knifeSpawner.KnifeAdd += GetSound;
        StartCoroutine(StartPlayBackGround());
    }

    private void GetSound() {
        _audioStacked.Play();
    }
    IEnumerator StartPlayBackGround()
    {
        do { 
        yield return new WaitForSeconds(1);
        _audioBackground.Play();
        } while (true);
    }

}
