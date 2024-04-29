using Godot;
using System;

public partial class Coin : Area2D
{
    public override void _Ready()
    {
        BodyEntered += OnBodyEnteredCoin;
    }

    private void OnBodyEnteredCoin(Node2D body)
    {
        QueueFree();
    }

}
