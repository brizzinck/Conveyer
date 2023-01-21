using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _addScore;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _restartButton;
    private static TextMeshProUGUI addScore;
    private static Transform transformCanvas;
    public static void AddScore()
    {
        TextMeshProUGUI score = Instantiate(addScore, transformCanvas);
        score.transform.DOLocalMoveY(250, 1).OnComplete(() =>
        {
            score.DOFade(0, 1).OnComplete(() => 
                Destroy(score.gameObject));
        });
    }
    private void Start()
    {
        _restart.onClick.AddListener(ReStarting);
        _restartButton.onClick.AddListener(ReStarting);
        addScore = _addScore;
        transformCanvas = transform;
    }
    private void ReStarting()
    {
        SceneManager.LoadScene(0);
    }
}
