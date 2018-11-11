using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour {

	public void LoadScene(int _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
