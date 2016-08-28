using UnityEngine;
using System.Collections;

public class BaseState : MonoBehaviour
{
    // TODO probably remove monobehaviour once explore state doesn't rely on print.

    public virtual void Step() { }
}
