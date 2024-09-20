using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class startGameState : gameState
{
    private startGameContext context;
    float currentTime;
    bool isSholAll = false;
    public startGameState(startGameContext _context , gameManager.EgameStates estate)
     :base(estate){
        context = _context;
    }
    public override void EnterState(){
        isSholAll = false;
        Debug.Log("Enter startGameState");
        context.debug_panel.text = "startGameState";
        currentTime = 3;
        
    }
    public override void ExitState(){
        Debug.Log("Exit startGameState");
    }
    
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        currentTime -= Time.fixedDeltaTime;
        if (currentTime < 3 && currentTime > 2)
        {
            context.start_text.text = "ready";
        }else if (currentTime < 2 && currentTime > 1)
        {
            context.start_text.text = "set";
        }else if (currentTime < 1 && currentTime > 0)
        {
            context.start_text.text = "GO";
        }else
        {
            context.start_text.text = "";
            isSholAll = true;
        }

    }
    
    public override gameManager.EgameStates GetNextState(){
        if (isSholAll)
        {
            isSholAll = false;
            return gameManager.EgameStates.pick;
        }
        return StateKey;
    }
}
public class startGameContext
{
    private Text _debugPanel;
    private Text _startText;
    public startGameContext
    (Text debugpanel,Text startText){
        _debugPanel = debugpanel;
        _startText = startText;
    }
    public Text debug_panel => _debugPanel;
    public Text start_text => _startText;
}
