using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]
public class DisplayPlayerStatusEffects : MonoBehaviour
{
    private ProgressBar progressBar;

    public bool showStatusEffects;
    public GameUnit player;

    private void Awake()
    {
        progressBar = GetComponent<ProgressBar>();
    }

    private void Start()
    {

        player.OnStatusEffectAdded.AddListener(AddStatusEffectIcon);
    }

    private void AddStatusEffectIcon(StatusEffectSlot statusEffectSlot)
    {
        if (showStatusEffects)
            progressBar.AddStatusEffectFrameIcon(statusEffectSlot, 2.5f);
    }
}
