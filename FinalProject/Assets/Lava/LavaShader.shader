Shader "Custom/LavaShader"
{
    Properties
    {
        //waving properties
        _TintColor("Tint Color", Color) = (1,1,1,1)
        _MainTex("Diffuse", 2D) = "white" {}
        _Freq("Frequnecy", Range(0,5)) = 3
        _Speed("Speed", Range(0,100)) = 10
        _Amp("Amplitude", Range(0,1)) = 0.5

        //overlaying propties
         _MainTexT("Main", 2D) = "white" {}
        _OverTex("Over", 2D) = "white" {}
        _scrollX("Scroll X", Range(-5,5)) = 1
        _scrollY("Scroll Y", Range(-5,5)) = 1

    }
        SubShader
        {

            CGPROGRAM
            //vertex shader as we will modify vertices 
            #pragma surface surf Lambert vertex:vert

            //define overlaying variables
            sampler2D _OverTex;
            float _scrollX;
            float _scrollY;

            //inputs for main tex and UVs
            struct Input
            {
                float2 uv_MainTex;
                float3 vertColor;
            };

            //define wave variables
            float4 _TintColor;
            float _Freq;
            float _Speed;
            float _Amp;


            //data position, normal and texcoords
            struct appdata
            {
                float4 vertex: POSITION;
                float3 normal: NORMAL;
                float4 texcoord:TEXCOORD0;
                float4 texcoord1: TEXCOORD1;
                float4 texcoord2: TEXCOORD2;
            };

            void vert(inout appdata v, out Input o)
            {
                UNITY_INITIALIZE_OUTPUT(Input,o);
                //time as sine function goes on 
                float t = _Time * _Speed;
                //height of vertices as they move in x axis
                float waveHeight = sin(t * v.vertex.x * _Freq) * _Amp + sin(t * 2 + v.vertex.x * _Freq * 2) * _Amp;
                //seting vertex to current vertex height 
                v.vertex.y = v.vertex.y + waveHeight;
                //updating noramls 
                v.normal = normalize(float3(v.normal.x + waveHeight, v.normal.y, v.normal.z));
                //color changes as height changes 
                o.vertColor = waveHeight + 2;
            }

            sampler2D _MainTex;
            sampler2D _MainTexT;
            void surf(Input IN, inout SurfaceOutput o)
            {
                //scroll x and y change over time i Unity 
                _scrollX *= _Time;
                _scrollY *= _Time;
                //rate of first texture moving 
                float3 main = (tex2D(_MainTexT, IN.uv_MainTex + float2(_scrollX, _scrollY)).rgb);
                //rate of first texture moving, *2 so it is different from main tex
                float3 over = (tex2D(_OverTex, IN.uv_MainTex + float2(_scrollX * 4.0, _scrollY * 4.0)).rgb);
                o.Albedo = (main + over) / 2.0;

              
            }
            ENDCG
        }
            FallBack "Diffuse"
}