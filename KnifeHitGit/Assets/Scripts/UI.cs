using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private GameObject _restart;
    [SerializeField] private GameObject _win;
    [SerializeField] private KnifeSpawner _knifeSpawner;
    [SerializeField] private GameObject _ui;
    [SerializeField] private Saver _saver;
    [SerializeField] private SceneManagerMine _sceneManagerMine;

    [SerializeField] private GameObject[] _images;

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
        _sceneManagerMine.LoadGame();
        
    }
    
    //private void GetWinOld() {
    //    _win.SetActive(true);
    //    StopScene();
    //    _saver.ProgressSave();
    //}

    private void StopScene() =>
        Time.timeScale = 0;
    
    private void UpdateHp() {
        for (int i = 0; i < _target.MaxValue; i++)
        {
            if (i < _target.Hp)
                _images[i].gameObject.SetActive(true);
            else _images[i].gameObject.SetActive(false);
        }

    }
}