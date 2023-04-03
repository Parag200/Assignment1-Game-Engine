Shader "Custom/Depth"
{
    Properties
    {
        
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
       
    }
        CGINCLUDE
#include "UnityCG.cginc"
        sampler2D _MainTex;
        float4 _MainTe_TexelSize;

        float _FocusDistance, _FocusRange;

        struct VertexData
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0
        };

        struct Interpolators
        {
            float4 pos  : SV_POSITION;
            float2 uv : TEXCOORD0;
        };

        Interpolators VertexProgram(VertexData v)
        {
            Interpolators i;
            i.pos = UnityObjectToClipPos(v.vertex);
            i.uv = v.uv;
            return i;
        }
        ENDCG




        SubShader
        {
            Cull Off
            ZTest Always
            ZWrite Off

            Pass
            {
            CGPROGRAM

            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

            half FragmentProgram(Interpolators i) : SV_Target
            {
              
            }
            }
     
            ENDCG
        }
    FallBack "Diffuse"
}
