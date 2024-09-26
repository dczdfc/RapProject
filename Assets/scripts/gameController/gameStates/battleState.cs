using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleState : gameState
{
    private battleContext context;
    bool endChose = false;
    bool end = false;
    bool win = false;
    
    public battleState(battleContext _context, gameManager.EgameStates estate)
     :base(estate){
        context = _context;
    }
    public override void EnterState(){
        Debug.Log("Enter battleState");
        context.debug_panel.text = "battleState";
        Debug.Log(context.Pick_Queue.punch_queue[0]);
        context.battle_manager.player_pick_queue = context.Pick_Queue;
        context.battle_manager.currentEnemy = context.enemy;
        context.battle_manager.enemy_pick_queue = context.Pick_Queue;
        context.battle_manager.EndEvent.AddListener(GoNext);
        
        context.battle_panel.SetActive(true);
        context.battle_manager.SStart();
        
        
    }
    public override void ExitState(){
        Debug.Log("Exit battleState");
        context.battle_panel.SetActive(false);
    }
    public void GoNext(bool isEnd, bool isWin){
        if (isEnd)
        {
            end = isEnd;
            win = isWin;

        }else
        {
            endChose = true;
        }
        
        

    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override gameManager.EgameStates GetNextState(){
        if (endChose)
        {
            endChose = false;
            return gameManager.EgameStates.pick; 
        }if (end)
        {
            end = false;
            if (win)
            {
                return gameManager.EgameStates.win;
            }
            return gameManager.EgameStates.lose;
            
        }
        return StateKey;
    }

}
public class battleContext
{
    private Text _debugPanel;
    private pick_queue _pick_queue;
    private pick_queue _enemy_pick_queue;
    private battleManager _battleManager;
    private GameObject _battlePanel;
    private BaceEnemy _enemy;
    public battleContext(Text debugpanel, pick_queue Pick_queue,battleManager Battle_manager, GameObject battlePanel, BaceEnemy baceEnemy){
        _debugPanel = debugpanel;
        _battleManager =Battle_manager;
        _pick_queue = Pick_queue;
        _battlePanel = battlePanel;
        _enemy = baceEnemy;
    }
    public Text debug_panel => _debugPanel;
    public pick_queue Pick_Queue => _pick_queue;
    public battleManager battle_manager => _battleManager;
    public GameObject battle_panel => _battlePanel;
    public BaceEnemy enemy => _enemy;
}
