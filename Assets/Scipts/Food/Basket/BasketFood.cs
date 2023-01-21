using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasketFood : MonoBehaviour
{
    [SerializeField] private int _fullCount;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Button _restartButton;
    private int _countFoodInBasket = 0;
    public void PutFood(PickFood food)
    {
        _countFoodInBasket++;
        _countText.text = "Basket full of: " + _countFoodInBasket + "/" + _fullCount; 
        food.transform.parent = transform;
        food.transform.localPosition = Vector3.zero;
        food.transform.rotation = Quaternion.identity;
    }
    public void Hidetext() => _countText.gameObject.SetActive(false);
    public bool BasketFull()
    {
        if (_fullCount == _countFoodInBasket)
        {
            _countText.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(true);
            return true;
        }
        else
            return false;
    }
    private void Start()
    {
        _countText.text = "Basket full of: " + "0/" + _fullCount;
    }
}
