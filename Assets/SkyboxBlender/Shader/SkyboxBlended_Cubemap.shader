Shader "Skybox/Blended_Cubemap" {
	Properties{
		_Tint("Tint Color", Color) = (.5, .5, .5, .5)
		_Blend("Blend", Range(0.0,1.0)) = 0.5

		_TargetSkybox("_TargetSkybox", Cube) = ""{}
		_CurrentSkybox("_CurrentSkybox", Cube) = ""{}

	}

		SubShader{
		Tags{ "Queue" = "Background" }
		Cull Off
		Fog{ Mode Off }
		Lighting Off
		Color[_Tint]
		Pass
		{
			SetTexture[_TargetSkybox]{ combine texture }
			SetTexture[_CurrentSkybox]{ constantColor(1,0,1,[_Blend]) combine texture lerp(constant) previous }
		}
	}

		Fallback "Skybox/6 Sided", 1
}