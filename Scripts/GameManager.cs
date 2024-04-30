using Godot;
using System;

public partial class GameManager : Node2D
{
    [Export]
    private Label _scoreDisplay;

    public int Score { get; private set; }
    
    
    public void AddScore()
    {
        Score += 1;
        _scoreDisplay.Text = $"You've collected {Score} coins!";
    }
}
