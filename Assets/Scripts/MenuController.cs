#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public GameObject Error;
    public InputField input;

    public void StartGame()
    {
        if (input.text.Length >= 3)
        {
            SceneManager.LoadScene(1);
            InstanceManager.Instance._name = input.text;
        }
        else
        {
            Error.gameObject.SetActive(true);
        }
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else

        Application.Quit();
#endif
    }

   
}
