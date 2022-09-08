using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class UI : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private KnifeSpawner _knifeSpawner;

    [SerializeField] private GameObject _restart;
    [SerializeField] private GameObject _win;

    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject[] _images;

    [SerializeField] private SceneManagerMine _sceneManagerMine;

    [SerializeField] private Saver _saver;

    [SerializeField] private GameObject _particleSystem;

    private void Start()
    {
        _target.Broken += GetWin;
        _knifeSpawner.Win += GetDied;
    }
    private void Update()
    {
        UpdateHp();
    }
    private void GetDied() {
        _restart.SetActive(true);
        StopScene();
        _saver.ProgressDelete();
    }


    private void GetWin()
    {
        _saver.ProgressSave();
        _particleSystem.SetActive(true);
        StartCoroutine(Waiter());
        

    }

    //private void GetWinOld() {
    //    _win.SetActive(true);
    //    StopScene();
    //    _saver.ProgressSave();
    //}

    private void OffAllSprites() {
        foreach (var item in _knifeSpawner.SpriteRenderers)
        {
            item.enabled = false;
        }
    }

    private void StopScene() =>
        Time.timeScale = 0;

    private void UpdateHp() {
        for (int i = 0; i < _target.MaxValue; i++) {
            if (i < _target.Hp)
                _images[i].gameObject.SetActive(true);
            else _images[i].gameObject.SetActive(false);
        }
    }
    IEnumerator Waiter()
    {
        _target.GetComponent<SpriteRenderer>().enabled = false;
        OffAllSprites();
        yield return new WaitForSeconds(1);
        _target.GetComponent<SpriteRenderer>().enabled = true;
        _particleSystem.SetActive(false);
        _sceneManagerMine.LoadGame();
    }
}