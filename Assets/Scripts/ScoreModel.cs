using System;

public class ScoreModel
{
    private int _batScore = 0;
    private int _backboardScore = 0;

    public Action<int> OnChangeBatScore;
    public Action<int> OnChangeBackboardScore;

    public void AddBatScore()
    {
        _batScore++;
        OnChangeBatScore?.Invoke(_batScore);
    }

    public void AddBackboardScore()
    {
        _backboardScore++;
        OnChangeBackboardScore?.Invoke(_backboardScore);
    }
}
