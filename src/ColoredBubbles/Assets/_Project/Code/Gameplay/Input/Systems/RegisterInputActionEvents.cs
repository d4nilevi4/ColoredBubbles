using UnityEngine.InputSystem;

namespace Bubbles.Gameplay;

public struct RegisterInputActionEvents : ISystem
{
    public void Init()
    {
        PlayerInputActions actions = GameW.GetResource<PlayerInputMap>().Value;

        actions.Gameplay.Interact.performed += SendDodgePerformedEvent;
    }

    public void Destroy()
    {
        PlayerInputActions actions = GameW.GetResource<PlayerInputMap>().Value;

        actions.Gameplay.Interact.performed -= SendDodgePerformedEvent;
    }

    private void SendDodgePerformedEvent(InputAction.CallbackContext _) =>
        GameW.SendEvent(new InteractionEvent());
}