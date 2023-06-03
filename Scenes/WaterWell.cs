using Godot;
using System;

public class WaterWell : Area
{
	[Export]
	public Resource playerStats;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	//public override void _Ready()
	//{
		//
	//}

	private void _on_WaterWell_body_entered(object body)
	{
		if (body.GetType() == typeof(PlayerSand))
		{
			PlayerSand playerSand = (PlayerSand)body;
			if (playerStats is PlayerStats stats)
			{
				stats.health = (int)playerSand.playerUI.healthBar.Value;
				stats.waterQt = (int)playerSand.playerUI.collectedWaterBar.Value; 
			}
			PackedScene nextLvl = (PackedScene)ResourceLoader.Load("res://Scenes/DeepLevel.tscn");
			GetTree().ChangeSceneTo(nextLvl);
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
