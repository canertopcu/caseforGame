using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Play, Stop, VacuumChanging }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState state = GameState.Play; 

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EventManager.Get<OnGameSuccessEvent>().AddListener(GameEnd);
    }

    private void OnDisable()
    {
        EventManager.Get<OnGameSuccessEvent>().RemoveListener(GameEnd);

    }

    public static void GameEnd()
    {
        state = GameState.Stop;
        Debug.LogError("GameEnded");
    }
}
