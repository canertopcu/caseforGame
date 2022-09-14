
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _selectedMovementHandler;

    private IRaycastProvider _rayProvider;
    private ISelector _selector;
    private ISelectResponse _selectorResponse;
    private IMoveResponse _moveResponse;

    private void Awake()
    {

        _rayProvider = GetComponent<IRaycastProvider>();
        _selector = GetComponent<ISelector>();
        _selectorResponse = GetComponent<ISelectResponse>();
        _moveResponse = GetComponent<IMoveResponse>();

    }

    private void OnEnable()
    {
        InputManager.OnPointerMove += InputManager_OnPointerMove;
        InputManager.OnClickStart += InputManager_OnClickStart;
        InputManager.OnClickEnd += InputManager_OnClickEnd;
    }

    private void InputManager_OnClickEnd(Vector3 obj)
    {
        _selectedMovementHandler = null;
    }

    private void InputManager_OnClickStart(Vector3 pointerPos)
    {
        _selector.Check(_rayProvider.CreateRay(pointerPos));
        _selectedMovementHandler = _selector.GetSelection();
        if (_selectedMovementHandler != null)
        {
            _selectorResponse.OnSelect(_selectedMovementHandler);
        }
    }

    private void OnDisable()
    {
        InputManager.OnClickStart -= InputManager_OnClickStart;
        InputManager.OnPointerMove -= InputManager_OnPointerMove;
        InputManager.OnClickEnd -= InputManager_OnClickEnd;
    }

    private void InputManager_OnPointerMove(Vector3 pointerPos, Vector3 deltaPos)
    {
        if (_selectedMovementHandler != null)
        { 
            _moveResponse.OnMove(deltaPos, _selectedMovementHandler);
        }
    }

}
