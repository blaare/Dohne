using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public int sceneNumber;

    public void Load()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
