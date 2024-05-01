using Godot;
using System;

public partial class Coin : Area2D
{
    [Export]
    private AnimationPlayer _animPlayer;
    private GameManager _gameManager;

    
    public override void _Ready()
    {
        _gameManager = GetOwner<GameManager>();
        BodyEntered += OnBodyEnteredCoin;
    }

    private void OnBodyEnteredCoin(Node2D body)
    {
        _gameManager.AddScore();
        _animPlayer.Play("Pickup");
    }

}
