using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class SkyboxBlenderBehaviour : PlayableBehaviour
{
	public AnimationCurve animationCurve;
	public Material skyboxBlender;

	public override void PrepareFrame(Playable playable, FrameData info)
	{
		base.PrepareFrame(playable, info);

		if (skyboxBlender)
		{
			if (RenderSettings.skybox != skyboxBlender)
				RenderSettings.skybox = skyboxBlender;

			var blend = Map((float)playable.GetTime(), 0, (float)playable.GetDuration(), 0, 1);
			RenderSettings.skybox.SetFloat("_Blend", animationCurve.Evaluate(blend));
		}
	}

	public float Map(float value, float low1, float high1, float low2, float high2)
	{
		return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
	}
}
