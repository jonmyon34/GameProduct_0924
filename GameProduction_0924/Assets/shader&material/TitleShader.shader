Shader "Unlit/TitleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	_Color("COLOR",Color) = (1,1,1,1)
		_Speed("SPEED",Range(0,1))=0.1

		_Alpha("Alpha",Range(0,1)) = 1
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

			fixed4 _Color;
			float _Speed;
			float _Alpha;

			fixed4 frag(v2f i) : SV_Target
			{
					float Lx = 1.0;
				float Ly = 1.0;

				float m0 = 5.0;
				float n0 = 2.0;

				float sens = 0.05;
				//float vel = 0.1;

				float pi = 3.14159265359;

					half2 pos = ((i.uv/0.5) *half2(Lx,Ly));
					//pos.x *= i.uv.x/i.uv.y;
					//pos.y *= i.uv.x / i.uv.y;


					float n = n0;	// + (_Time.w * vel);
					float m = m0 *sin((_Time.w*_Speed));


					float z = cos(n * pi * pos.x / Lx) * cos(m * pi * pos.y / Ly) + cos(n * pi * pos.y / Ly) * cos(m * pi * pos.x / Lx);
					float dist = abs(z)*(1.0 / sens);
					return half4(_Color.x / dist, _Color.y / dist, _Color.z / dist, _Alpha);

			
					//return half4(i.uv.x,0,0, 1.0);uv確認用
            }
            ENDCG
        }
    }
}
