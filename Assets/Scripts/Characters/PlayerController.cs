using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputSystem.IPlayerActions
{
    public InputSystem controls;

    void Awake()
    {
        controls = new InputSystem();
        controls.Player.SetCallbacks(this);
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    public void OnPrimaryAttack(InputAction.CallbackContext context)
    {
        GetComponent<CharacterAttack>().Attack();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        CharacterMovement move = GetComponent<CharacterMovement>();
        if (move != null)
            move.Movement(context.ReadValue<Vector2>());
        else
            Debug.LogError("Char Movement comp not found");
    }

    public void OnDamage(InputAction.CallbackContext context)
    {
        Health health = GetComponent<Health>();
        if (health != null)
            health.Damaged(1);
        else
            Debug.LogError("Health comp not found");
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        PlayerInventory inv = GetComponent<PlayerInventory>();
        if (inv != null)
            inv.ToggleInventoryUI();
        else
            Debug.LogError("PLAYER INVENTORY NOT FOUND");
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        PlayerInteraction interact = GetComponent<PlayerInteraction>();
        if (interact != null)
            interact.CallInteraction();
        else
            Debug.LogError("PLAYER INTERACTION NOT FOUND");
    }
}
