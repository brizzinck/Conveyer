using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasker : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _taskText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private PickUpFood _pickUpFood;
    [SerializeField] private PickFood[] _allPickFoods;
    private List<PickFood> _pickFoods = new List<PickFood>();
    private string _nameTaskFood = string.Empty;
    private int _countTaskFood = 0;
    private void Start()
    {
        _pickUpFood.PutPickFood += CheckTaskPickFood;
        SetTask();
    }
    private void SetTask()
    {
        _nameTaskFood = _allPickFoods[Random.Range(0, _allPickFoods.Length)].NameFood;
        _countTaskFood = Random.Range(1, 6);
        _taskText.text = "Collect " + _countTaskFood + " " + _nameTaskFood;
    }
    private void CheckTaskPickFood(PickFood pickFood)
    {  
        if (pickFood.NameFood == _nameTaskFood)
            _pickFoods.Add(pickFood);
        if (_pickFoods.Count >= _countTaskFood)
        {
            _taskText.text = "Level Passed";
            StartCoroutine(Finish());
            AnimationController.Finish();
        }
    }
    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(3.3f);
        CameraToPlayer.GoPlayer();
        yield return new WaitForSeconds(.5f);
        _nextButton.gameObject.SetActive(true);
    }
}
