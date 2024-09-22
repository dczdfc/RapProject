using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickGameState : gameState
{
    private pickGameContext context;
    
    bool endChose = false;
    public pickGameState(pickGameContext _context,gameManager.EgameStates estate)
     :base(estate){
        context = _context;
        
    }
    public override void EnterState(){
        context.inv_controller._pick_queue = context.Pick_Queue;
        Debug.Log("Enter pickGameState");
        context.debug_panel.text = "pickGameState";
        context.pick_panel.SetActive(true);
        context.inv_controller.endChoseEvent.AddListener(GoNext);
    }
    public void GoNext(){
        
        endChose = true;

    }
    public override void ExitState(){
        Debug.Log("Exit pickGameState");
        context.pick_panel.SetActive(false);
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override gameManager.EgameStates GetNextState(){
        if (endChose)
        {
            endChose = false;
            return gameManager.EgameStates.battle; 
        }
        return StateKey;
    }
}
public class pickGameContext
{
    private Text _debugPanel;
    private pick_queue _pick_queue;
    private GameObject _pickPanel;
    private inventoryController _invController;
    private BaceEnemy _enemy;
    public pickGameContext
    (Text debugpanel, GameObject pickPanel,inventoryController invController, pick_queue Pick_queue, BaceEnemy baceEnemy){
        _pick_queue = Pick_queue;
        _debugPanel = debugpanel;
        _pickPanel = pickPanel;
        _invController = invController;
        _enemy = baceEnemy;
    }
    public Text debug_panel => _debugPanel;
    public GameObject pick_panel => _pickPanel;
    public inventoryController inv_controller => _invController;
    public pick_queue Pick_Queue => _pick_queue;
    public BaceEnemy enemy => _enemy;
}