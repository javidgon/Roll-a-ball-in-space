using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelController : MonoBehaviour {

    public void NextLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level" + levelNumber);
        Time.timeScale = 1;
    }
}
