using UnityEngine;
using System.Collections;
using Firebase.Analytics;

public class GamePlayState: _StatesBase {

    private float gamePlayDuration;

    #region implemented abstract members of _StatesBase
    public override void OnActivate() {
        Managers.UI.panel.SetActive(false);
        Managers.UI.ActivateUI(Menus.INGAME);

        gamePlayDuration = Time.time;
        Managers.Cam.ZoomIn();
        Debug.Log("<color=green>Gameplay State</color> OnActive");

        // Log a LevelStart event with Firebase whenever user starts/continues a level
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
    }
    public override void OnDeactivate() {
        Managers.Game.stats.timeSpent += Time.time - gamePlayDuration;
        Debug.Log("<color=red>Gameplay State</color> OnDeactivate");
    }

    public override void OnUpdate() {
        if (Managers.Game.currentShape != null)
            Managers.Game.currentShape.movementController.ShapeUpdate();
        Debug.Log("<color=yellow>Gameplay State</color> OnUpdate");
    }
    #endregion

}
