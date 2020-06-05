// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/VolumeFog"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        
        LOD 200
        
        CGPROGRAM
        
        #pragma surface surf Standard alpha vertex:vert
        #pragma target 3.0
        
        fixed4 _Color;
        
        struct Input 
        {
            float4 location;
        };
        
        void vert(inout appdata_full v, out Input o)
        {
            o.location =  mul(UNITY_MATRIX_VP, v.vertex);
        }
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = clamp( IN.location, 0, 1);
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}