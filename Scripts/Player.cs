using Godot;
using Scripts.Helper;
using Scripts.HelperClasses;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public CollisionShape2D CollisionShape { get; private set; }

	[Export]
	public AnimatedSprite2D AnimatedSprite { get; private set; }
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed(ActionMapConsts.JUMP) && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector(ActionMapConsts.MOVE_LEFT, ActionMapConsts.MOVE_RIGHT, "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			
			// Flip the animation according to the input direction
			AnimatedSprite.FlipH = direction.X < 0;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		// Play the correct animations
		if (IsOnFloor())
		{
			if (direction.X == 0)
			{
				AnimatedSprite.Play(AnimationConstants.Player.IDLE);
			}
			else
			{
				AnimatedSprite.Play(AnimationConstants.Player.RUN);
			}
		}
		else
		{
			AnimatedSprite.Play(AnimationConstants.Player.JUMP);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
