using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : ToolHit
{
    [SerializeField] GameObject pickupDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    [SerializeField] int itemCountInOneDrop=1;
    [SerializeField] Item item;
    [SerializeField] ResourceNodeType nodeType;
    public override void Hit()
    {
        while(dropCount> 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread/2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);

        }
        Destroy(gameObject);
    }

    public override bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return canBeHit.Contains(nodeType);
    }
}
