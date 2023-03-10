using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void LoadLvL(int scene)
    {
       SceneManager.LoadScene(scene);
    }

    public void OpenPanel (GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    public void SaveData( int flagZanovo)
    {
        PlayerPrefs.SetInt("destroy", flagZanovo);
    }
}
