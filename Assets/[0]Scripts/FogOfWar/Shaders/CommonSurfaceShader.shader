Shader "Custom/CommonSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        _ItemPos ("Item Position", Vector) = (0,0,0,1)
        _FogRadius ("Fog Radius", Range(0, 25) ) = 5.0
        _FogFeather("Fog Feather", Range(0, 10)) = 0.5
    }
    SubShader
    {
        Tags
		{
			"RenderType" = "Opaque" 
		}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows vertex:vert
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        
        float _FogRadius;
        float _FogFeather;
	    float4 _ItemsPos[300];
		int _ItemsCount = 0;

        struct Input
        {
            float2 uv_MainTex;
            float4 location;
        };
        
        float AlphaAreaForPos(Input IN, float4 pos)
		{
		    float radius = _FogRadius - length(pos.xz - IN.location.xz);
			return radius * _FogFeather;
		}
		
		void vert(inout appdata_full v, out Input o)
		{
			fixed4 posWorld = mul(unity_ObjectToWorld, v.vertex);
			o.uv_MainTex = v.texcoord;
			o.location = posWorld;
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            
            float allOcclusionPerPositions = 1.0;
		    for(int i = 0; i < _ItemsCount; i ++)
		    {
			    allOcclusionPerPositions += clamp(AlphaAreaForPos(IN, _ItemsPos[i]), -1, 1);
			}
			
			o.Occlusion = clamp(allOcclusionPerPositions, -1, 1); 
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
