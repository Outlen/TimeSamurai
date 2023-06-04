using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject gameController;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
 
    void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(-100, -22), new Item {itemType = Item.ItemType.Armor, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-94, -282), new Item {itemType = Item.ItemType.ArmorAlt, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(126, -18), new Item {itemType = Item.ItemType.Hairpin, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(68, -134), new Item {itemType = Item.ItemType.HairpinAlt, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(110, -88), new Item {itemType = Item.ItemType.Bow, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(110, -127), new Item {itemType = Item.ItemType.BowAlt, amount = 1});
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
            gameController.GetComponent<WinConditions>().artifactNum ++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
