using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void LoadNewScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
