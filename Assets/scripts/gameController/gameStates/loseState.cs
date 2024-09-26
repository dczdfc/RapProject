using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseState : gameState
{
    private endGameContext context;
    public loseState(endGameContext _context, gameManager.EgameStates estate)
     :base(estate){
        context = _context;
    }
    public override void EnterState(){
        Debug.Log("Enter loseState");
        context.debug_panel.text = "loseState";
        
    }
    public override void ExitState(){
        Debug.Log("Exit loseState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override gameManager.EgameStates GetNextState(){
        return StateKey;
    }
}
