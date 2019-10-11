Shader "Unlit/yabai"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

			float random(in float2 _st) {
				return frac(sin(dot(_st.xy, float2(12.9898, 78.233)))*43758.5453123);
			}

			//フラクタルノイズの使い方講座
			float noise(in float2 _st) {
				float2 i = floor(_st);
				float2 f = frac(_st);

				//ランダムな位置から右上方向に3点(計4点)を作る
				float a = random(i);
				float b = random(i + float2(1.0, 0.0));
				float c = random(i + float2(0.0, 1.0));
				float d = random(i + float2(1.0, 1.0));

				//は？
				float2 u = f * f * (3.0 - 2.0 * f);

				//は?
				return lerp(a, b, u.x) + (c - a)* u.y * (1.0 - u.x) + (d - b) * u.x * u.y;
			}

#define NUM_OCTAVES 5

			float fbm(in float2 _st) {
				float y = 0.0;
				float amplitude = 0.5;//振幅
				float2 shift = float2(100.0, 100.0);

				// Rotate to reduce axial bias//axial:軸
				float2x2 rot = float2x2(cos(0.5), sin(0.5), -sin(0.5), cos(0.50));

				// フラクタルノイズを作るためのループ//https://thebookofshaders.com/13/?lan=jp
				for (int i = 0; i < NUM_OCTAVES; ++i) {//ループ増えるほどノイズが増える
					y += amplitude * noise(_st);//amplitude:振幅
					_st = mul(rot, _st) * 2.0 + shift;//frequency:頻度
					amplitude *= 0.5;//0.5はgain
				}
				return y;
			}

			
            fixed4 frag (v2f i) : SV_Target
            {
				//3倍にスケールを上げる
				float2 st = i.uv * 3;
				// st += st * abs(sin(Time.x*0.1)*3.0);
				float3 color = float3(0.0,0.0,0.0);

				float2 q = float2(0.0,0.0);
				q.x = fbm(st + 0.00*_Time.y);
				q.y = fbm(st + float2(1.0,1.0));

				float2 r = float2(0.,0.0);
				r.x = fbm(st + 1.0*q + float2(1.7, 9.2) + 0.15*_Time.y);
				r.y = fbm(st + 1.0*q + float2(8.3, 2.8) + 0.126*_Time.y);

				float f = fbm(st + r);

				color = lerp(float3(0.101961, 0.619608, 0.666667),float3(0.666667, 0.666667, 0.498039),clamp((f*f)*4.0, 0.0, 1.0));

				color = lerp(color,float3(0, 0, 0.164706),clamp(length(q), 0.0, 1.0));

				color = lerp(color,float3(0.666667, 1, 1),clamp(length(r.x), 0.0, 1.0));

				color= float4((f*f*f + .6*f*f + .5*f)*color, 1.);
     
                return float4(color,1.0f);
            }
            ENDCG
        }
    }
}
