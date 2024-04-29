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
        await ToSignal(GetTree().CreateTimer(1.0f), Timer.SignalName.Timeout);

        GetTree().ReloadCurrentScene();
    }

}
