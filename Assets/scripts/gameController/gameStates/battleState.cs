using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleState : gameState
{
    private battleContext context;
    public battleState(battleContext _context, gameManager.EgameStates estate)
     :base(estate){
        context = _context;
    }
    public override void EnterState(){
        Debug.Log("Enter battleState");
        context.debug_panel.text = "battleState";
        
    }
    public override void ExitState(){
        Debug.Log("Exit battleState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override gameManager.EgameStates GetNextState(){
        return StateKey;
    }

}
public class battleContext
{
    private Text _debugPanel;
    public battleContext(Text debugpanel){
        _debugPanel = debugpanel;
    }
    public Text debug_panel => _debugPanel;
}
