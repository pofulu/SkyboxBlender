using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SkyboxBlenderClip : PlayableAsset, ITimelineClipAsset
{
    public SkyboxBlenderBehaviour template = new SkyboxBlenderBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SkyboxBlenderBehaviour>.Create (graph, template);
        SkyboxBlenderBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
