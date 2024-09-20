using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameState : gameState
{
    private endGameContext context;
    public endGameState(endGameContext _context, gameManager.EgameStates estate)
     :base(estate){
        context = _context;
    }
    public override void EnterState(){
        Debug.Log("Enter endGameState");
        context.debug_panel.text = "endGameState";
        
    }
    public override void ExitState(){
        Debug.Log("Exit endGameState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override gameManager.EgameStates GetNextState(){
        return StateKey;
    }
}
public class endGameContext
{
    private Text _debugPanel;
    public endGameContext
    (Text debugpanel){
        _debugPanel = debugpanel;
    }
    public Text debug_panel => _debugPanel;
}
