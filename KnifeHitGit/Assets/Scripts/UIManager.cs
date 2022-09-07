using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private GameObject _restart;
    [SerializeField] private GameObject _win;
    [SerializeField] private KnifeSpawner _knifeSpawner;
    [SerializeField] private GameObject _ui;

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
        
    }

    private void GetWin() {
        _win.SetActive(true);
        StopScene();
    }

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