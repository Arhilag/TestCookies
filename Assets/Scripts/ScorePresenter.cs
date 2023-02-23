using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    private ScoreModel _scoreModel;
    private void Awake()
    {
        _scoreModel = new ScoreModel();
        _scoreModel.OnChangeBatScore += _scoreView.SetBatScore;
        _scoreModel.OnChangeBackboardScore += _scoreView.SetBackboardScore;
        BallCollision.OnTriggerBackboard += OnTriggerBackboard;
        BallCollision.OnTriggerBat += OnTriggerBat;
    }
    
    private void OnDestroy()
    {
        _scoreModel.OnChangeBatScore -= _scoreView.SetBatScore;
        _scoreModel.OnChangeBackboardScore -= _scoreView.SetBackboardScore;
        BallCollision.OnTriggerBackboard -= OnTriggerBackboard;
        BallCollision.OnTriggerBat -= OnTriggerBat;
    }

    private void OnTriggerBat()
    {
        _scoreModel.AddBatScore();
    }

    private void OnTriggerBackboard()
    {
        _scoreModel.AddBackboardScore();
    }
}
