Shader "Unlit/test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	    _Color("COLOR",color)=(0.1,0.8,0.7,1)
		_EdgeColor("EDGE_COLOR",color)=(0.1,0.8,0.8,1)
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
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
				float4 albedo : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			fixed4 _Color;
			fixed4 Edge_Color;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.albedo = _Color;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }


			fixed4 frag(v2f i) : SV_Target
			{
				//x座標の両端0.1でグラデーション0~1
				float edgex1 = smoothstep(0,0.05,i.uv.x);
				float edgex2 = smoothstep(0.95, 1.0, i.uv.x);
				float edgex = edgex1 - edgex2;

				//y座標の両端0.1でグラデーション0~1
				float edgey1 = smoothstep(0, 0.05, i.uv.y);
				float edgey2 = smoothstep(0.95, 1.0, i.uv.y);
				float edgey = edgey1 - edgey2;

				//明るいところは1*1それ以外は1*(0~1)になる
				half edge = edgex*edgey;

				float2 cen = (i.uv.x,sin(_Time.z/2)%1);
				float len = length(i.uv-cen);
				half4 edgecol = half4(edge, edge, edge, 1);
				if (edge < 1)
				{
					//edgecol.x += Edge_Color.x*(0.1 / len);
					//edgecol.y += Edge_Color.y*(0.1 / len);
					//edgecol.z += Edge_Color.z*(0.1 / len);

					edgecol.x += 0.1*(0.1 / len);
					edgecol.y += 0.8*(0.1 / len);
					edgecol.z += 0.8*(0.1 / len);
				}
				else
					edgecol*=i.albedo;

                return edgecol;
            }
            ENDCG
        }
    }
}
