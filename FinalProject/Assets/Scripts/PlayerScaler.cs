using System;
using UnityEngine;


public interface ICommand
{
    void Execute();
    void Undo();
}


public class ScaleUpCommand : ICommand
{
    private Transform playerTransform;
    private Vector3 scaleChange;

    public ScaleUpCommand(Transform playerTransform, Vector3 scaleChange)
    {
        this.playerTransform = playerTransform;
        this.scaleChange = scaleChange;
    }

    public void Execute()
    {
        playerTransform.localScale += scaleChange;
    }

    public void Undo()
    {
        playerTransform.localScale -= scaleChange;
    }
}

public class CommandInvoker
{
    private ICommand currentCommand;

    public void SetCommand(ICommand command)
    {
        currentCommand = command;
    }

    public void ExecuteCommand()
    {
        if (currentCommand != null)
        {
            currentCommand.Execute();
        }
    }

    public void UndoCommand()
    {
        if (currentCommand != null)
        {
            currentCommand.Undo();
        }
    }
}


public class PlayerScaler : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    private CommandInvoker invoker;
    private Transform playerTransform;

    private void Start()
    {
        invoker = new CommandInvoker();
        playerTransform = transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ICommand scaleUp = new ScaleUpCommand(playerTransform, scaleChange);
            invoker.SetCommand(scaleUp);
            invoker.ExecuteCommand();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            invoker.UndoCommand();
        }
    }
}
