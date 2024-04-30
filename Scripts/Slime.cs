using Godot;
using System;

public partial class Slime : Node2D
{
	[ExportGroup("Required Nodes")]
	[Export]
	private AnimatedSprite2D _animatedSprite;

	[Export]
	private RayCast2D _rayToRight;

	[Export]
	private RayCast2D _rayToLeft;


	private const float SPEED = 60.0f;
	// the movement direction 1: to right, -1: to left
	private Vector2 _direction = Vector2.Right;

    public override void _Process(double delta)
    {
        if (_rayToRight.IsColliding())
		{
			_direction = Vector2.Left;
			_animatedSprite.FlipH = true;
		}
		
		if (_rayToLeft.IsColliding())
		{
			_direction = Vector2.Right;
			_animatedSprite.FlipH = false;
		}

		Position += Vector2.Right * (float)delta * _direction * SPEED;
    }
}
