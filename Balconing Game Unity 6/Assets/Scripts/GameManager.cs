using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameActive;

    public GameObject Player;
    public GameObject Movables;
    
    public static GameManager Instance; //Singleton

    public GameObject btnQuit;
    public GameObject textInfo;
    public TMP_Text textResult;


    private void Awake()
    {
        Instance = this; //Singleton
        GameActive = false;
    }

    private void Start() 
    {
        textResult.text = "";
    }

    public void ResetPositions()
    {
        GameActive = false;
        Player.transform.position = new Vector3(0, 60, 0);
        Movables.transform.position = new Vector3(0, 0, 0);
    }

    public void HideShowUI()
    {

        if(GameActive) {
            Cursor.lockState = CursorLockMode.Locked;
            btnQuit.SetActive(false);
            textInfo.SetActive(false);
        } else {
            Cursor.lockState = CursorLockMode.None; 
            btnQuit.SetActive(true);
            textInfo.SetActive(true);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
