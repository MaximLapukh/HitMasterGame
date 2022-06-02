using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] UIBaseWidget _coverScreen;
    public void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {

    }
    public void LoadScene(int index)
    {
        _coverScreen.HadShowed += () => { SceneManager.LoadScene(index); };
        _coverScreen.Show();
    }
}
