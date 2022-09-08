using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    [SerializeField] private Text _uiText;
    private string LevelTag = "Level";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(LevelTag))
        {
            PlayerPrefs.SetInt(LevelTag, 0);
        }
    }

    private void Update()
    {
        _uiText.text = PlayerPrefs.GetInt(LevelTag).ToString();
    }

    public void ProgressDelete() {
        PlayerPrefs.DeleteKey(LevelTag);
        PlayerPrefs.Save();
    }

    public void ProgressSave() {
        PlayerPrefs.SetInt(LevelTag, (PlayerPrefs.GetInt("Level") + 1));
        PlayerPrefs.Save();
    } 
}
