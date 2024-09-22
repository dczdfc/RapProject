using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class pick_queue
{
    public int[] punch_queue;
    

    public pick_queue(int[] punchIDs){
        punch_queue = punchIDs;
    }
}
public class inventoryController : MonoBehaviour
{
    public pick_queue _pick_queue;
    public enum PunchTipes
    {
        rock,
        paper,
        scissors

    }
    public Image[] slots;
    public Sprite[] PunchTipesImages = new Sprite[3];
    public UnityEvent endChoseEvent;
    
    [SerializeField] private int[] slotIDs;
    
    public void AddPunch(int punchTipeID){
        /*
        inventoryController.PunchTipes punchTipe;
        switch (punchTipeID)
        {
            case 1:
                punchTipe = PunchTipes.rock;
                break;
            case 2:
                punchTipe = PunchTipes.paper;
                break;
            case 3:
                punchTipe = PunchTipes.scissors;
                break;
            default: 
                punchTipe = PunchTipes.rock;
                break;
        }*/
        for (int i = 0; i < slotIDs.Length; i++)
        {
            if (slotIDs[i] == 0)
            {
                slotIDs[i] = punchTipeID;
                slots[i].sprite = PunchTipesImages[punchTipeID];
                break;
            }
        }




    }
    public void ClearCell(int cellID){
        slotIDs[cellID] = 0;
        slots[cellID].sprite = PunchTipesImages[0];

    }
    public void ConfermColodu(){
        for (int i = 0; i < slotIDs.Length; i++)
        {
            if (slotIDs[i] == 0)
            {
                return;
            }
        }

        _pick_queue.punch_queue = slotIDs;
        endChoseEvent.Invoke();
        

    }
    void Start()
    {
        slotIDs = new int[slots.Length];
    }

    void Update()
    {
        
    }
}
