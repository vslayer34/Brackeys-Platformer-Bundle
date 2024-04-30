using Godot;
using System;

public partial class KillZone : Area2D
{
    public override void _Ready()
    {
        BodyEntered += OnKillZoneBodyEnterd;
    }

    
    private async void OnKillZoneBodyEnterd(Node2D body)
    {
        // Remove the collision shape of the player to fall when he dies
        Player player = body as Player;
        Engine.TimeScale = 0.5f;
        player.CollisionShape.QueueFree();
        
        await ToSignal(GetTree().CreateTimer(0.5f), Timer.SignalName.Timeout);
        
        Engine.TimeScale = 1.0f;
        GetTree().ReloadCurrentScene();
    }

}
