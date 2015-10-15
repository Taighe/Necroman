// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8984,x:33526,y:32687,varname:node_8984,prsc:2|emission-6954-OUT;n:type:ShaderForge.SFN_Time,id:4309,x:31280,y:32577,varname:node_4309,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2343,x:31746,y:32829,ptovrint:False,ptlb:u speed,ptin:_uspeed,varname:node_2343,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:5942,x:31746,y:32915,ptovrint:False,ptlb:v speed,ptin:_vspeed,varname:node_5942,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Add,id:531,x:32372,y:32678,varname:node_531,prsc:2|A-2421-UVOUT,B-9945-OUT;n:type:ShaderForge.SFN_TexCoord,id:2421,x:31898,y:32440,varname:node_2421,prsc:2,uv:0;n:type:ShaderForge.SFN_Append,id:4349,x:31966,y:32773,varname:node_4349,prsc:2|A-2343-OUT,B-5942-OUT;n:type:ShaderForge.SFN_Multiply,id:9945,x:32175,y:32708,varname:node_9945,prsc:2|A-4050-OUT,B-4349-OUT;n:type:ShaderForge.SFN_Tex2d,id:4439,x:33036,y:32703,ptovrint:False,ptlb:panning line,ptin:_panningline,varname:node_4439,prsc:2,tex:6e55cec41c692ed408555d81e0966fdd,ntxv:0,isnm:False|UVIN-3832-OUT;n:type:ShaderForge.SFN_Lerp,id:6954,x:33292,y:32667,varname:node_6954,prsc:2|A-4071-RGB,B-4439-RGB,T-5241-OUT;n:type:ShaderForge.SFN_Slider,id:5241,x:33135,y:32882,ptovrint:False,ptlb:Fade on/off,ptin:_Fadeonoff,varname:node_5241,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:4071,x:33025,y:32522,ptovrint:False,ptlb:color when faded out,ptin:_colorwhenfadedout,varname:node_4071,prsc:2,glob:False,c1:0.1058824,c2:0.1490196,c3:0.1960784,c4:1;n:type:ShaderForge.SFN_Vector2,id:5871,x:32372,y:32810,varname:node_5871,prsc:2,v1:1,v2:-1;n:type:ShaderForge.SFN_Multiply,id:3422,x:32605,y:32760,varname:node_3422,prsc:2|A-531-OUT,B-5871-OUT;n:type:ShaderForge.SFN_Lerp,id:3832,x:32831,y:32703,varname:node_3832,prsc:2|A-531-OUT,B-3422-OUT,T-313-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:313,x:32605,y:32911,ptovrint:False,ptlb:toggle direction,ptin:_toggledirection,varname:node_313,prsc:2,on:False;n:type:ShaderForge.SFN_Lerp,id:4050,x:31966,y:32614,varname:node_4050,prsc:2|A-4309-T,B-1754-OUT,T-446-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:446,x:31746,y:32746,ptovrint:False,ptlb:toggle smooth / blocky panning,ptin:_togglesmoothblockypanning,varname:node_446,prsc:2,on:False;n:type:ShaderForge.SFN_Posterize,id:1754,x:31554,y:32660,varname:node_1754,prsc:2|IN-4309-T,STPS-5905-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5905,x:31340,y:32764,ptovrint:False,ptlb:steps,ptin:_steps,varname:node_5905,prsc:2,glob:False,v1:5;proporder:2343-5942-4439-5241-4071-313-446-5905;pass:END;sub:END;*/

Shader "Shader Forge/spirit_tracks_shader" {
    Properties {
        _uspeed ("u speed", Float ) = 0
        _vspeed ("v speed", Float ) = 1
        _panningline ("panning line", 2D) = "white" {}
        _Fadeonoff ("Fade on/off", Range(0, 1)) = 0
        _colorwhenfadedout ("color when faded out", Color) = (0.1058824,0.1490196,0.1960784,1)
        [MaterialToggle] _toggledirection ("toggle direction", Float ) = 0
        [MaterialToggle] _togglesmoothblockypanning ("toggle smooth / blocky panning", Float ) = 0
        _steps ("steps", Float ) = 5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float _uspeed;
            uniform float _vspeed;
            uniform sampler2D _panningline; uniform float4 _panningline_ST;
            uniform float _Fadeonoff;
            uniform float4 _colorwhenfadedout;
            uniform fixed _toggledirection;
            uniform fixed _togglesmoothblockypanning;
            uniform float _steps;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD2;
                #else
                    float3 shLight : TEXCOORD2;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_4309 = _Time + _TimeEditor;
                float2 node_531 = (i.uv0+(lerp(node_4309.g,floor(node_4309.g * _steps) / (_steps - 1),_togglesmoothblockypanning)*float2(_uspeed,_vspeed)));
                float2 node_3832 = lerp(node_531,(node_531*float2(1,-1)),_toggledirection);
                float4 _panningline_var = tex2D(_panningline,TRANSFORM_TEX(node_3832, _panningline));
                float3 emissive = lerp(_colorwhenfadedout.rgb,_panningline_var.rgb,_Fadeonoff);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
