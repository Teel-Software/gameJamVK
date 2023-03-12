using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLvL(SceneAsset Scene)
    {
       SceneManager.LoadScene(Scene.name);
    }
}
