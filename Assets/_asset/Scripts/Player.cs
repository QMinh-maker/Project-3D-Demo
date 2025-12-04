using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerUi playerUi;
    public Transform playerFoot;
    public Health health;

    public MoveByKey moveBykey;
    public MoveByJoystick moveByVJoystick;
    public Mousemovement rotateByMouse;
    public RotateByDrag rotateByDrag;

#if UNITY_EDITOR
    [MenuItem("Game/Switch To Mobile Control")]
    public static void SwitchToMobileControl() => SetMobileControl(true);

    [MenuItem("Game/Switch To Pc Control")]
    public static void SwitchToPcControl() => SetMobileControl(false);

    private static void SetMobileControl(bool enable)
    {
        Player player = Player.Instance;
        Undo.RegisterFullObjectHierarchyUndo(player, "Set mobile control");
        player.moveBykey.enabled = !enable;
        player.moveByVJoystick.enabled = enable;
        player.rotateByMouse.enabled = !enable;
        player.rotateByDrag.enabled = enable;
    }
#endif
}
