using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private PickUpFood _pickUpFood;
    [SerializeField] private PickFood[] _allPickFoods;
    private List<PickFood> _pickFoods = new List<PickFood>();
    private static string _nameTaskFood = string.Empty;
    private static int _countTaskFood = 0;
    private void Start()
    {
        _pickUpFood.PutPickFood += CheckTaskPickFood;
        SetTask();
    }
    private void SetTask()
    {
        if (_nameTaskFood == string.Empty)
        {
            _nameTaskFood = _allPickFoods[Random.Range(0, _allPickFoods.Length)].NameFood;
            _countTaskFood = Random.Range(1, 6);
        }
        ChangeText(_countTaskFood);
    }

    private void ChangeText(int count)
    {
        _taskText.text = "Collect " + count + " " + _nameTaskFood;
        if (count > 1)
            _taskText.text = _taskText.text = "Collect " + count + " " + _nameTaskFood + "s";
        if (count == 1)
            _taskText.text = _taskText.text = "Collect " + count + " " + _nameTaskFood;
    }

    private void CheckTaskPickFood(PickFood pickFood)
    {  
        if (pickFood.NameFood == _nameTaskFood)
        {
            UIController.AddScore();
            _pickFoods.Add(pickFood);
            int current = _countTaskFood - _pickFoods.Count;
            ChangeText(current);
        }
        if (_pickFoods.Count >= _countTaskFood)
        {
            _taskText.text = "Level Passed";
            _pickUpFood.BasketFood.Hidetext();
            StartCoroutine(Finish());
            AnimationController.Finish();
        }
        else if (_pickUpFood.BasketFood.BasketFull())
        {
            _pickUpFood.SetPickUping();
            AnimationController.Lost();
        }
    }
    private IEnumerator Finish()
    {
        ClearTask();
        yield return new WaitForSeconds(3.3f);
        CameraToPlayer.GoPlayer();
        yield return new WaitForSeconds(.5f);
        _nextButton.gameObject.SetActive(true);
    }
    private void ClearTask()
    {
        _nameTaskFood = string.Empty;
        _countTaskFood = 0;
    }
}
