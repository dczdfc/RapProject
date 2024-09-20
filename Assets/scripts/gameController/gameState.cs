using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class gameState : BaceState<gameManager.EgameStates>
{
    public gameState(gameManager.EgameStates stateKey) : base(stateKey){
        
    }
}
