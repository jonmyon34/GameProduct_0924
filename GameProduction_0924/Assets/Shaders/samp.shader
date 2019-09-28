Shader "Custom/samp"
{
	Properties
	{
		_BaseColor("Base Color", Color) = (1,1,1,1)//;つけちゃだめ
		_Alpha("Alpha",Range(0,1)) = 1.0
    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }
		Tags{ "Queue" = "Transparent" }//Queueは描画の優先順位
		LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade//fade指定で半透明

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

			fixed4 _BaseColor;
			float _Alpha;
			void surf(Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = _BaseColor.rgb;
			o.Alpha = _Alpha;
		}
        ENDCG
    }
    FallBack "Diffuse"
}
