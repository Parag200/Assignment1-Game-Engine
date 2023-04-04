Shader "Custom/DecalShader"
{
    Properties
    {
      //inputs for main and decal 
        _MainTex ("Main", 2D) = "white" {}
        _DecalTex ("Decal", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
      

        CGPROGRAM
       
        #pragma surface surf Lambert

     
        //declaring main and decal inputs 
        sampler2D _MainTex;
        sampler2D _DecalTex;


        struct Input
        {
            float2 uv_MainTex;
        };

       
        //
        void surf (Input IN, inout SurfaceOutput o)
        {
            //both main and decal texture being used 
            fixed4 a = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 b = tex2D(_DecalTex, IN.uv_MainTex);

            //if maintex red channel above 0.9, show instead of main texture
            o.Albedo = b.r > 0.9 ? b.rgb : a.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
