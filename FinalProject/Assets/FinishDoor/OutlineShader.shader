Shader "Custom/DoorOutlineShader"
{
    Properties
    {
      
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutColor ("Ouline Color", Color) = (1,1,1,1)
        _Out ("Ouline width", Range(.0,0.1)) = .005
       
    }
    SubShader
    {
        ZWrite off //avoid being drawn in depth buffer
        //drawing outline
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert

        struct Input
        {
            float2 uv_MainTex;
        };

        float _Out;
        float4 _OutColor;

        //offseting vertices normal by outline width value 
        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal * _Out;
        }

        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o)
        {
            //drawing the outline in a color
            o.Emission = _OutColor.rgb;
        }
        ENDCG

        ZWrite on


        //rendering main texture 
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        //albedo to main texture 
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
      
    }
    FallBack "Diffuse"
}
