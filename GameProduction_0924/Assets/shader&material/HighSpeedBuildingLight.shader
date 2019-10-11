Shader "Unlit/HighSpeedBuildingLight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	_Speed("SPEED",Range(0,100))=20
		_Thick("THICK",Range(0,10)) = 2
		_Color("COLOR",Color)=(0.01,0.8,0.7,1.0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			float _Speed;
			float _Thick;
			float4 _Color;
            fixed4 frag (v2f i) : SV_Target
            {
				_Speed = 100-_Speed;
			_Thick = 10 - _Thick;
				//return half4(i.uv.x,0,0,1);
				half2 cen = half2((_Time.y*10.0/_Speed) % 1,i.uv.y);
				float len = length(i.uv-cen)*_Thick;
				return half4(_Color.x,_Color.y*(0.05/len), _Color.z*(0.1 / len), _Color.w);
            }
            ENDCG
        }
    }
}
