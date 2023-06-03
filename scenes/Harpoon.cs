using Godot;
using System;

public class Harpoon : Spatial
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Sprite sprite;
	RayCast raycast;
	Timer timer;
	AnimationPlayer animPlayer;
	PlayerDepth player;
	public bool canShoot;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<CanvasLayer>("CanvasLayer").GetNode<Control>("Control").GetNode<Sprite>("Sprite");
		raycast = GetNode<RayCast>("RayCast");
		timer = GetNode<Timer>("Timer");
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		player = (PlayerDepth)GetParent().GetParent();
		canShoot = true;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(float delta)
	// {
	//     GD.Print(raycast.GetCollider());
	// }

	public void shoot()
	{
		canShoot = false;
		timer.Start();
		animPlayer.Play("shoot");
		if(raycast.IsColliding() && ((Node)raycast.GetCollider()).IsInGroup("enemies"))
		{
			Enemy enemy = (Enemy)raycast.GetCollider();
			if(enemy.damage())
				player.playerUI.UpdateCollectedWaterBar(200);
		}
	}

	public void _on_Timer_timeout()
	{
		canShoot = true;
	}
}
