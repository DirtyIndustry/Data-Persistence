using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private InputField nameInput;

    [SerializeField] private string userName;
    [SerializeField] private string bestUserName;
    [SerializeField] private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        Storage.Instance.LoadRecord();
        userName = Storage.Instance.userName;
        bestUserName = Storage.Instance.bestUserName;
        bestScore = Storage.Instance.bestScore;
        UpdateNameInput();
        ShowBestScore();
    }

    void UpdateNameInput()
    {
        nameInput.text = userName;
    }

    void ShowBestScore()
    {
        bestScoreText.text = "Best Score: " + bestUserName + " " + bestScore;
    }

    public void ChangeUserName()
    {
        userName = nameInput.text;
        Storage.Instance.ChangeUserName(userName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
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
