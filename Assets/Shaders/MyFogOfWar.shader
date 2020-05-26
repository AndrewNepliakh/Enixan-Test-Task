Shader "Custom/MyFogOfWar"
{
	Properties
	{
		_Color ("Main color", Color) = (1,1,1,1)
		_PlayerPos ("Player Position", Vector) = (0,0,0,1)
		_FogRadius ("FogRadius", Float) = 1.0
        _FogMaxRadius("FogMaxRadius", Float) = 0.5
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
            float _FogMaxRadius;
			float4 _PlayerPos;

			struct Input
			{
				float2 uv_MainTex;
				float2 location;
			};

			float AlphaAreaForPos(float4 pos, float2 nearVertex)
			{
				 float atten = clamp(_FogRadius - length(pos.xz - nearVertex.xy), 0.0, _FogRadius);
                 return (1.0/_FogMaxRadius) * atten / _FogRadius;
			}

			void Vert(inout appdata_full v, out Input o)
			{
				float4 posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.uv_MainTex = v.texcoord;
				o.location = posWorld.xz;
			}

			void Surf (Input IN, inout SurfaceOutput o)
			{
				 fixed4 baseColor = _Color;
				 float alpha = (baseColor.a + AlphaAreaForPos(_PlayerPos, IN.location));
				 o.Albedo = baseColor.rgb;
				 o.Alpha = clamp(alpha, 0, 1);
			}
			
		ENDCG
	} 

	Fallback "Transparent/VertexLit"
}