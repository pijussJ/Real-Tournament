using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TMP_Text waveText;
    async public void AnnounceWave(int wave)
    {
        waveText.text = $"Wave {wave + 1} started!";
        await new WaitForSeconds(2f);
        waveText.text = "";
    }
}
