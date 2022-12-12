using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
}

public class MoveLeft : Command
{
    private PlayerMovement _controller;

    public MoveLeft(PlayerMovement controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.MoveLeft();
    }
}

public class MoveRight : Command
{
    private PlayerMovement _controller;

    public MoveRight(PlayerMovement controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.MoveRight();
    }
}

public class MoveUp : Command
{
    private PlayerMovement _controller;

    public MoveUp(PlayerMovement controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        Debug.Log("Jump");
        _controller.MoveUp();
    }
}