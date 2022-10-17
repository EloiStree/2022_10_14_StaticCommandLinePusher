using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StaticCommandLinePusherMono : MonoBehaviour
{
    public void PushCommand(string command)
    {
        StaticCommandLinePusher.PushCommandRef(in command);
    }
    public void PushCommand(string [] commands)
    {
        StaticCommandLinePusher.PushCommandRef(in commands);
    }
    public void PushCommandRef(in string command)
    {
        StaticCommandLinePusher.PushCommandRef(in command);
    }
}

[System.Serializable]
public  class CommandLineUnityEvent: UnityEvent<string>{ }
public delegate void CommandLineDelegateEvent(in string command);
public class StaticCommandLinePusher
{
    private static List<CommandLineDelegateEvent> m_onCommandLinePush = new List<CommandLineDelegateEvent>();

    public static void AddListener(in CommandLineDelegateEvent listener)
    {
        m_onCommandLinePush.Add(listener);
    }
    public static void RemoveListener(in CommandLineDelegateEvent listener)
    {
        m_onCommandLinePush.Remove(listener);
    }

    public static bool m_useDebugLogWarning = true;
    public static void PushCommand(string command)
    {
        for (int i = 0; i < m_onCommandLinePush.Count; i++)
        {
            try
            {
                if (m_onCommandLinePush[i] != null)
                    m_onCommandLinePush[i](in command);
            }
            catch (Exception e) { if(m_useDebugLogWarning)Debug.LogWarning(e.StackTrace); }
        }
    }
    public static void PushCommandRef(in string command)
    {
        for (int i = 0; i < m_onCommandLinePush.Count; i++)
        {
            try
            {
                if (m_onCommandLinePush[i] != null)
                    m_onCommandLinePush[i](in command);
            }
            catch (Exception e) { if (m_useDebugLogWarning) Debug.LogWarning(e.StackTrace); }
        }
    }
    public static void PushCommandRef(in string [] commands)
    {
        for (int i = 0; i < commands.Length; i++)
        {
            PushCommandRef(in commands[i]);
        }
    }
}
