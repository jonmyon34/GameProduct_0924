Shader "Unlit/CyberBugNoise"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Alpha("Alpha",Range(0,5)) = 1
		_Grid("Grid",Range(10,10000))=10
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100

		cull off
		Blend SrcAlpha OneMinusSrcAlpha

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
			float _Alpha;
			float _Grid;

			float random(fixed2 p)
			{
            	return frac(sin(dot(p, fixed2(12.9898,78.233))) * 43758.5453);
			}

			float pattern(fixed2 p,fixed2 v, float t)
			{
				fixed2 _P = floor(p+v);
				return step(t,random(100.0f + p * 0.000001) + random(_P.x)*0.5f);
			}
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 grid = float2(_Grid,25.0f);
				i.uv *= grid;

				float2 ipos = floor(i.uv);
				float2 fpos = frac(i.uv);

				float2 vel = float2(_Time.w * max(grid.x,grid.y) * 2.0f,_Time.w * max(grid.x,grid.y) * 2.0f);
				//vel *= float2(-1.0f,0.0f) * random(1.0f + ipos.y);
				vel.x *= -1.0f * random(1.0f + ipos.y);
				vel.y *= 0.0f;

				float2 offset = float2(0.1f,0.0f);

				float3 col;
				col.r = pattern(i.uv + offset,vel,0.5f);
				col.g = pattern(i.uv,vel,0.5f);
				col.b = pattern(i.uv-offset,vel,0.5f);

				col *= step(0.2,fpos.y);

				float4 c = float4(1.0f-col.r,1.0f-col.g,1.0f-col.b,1.0f);

				if(c.r<1.0f || c.g < 1.0f || c.b < 1.0f)
				{
					float r = 0.52734f;
					float g = 0.80468f;
					float b = 0.91796f;
					b=0.2f;

					r += (random(i.uv) - 0.5f) * 0.1f;
					b += (random(i.uv)) * 0.8f;
					g = 1.0f;
					g += (random(i.uv) - 1.0f) * 0.05f;

					c = float4(r,g,b,_Alpha);
					//c.w = saturate(c.w);
				}
				else
				{
					c.w = min(0.232f,_Alpha);
				}

				return c;
			}

			ENDCG
		}
	}
}
