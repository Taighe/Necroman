// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4548,x:33653,y:32684,varname:node_4548,prsc:2|emission-1048-OUT,clip-8215-A;n:type:ShaderForge.SFN_Tex2d,id:3978,x:32783,y:32848,varname:node_3978,prsc:2,tex:e7a3df12a1f5c064d81a11bfbd603e9c,ntxv:0,isnm:False|UVIN-8518-OUT,TEX-7585-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7585,x:32559,y:32946,ptovrint:False,ptlb:pixelated clouds,ptin:_pixelatedclouds,varname:node_7585,tex:e7a3df12a1f5c064d81a11bfbd603e9c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:2411,x:32783,y:32620,ptovrint:False,ptlb:Rune_colour,ptin:_Rune_colour,varname:node_2411,prsc:2,glob:False,c1:0.07586217,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Time,id:1488,x:31916,y:32591,varname:node_1488,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8633,x:31916,y:32878,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_8633,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:5113,x:31916,y:32952,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_5113,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Append,id:2542,x:32120,y:32908,varname:node_2542,prsc:2|A-8633-OUT,B-5113-OUT;n:type:ShaderForge.SFN_Multiply,id:6901,x:32357,y:32860,varname:node_6901,prsc:2|A-3896-OUT,B-2542-OUT;n:type:ShaderForge.SFN_TexCoord,id:9234,x:32357,y:32717,varname:node_9234,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:8518,x:32558,y:32795,varname:node_8518,prsc:2|A-9234-UVOUT,B-6901-OUT;n:type:ShaderForge.SFN_Multiply,id:7575,x:33270,y:32799,varname:node_7575,prsc:2|A-2411-RGB,B-216-OUT,C-2649-OUT;n:type:ShaderForge.SFN_Posterize,id:3896,x:32151,y:32742,varname:node_3896,prsc:2|IN-1488-T,STPS-6461-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6461,x:31582,y:32993,ptovrint:False,ptlb:Steps,ptin:_Steps,varname:node_6461,prsc:2,glob:False,v1:6;n:type:ShaderForge.SFN_Add,id:8718,x:32559,y:33155,varname:node_8718,prsc:2|A-6378-UVOUT,B-500-OUT;n:type:ShaderForge.SFN_TexCoord,id:6378,x:32348,y:33155,varname:node_6378,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:500,x:32348,y:33298,varname:node_500,prsc:2|A-3442-OUT,B-7372-OUT;n:type:ShaderForge.SFN_Posterize,id:3442,x:32142,y:33180,varname:node_3442,prsc:2|IN-8177-T,STPS-6461-OUT;n:type:ShaderForge.SFN_Append,id:7372,x:32111,y:33346,varname:node_7372,prsc:2|A-1705-OUT,B-8882-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8882,x:31907,y:33390,ptovrint:False,ptlb:V Speed_copy,ptin:_VSpeed_copy,varname:_VSpeed_copy,prsc:2,glob:False,v1:-0.5;n:type:ShaderForge.SFN_ValueProperty,id:1705,x:31907,y:33316,ptovrint:False,ptlb:U Speed_copy,ptin:_USpeed_copy,varname:_USpeed_copy,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Time,id:8177,x:31907,y:33029,varname:node_8177,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:9903,x:32783,y:33049,varname:node_9903,prsc:2,tex:e7a3df12a1f5c064d81a11bfbd603e9c,ntxv:0,isnm:False|UVIN-8718-OUT,TEX-7585-TEX;n:type:ShaderForge.SFN_Tex2d,id:8215,x:33269,y:33069,ptovrint:False,ptlb:Runes,ptin:_Runes,varname:node_8215,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:216,x:33002,y:32862,varname:node_216,prsc:2|A-3978-RGB,B-3741-OUT;n:type:ShaderForge.SFN_Add,id:2649,x:33002,y:33019,varname:node_2649,prsc:2|A-3741-OUT,B-9903-RGB;n:type:ShaderForge.SFN_ValueProperty,id:3741,x:32783,y:32997,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_3741,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:1048,x:33483,y:32784,varname:node_1048,prsc:2|A-6519-OUT,B-7575-OUT,T-7734-OUT;n:type:ShaderForge.SFN_Vector3,id:6519,x:33269,y:32709,varname:node_6519,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Slider,id:7734,x:33211,y:32970,ptovrint:False,ptlb:Fade_off,ptin:_Fade_off,varname:node_7734,prsc:2,min:0,cur:0,max:1;proporder:7585-8215-2411-8633-5113-6461-8882-1705-3741-7734;pass:END;sub:END;*/

Shader "Shader Forge/Runes_shader_02" {
    Properties {
        _pixelatedclouds ("pixelated clouds", 2D) = "white" {}
        _Runes ("Runes", 2D) = "white" {}
        _Rune_colour ("Rune_colour", Color) = (0.07586217,1,0,1)
        _USpeed ("U Speed", Float ) = 0
        _VSpeed ("V Speed", Float ) = 0.5
        _Steps ("Steps", Float ) = 6
        _VSpeed_copy ("V Speed_copy", Float ) = -0.5
        _USpeed_copy ("U Speed_copy", Float ) = 0.5
        _Brightness ("Brightness", Float ) = 0
        _Fade_off ("Fade_off", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _pixelatedclouds; uniform float4 _pixelatedclouds_ST;
            uniform float4 _Rune_colour;
            uniform float _USpeed;
            uniform float _VSpeed;
            uniform float _Steps;
            uniform float _VSpeed_copy;
            uniform float _USpeed_copy;
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            uniform float _Brightness;
            uniform float _Fade_off;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
////// Lighting:
////// Emissive:
                float4 node_1488 = _Time + _TimeEditor;
                float2 node_8518 = (i.uv0+(floor(node_1488.g * _Steps) / (_Steps - 1)*float2(_USpeed,_VSpeed)));
                float4 node_3978 = tex2D(_pixelatedclouds,TRANSFORM_TEX(node_8518, _pixelatedclouds));
                float4 node_8177 = _Time + _TimeEditor;
                float2 node_8718 = (i.uv0+(floor(node_8177.g * _Steps) / (_Steps - 1)*float2(_USpeed_copy,_VSpeed_copy)));
                float4 node_9903 = tex2D(_pixelatedclouds,TRANSFORM_TEX(node_8718, _pixelatedclouds));
                float3 node_7575 = (_Rune_colour.rgb*(node_3978.rgb+_Brightness)*(_Brightness+node_9903.rgb));
                float3 emissive = lerp(float3(0,0,0),node_7575,_Fade_off);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                float4 screenPos : TEXCOORD6;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD7;
                #else
                    float3 shLight : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
