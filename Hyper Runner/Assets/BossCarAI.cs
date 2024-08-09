using BossFight.Cyber;
using UnityEngine;

public class BossCarAI : ARacingCar
{
    protected override GasPedalState GetPlayerGasInput()
    {
        return GasPedalState.Neutral;
    }
    protected override TurningDirection GetTurningDirectionInput()
    {
        return TurningDirection.None;
    }
}
