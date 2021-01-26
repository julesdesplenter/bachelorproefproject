<template>
<div class="bg-headerGray h-16 flex justify-between">
    <div class="flex items-center">
        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" viewBox="0 0 86 86">
        <g id="Group_4" data-name="Group 4" transform="translate(-2663 -2936)">
            <path id="Path_1" data-name="Path 1" d="M0,0H86V86H0Z" transform="translate(2663 2936)" fill="#ffd163"/>
            <circle id="Ellipse_1" data-name="Ellipse 1" cx="26.5" cy="26.5" r="26.5" transform="translate(2679 2953)" fill="#4d4d4d"/>
            <circle id="Ellipse_2" data-name="Ellipse 2" cx="9.325" cy="9.325" r="9.325" transform="translate(2696.675 2969.675)" fill="#3f96f2"/>
            <circle id="Ellipse_3" data-name="Ellipse 3" cx="2.072" cy="2.072" r="2.072" transform="translate(2703.928 2976.928)" fill="#ffc5d5"/>
        </g>
        </svg>
        <router-link id="SM" class="mx-4 text-white changeBold hover:opacity-70" to="/SM">self-made music</router-link>
        <router-link id="UP" class="mx-4 text-white changeBold hover:opacity-70" to="/UP">edited music</router-link>
    </div>
    <div class="flex mx-8 items-center">
        <div class="bg-pinkLight mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <router-link to="/NewSong">Make new Song</router-link>
        </div>
        <div class="bg-blue mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <router-link to="/UploadSong">Upload New Song</router-link>
        </div>
        <div class="bg-yellow mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <router-link to="/">logout</router-link>
        </div>
        

    </div>
    

</div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import axios from 'axios';

export default defineComponent({
    props:{
        title:String
    }
    ,data(){
       return{
           SM:"",
           UP:""
       }

    },
    methods:{
         
    },
    mounted(){
        if(this.title == "SM"){
            //@ts-ignore
            document.getElementById("SM").classList.add("font-bold");
            
        }else  if(this.title == "UP"){
            //@ts-ignore
            document.getElementById("UP").classList.add("font-bold");
        }
        console.log("done");
    }
        
    });
</script>
