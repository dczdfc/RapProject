using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaceEnemy : MonoBehaviour
{
    public Sprite Disie;
    private pick_queue last_round;
    public pick_queue get_pick_queue(int roundNumb, pick_queue last_round){
        pick_queue standartQueue = new pick_queue(new int[4]{2,1,1,2});
        return standartQueue;

    }
    
}
