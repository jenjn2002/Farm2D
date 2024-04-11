using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public ItemContainer inventoryContainer;

    public ItemDragAndDrop dragAndDropController;
    public DayTimeController timeController;
    public DialogueSystem dialogueSystem;
}
