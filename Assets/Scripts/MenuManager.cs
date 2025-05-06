using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string Name;
    public int HighScore;

    //singleton stuff
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    //methods for updating the name and the score
    public void NewNameCreated (string name)
    {
        MenuManager.Instance.Name = name;
    }

    public void UpdateHighScore(int highScore)
    {
        MenuManager.Instance.HighScore = highScore;
    }


    //save data class (put everything together)
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }
    //method for putting the data into json file

    public void SaveNameScore()
    {
        SaveData data = new SaveData();
        data.name = Name;
        data.highScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //extracting the data back into the ol' mighty singleton
    public void LoadNameScore()
    {
        string path = Application.persistentDataPath + "savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.name;
            HighScore = data.highScore;

        }
    }





    //scene management part (should've been a separate script)
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
