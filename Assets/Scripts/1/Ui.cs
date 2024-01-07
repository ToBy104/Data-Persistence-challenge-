#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ui : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text name_Text;

    private MainManager1 mainManager;

    private void Start()
    {
        mainManager = MainManager1.Instance;
        name_Text.text = "name : " + mainManager._name + "\n" + "Score : " + mainManager._score;
    }

    private void Update()
    {
        if(inputField.text != "")
        {
            mainManager._name = inputField.text;
            mainManager._score = 0;
        }

    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        mainManager.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
