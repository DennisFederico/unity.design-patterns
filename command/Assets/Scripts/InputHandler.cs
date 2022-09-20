using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    public GameObject actor;
    Animator anim;

    Command Jump, Walk, StopWalk, Punch, Kick;
    List<Command> oldCommands = new List<Command>();

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;

    void Start() {
        anim = actor.GetComponent<Animator>();
        Jump = new JumpCommand();
        Walk = new WalkCommand();
        // StopWalk = new StopWalk();
        Punch = new PunchCommand();
        Kick = new KickCommand();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    void Update() {        
        if (!isReplaying) {
            HandleInput();
        }
        StartReplay();
    }

    void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump.Execute(anim);
            oldCommands.Add(Jump);
        }
            
        else if (Input.GetKeyDown(KeyCode.P)){
            Punch.Execute(anim);
            oldCommands.Add(Punch);
        }
            
        else if (Input.GetKeyDown(KeyCode.K)){
            Kick.Execute(anim);
            oldCommands.Add(Kick);
        }
            
        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            Walk.Execute(anim);
            oldCommands.Add(Walk);
        }
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter)){
            shouldStartReplay = true;
        }

        if (Input.GetKeyDown(KeyCode.Z)){
            UndoLastCommand();
        }
    }

    void UndoLastCommand() {
        if (oldCommands.Count > 0) {
            Command c = oldCommands[oldCommands.Count -1];
            oldCommands.RemoveAt(oldCommands.Count -1);
            c.Execute(anim, true);
        }
    }

    void StartReplay() {
        if (shouldStartReplay && oldCommands.Count > 0) {
            shouldStartReplay = false;
            if(replayCoroutine != null) {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands() {
        isReplaying = true;
        foreach (Command command in oldCommands) {
            command.Execute(anim);
            yield return new WaitForSeconds(1f);
        }
        isReplaying = false;
    }

}
