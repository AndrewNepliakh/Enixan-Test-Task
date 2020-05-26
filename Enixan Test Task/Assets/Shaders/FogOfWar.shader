
Shader "Custom/FogOfWar" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _FogRadius ("FogRadius", Float) = 1.0
    _FogMaxRadius("FogMaxRadius", Float) = 0.5
    _Player_Pos ("Player Position", Vector) = (1,1,1,1)
}

SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 200
    //Blend SrcAlpha OneMinusSrcAlpha
    //Cull Off

    CGPROGRAM
    #pragma surface surf Lambert alpha vertex:vert 

    fixed4     _Color;
    float     _FogRadius;
    float     _FogMaxRadius;
    float4     _Player_Pos;

    struct Input {
        float2 uv_MainTex;
        float2 location;
    };

        //return 0 if (pos - nearVertex) > _FogRadius
    float AlphaAreaForPos(float4 pos, float2 nearVertex) {
        float atten = clamp(_FogRadius - length(pos.xz - nearVertex.xy), 0.0, _FogRadius);
        return (1.0/_FogMaxRadius)*atten/_FogRadius;
    }

    void vert(inout appdata_full vertexData, out Input outData) {
        //float4 pos = UnityObjectToClipPos(vertexData.vertex);
        float4 posWorld = mul(unity_ObjectToWorld, vertexData.vertex);
        outData.uv_MainTex = vertexData.texcoord;
        outData.location = posWorld.xz;
    }

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 baseColor = _Color;
        float alpha = (1.0 - (baseColor.a + AlphaAreaForPos(_Player_Pos, IN.location)));
        o.Albedo = baseColor.rgb;
        o.Alpha = alpha;
    }

    ENDCG
}

Fallback "Transparent/VertexLit"
}