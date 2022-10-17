using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SendCommandLineOnMouseEventMono : MonoBehaviour
{
    public string[] m_onMouseEnterCommands;
    public UnityEvent m_onMouseEnter;
    [Space(5)]
    public string[] m_onmouseDownCommands;
    public UnityEvent m_onmouseDown;
    [Space(5)]
    public string[] m_onMouseUpCommands;
    public UnityEvent m_onMouseUp;
    [Space(5)]
    public string[] m_onMouseExitCommands;
    public UnityEvent m_onMouseExit;

    private void OnMouseDown()
    {
        m_onmouseDown.Invoke();
        StaticCommandLinePusher.PushCommandRef(in m_onmouseDownCommands);
    }
    private void OnMouseEnter()
    {
        m_onMouseEnter.Invoke();
        StaticCommandLinePusher.PushCommandRef(in m_onMouseEnterCommands);
    }
    private void OnMouseExit()
    {
        m_onMouseExit.Invoke();
        StaticCommandLinePusher.PushCommandRef(in m_onMouseExitCommands);
    }
    private void OnMouseUp()
    {
        m_onMouseUp.Invoke();
        StaticCommandLinePusher.PushCommandRef(in m_onMouseUpCommands);
    }

}
