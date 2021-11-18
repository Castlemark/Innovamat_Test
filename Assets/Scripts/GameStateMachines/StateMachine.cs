using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IState State;

    public void SetState(IState state)
    {
        State = state;
        StartCoroutine(State.Execute());
    }
}