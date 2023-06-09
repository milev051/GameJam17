using Godot;
using System;

public class EnemySpawner : Spatial
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    PackedScene enemyScene;
    Enemy enemy;
    Timer timer;
    RandomNumberGenerator random = new RandomNumberGenerator();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        random = new RandomNumberGenerator();
        random.Randomize();
        timer = GetNode<Timer>("Timer");
        timer.WaitTime = (Mathf.Abs((int)random.Randi()) % 10 + 5);
        GD.Print(timer.WaitTime);
        timer.Start();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    public void _on_Timer_timeout()
    {
        GD.Print(((DeepLevel)GetParent()).number);
        if (((DeepLevel)GetParent()).number > 0)
        {
            random = new RandomNumberGenerator();
            random.Randomize();
            enemy = (Enemy)enemyScene.Instance();
            ((DeepLevel)GetParent()).number -= 1;
            enemy.Scale = new Vector3(5.0f, 5.0f, 0.0f);
            enemy.GetNode<Sprite3D>("Sprite3D").Modulate = new Color(random.Randf(), random.Randf(), random.Randf());
            GetParent().AddChild(enemy);
            enemy.Translation = this.GlobalTranslation;
            Translation += new Vector3(random.Randf() * 20, 0.0f, 0.0f);
            timer.Start();
        }
        else
        {
            timer.Start();
        }
    }
}
