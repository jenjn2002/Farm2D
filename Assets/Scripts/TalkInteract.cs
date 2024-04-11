using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    [SerializeField] DialogContainer dialog;
    public override void Interact(Character character)
    {
        GameManager1.instance.dialogueSystem.Initalize(dialog);
    }
}
