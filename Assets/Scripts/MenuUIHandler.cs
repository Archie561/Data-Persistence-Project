using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private InputField _nameField;
    [SerializeField]
    private Text bestScoreText;

    private void Start()
    {
        DataManager.instance.onScoreBeated.AddListener(ShowBestScore);
        ShowBestScore();
    }

    private void Awake()
    {
        if (DataManager.instance.userName != null)
            _nameField.text = DataManager.instance.userName;
    }

    private void ShowBestScore()
    {
        DataManager.instance.LoadData();
        bestScoreText.text = $"Best score: {DataManager.instance.bestUserName}: {DataManager.instance.bestPoints}";
    }

    public void StartGame()
    {
        if (_nameField.text != string.Empty)
        {
            DataManager.instance.userName = _nameField.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            _nameField.placeholder.color = Color.red;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Exit()
#endif
    }
}
