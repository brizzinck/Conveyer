using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class PickUpFood : MonoBehaviour
{
    public UnityAction<float> ActionsWithFood;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _resetPostion;
    [SerializeField] private Transform _playerHand;
    [SerializeField] private Transform _basket;
    [SerializeField] private Transform _parent;
    [SerializeField] private BasketFood _basketFood;
    private Food _currentFood = null;
    private Vector3 _centerHand = new Vector3(-0.0128f, 0.0306f, 0.0571f);
    private bool _isPickUp = false;

    public bool IsPickUp { get => _isPickUp; }

    public void SetStopConveyor() => ActionsWithFood?.Invoke(0);
    public void TakeFood()
    {
        if (_currentFood == null) return;
        _isPickUp = true;
        _currentFood.PickFood.transform.parent = _playerHand;
        _currentFood.PickFood.transform.localPosition = _centerHand;
    }
    public void PutFood()
    {
        ActionsWithFood?.Invoke(0.5f);
        _basketFood.PutFood(_currentFood.PickFood);
        _currentFood.PickFood.FreeGravity();
        _currentFood = null;
        _isPickUp = false;
    }
    private void Update()
    {
        if (_currentFood != null) AnimationController.TurnToObject(_parent, 
            new Vector3(_currentFood.transform.position.x, 
            _currentFood.transform.position.y, 
            _currentFood.transform.position.z), 25);
        else 
            AnimationController.TurnToObject(_parent, _resetPostion, 25);
        if (_currentFood != null) return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Food food))
                {
                    if (food.IsPick) return;
                    _currentFood = food;
                    food.IsPick = true;
                    AnimationController.PickUp(_currentFood.transform);
                }
            }
        }
    }
}
