using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode AttackKey = KeyCode.Space;

    public float ReturnHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool ReturnJumpPressed()
    {
        return Input.GetKeyDown(JumpKey);
    }

    public bool ReturnAttackPressed()
    {
        return Input.GetKeyDown(AttackKey);
    }
}