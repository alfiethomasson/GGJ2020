using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{

    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
   void BuildDB()
   {
       items = new List<Item>(new Item(0, "Spare Part", "A rusty old part from a long forgotten era."));
   }

  private void Awake() {
       {
           BuildDB();
       }
   }
}
