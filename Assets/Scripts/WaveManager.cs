/*using UnityEngine;

public class WaveManager : MonoBehaviour {
    private BattleManager battleManager;s
    private float waveTimer = 120f; 
    private bool isWaveInProgress = false;

    void Start() {
        battleManager = FindObjectOfType<BattleManager>(); 
    }

    void Update() {
        if (!isWaveInProgress) {
            waveTimer -= Time.deltaTime;

            if (waveTimer <= 0f) {
                StartWave();
                waveTimer = 120f; 
            }
        }
    }

    private void StartWave() {
        isWaveInProgress = true;
        battleManager.StartBattle(); 
    }

    public void OnWaveCompleted() {
        isWaveInProgress = false;
        battleManager.EndBattle(); 
    }
}
*/