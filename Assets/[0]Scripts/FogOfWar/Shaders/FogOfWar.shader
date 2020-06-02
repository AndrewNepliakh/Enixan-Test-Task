// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/FogOfWar"
{
	Properties
	{
		_Color ("Main color", Color) = (1,1,1,1)
		_FogRadius ("Fog Radius", Range(0, 25) ) = 5.0
        _FogFeather("Fog Feather", Range(0, 1)) = 0.5
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent" 
		}

		LOD 200

		CGPROGRAM

			#pragma surface Surf Lambert alpha vertex:Vert

			fixed4 _Color;
			float _FogRadius;
            float _FogFeather;
			float4 _ItemsPos[300];
			int _ItemsCount = 0;

			struct Input
			{
				float4 location;
			};

			float AlphaAreaForPos(Input IN, float4 pos)
			{
			    float radius = 1.0 - (_FogRadius - length(pos.xz - IN.location.xz));
				return radius * _FogFeather;
		  	}

			void Vert(inout appdata_full v, out Input o)
			{
				fixed4 posWorld = UnityObjectToClipPos(v.vertex);
				o.location = posWorld;
			}

			void Surf (Input IN, inout SurfaceOutput o)
			{
				 fixed4 baseColor = _Color;
				 o.Albedo = baseColor.rgb;
				 
				 float allAlphaPerPositions = 1.0;
				 for(int i = 0; i < _ItemsCount; i ++)
				 {
				    allAlphaPerPositions *= clamp(AlphaAreaForPos(IN, _ItemsPos[i]), 0, 1);
				 }
				 o.Alpha = allAlphaPerPositions * 0.9;
			}
			
		ENDCG
	} 

	Fallback "Transparent/VertexLit"
}