using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Destroy(MenuMusicManager.MenuMusic);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
#if UNITYEDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    // Unity's LoadSceneAsync does NOT work and its a KNOWN bug. Try to avoid using this method for now.
    private IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //slider.value = progress;
            yield return null;
        }
    }
}
