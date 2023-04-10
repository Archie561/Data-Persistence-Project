using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private InputField _nameField;

    private void Awake()
    {
        if (DataManager.instance.userName != null)
            _nameField.text = DataManager.instance.userName;
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
