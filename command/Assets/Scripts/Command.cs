using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {
    public abstract void Execute(Animator anim, bool reverse = false);
}

public class DoNothing : Command {
    public override void Execute(Animator anim, bool reverse = false) {
    }
}

public class JumpCommand : Command {
    public override void Execute(Animator anim, bool reverse = false) {
        if (reverse)
            anim.SetTrigger("isJumpingR");
        else
            anim.SetTrigger("isJumping");
    }
}

public class WalkCommand : Command {
    public override void Execute(Animator anim, bool reverse = false) {
        if (reverse)
            anim.SetTrigger("isWalkingR");
        else
            anim.SetTrigger("isWalking");
    }
}

public class PunchCommand : Command {
    public override void Execute(Animator anim, bool reverse = false) {
        if (reverse)
            anim.SetTrigger("isPunchingR");
        else
            anim.SetTrigger("isPunching");
    }
}

public class KickCommand : Command {
    public override void Execute(Animator anim, bool reverse = false) {
        if (reverse)
            anim.SetTrigger("isKickingR");
        else
            anim.SetTrigger("isKicking");
    }
}

