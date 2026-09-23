using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.StickyNote;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer1 = Color.white;
    public Color colorPlayer2 = Color.white;

    public string namePlayer1;
    public string namePlayer2;

    private static SaveController _instance;
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindAnyObjectByType<SaveController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer1 : namePlayer2;
    }

    public void Reset()
    {
        namePlayer1 = "";
        namePlayer2 = "";
        colorPlayer1 = Color.white;
        colorPlayer2 = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}