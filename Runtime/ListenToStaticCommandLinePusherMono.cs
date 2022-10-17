using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenToStaticCommandLinePusherMono : MonoBehaviour
{

    public CommandLineUnityEvent m_onReceivedCommand;

    private void OnEnable()
    {
        StaticCommandLinePusher.AddListener(RelayCommand);
    }

    private void OnDisable()
    {
        StaticCommandLinePusher.RemoveListener(RelayCommand);
    }
    private void RelayCommand(in string command)
    {
        m_onReceivedCommand.Invoke(command);
    }
}
public abstract class AbstractListenToStaticCommandLinePusherMono : MonoBehaviour
{
    private void OnEnable()
    {
        StaticCommandLinePusher.AddListener(OnReceivedCommandLine);
    }
    private void OnDisable()
    {
        StaticCommandLinePusher.RemoveListener(OnReceivedCommandLine);
    }
    protected abstract void OnReceivedCommandLine(in string commandLine);
}
