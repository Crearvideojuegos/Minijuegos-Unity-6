using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Points;
    public bool GameActive;

    public GameObject Player;
    public GameObject Movables;
    
    public static GameManager Instance; //Singleton


    private void Awake()
    {
        Instance = this; //Singleton

        Points = 0;
        GameActive = false;
    }

    public void ResetPositions()
    {
        GameActive = false;
        Player.transform.position = new Vector3(0, 60, 0);
        Movables.transform.position = new Vector3(0, 0, 0);
    }
}
