using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _batScoreText;
    [SerializeField] private TMP_Text _backboardScoreText;

    public void SetBatScore(int score)
    {
        _batScoreText.text = $"{score}";
    }
    
    public void SetBackboardScore(int score)
    {
        _backboardScoreText.text = $"{score}";
    }
}
