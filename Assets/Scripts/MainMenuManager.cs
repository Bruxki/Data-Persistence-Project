using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    
    private string highScoreName;
    private int highScore;

    public void SetName(string name)
    {
        MenuManager.Instance.currentName = name;
        Debug.Log(name);
    }

    private void Start()
    {
        MenuManager.Instance.LoadNameScore();
        highScoreName = MenuManager.Instance.Name;
        highScore = MenuManager.Instance.HighScore;



        highScoreText.text = "High Score: " + highScoreName + ": " + highScore;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
