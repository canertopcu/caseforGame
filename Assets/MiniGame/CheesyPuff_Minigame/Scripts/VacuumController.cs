using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour
{
    public Transform outOfScene;
    public Vector3 lastPosition;
    public int ActiveVacuumIndex = 0;
    public Vacuum[] vacuumList;
    private Vacuum activeVacuum;
    public float vaccumSpeed;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float zMin;
    [SerializeField] private float zMax;

    private void Awake()
    {
        vacuumList = GetComponentsInChildren<Vacuum>(true);

        ActivateVacuum(0);
    }

    private void PassOtherVacuum()
    {
        ActiveVacuumIndex++;
        if (vacuumList.Length > ActiveVacuumIndex)
        {
            activeVacuum.gameObject.SetActive(false);
            lastPosition = transform.position;
            transform.position = outOfScene.position;
            ActivateVacuum(ActiveVacuumIndex);
            transform.DOMove(lastPosition, 1f);
            GameManager.state = GameState.Play;
        }
        else
        {
            EventManager.Get<OnGameSuccessEvent>().Execute();
        }

    }


    void ActivateVacuum(int index)
    {
        ActiveVacuumIndex = index;
        activeVacuum = vacuumList[index];
        for (int i = 0; i < vacuumList.Length; i++)
        {
            vacuumList[i].SetActive(false);
        }
        activeVacuum.SetActive(true);
    }

    private void Update()
    {
        if (activeVacuum.IsMissionCompleted() && GameManager.state == GameState.Play)
        {
            GameManager.state = GameState.VacuumChanging;
            PassOtherVacuum();
        }
        else if (GameManager.state == GameState.Play)
        {
            activeVacuum.Interact(); 
        }
    }



    private void OnEnable()
    {
        InputManager.OnJoystickMove += InputManager_OnJoystickMove;
    }
    private void OnDisable()
    {
        InputManager.OnJoystickMove -= InputManager_OnJoystickMove;
    }


    private void InputManager_OnJoystickMove(Vector2 obj)
    {
        if (GameManager.state == GameState.Play)
        {
            Vector3 pos = transform.position;
            pos += (Vector3.forward * obj.x * Time.deltaTime * vaccumSpeed + Vector3.left * obj.y * Time.deltaTime * vaccumSpeed);

            pos.x = Mathf.Clamp(pos.x, xMin, xMax);
            pos.z = Mathf.Clamp(pos.z, zMin, zMax);

            transform.position = pos;

        }
    }

}
