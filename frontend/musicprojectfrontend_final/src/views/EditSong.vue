<template>
<div class="h-screen">
<Header title="UP"></Header>
<div class="flex justify-between mt-4">
    <p class=" w-full text-left pl-8 text-2xl font-bold text-white">{{state.songname}}</p>
    <div class="flex mr-8 hidden">
        <div  class="bg-blue mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>Play</div>
        </div>
        <div class="bg-yellow mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>notes</div>
        </div>
        <div  class="bg-pinkLight mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>Save</div>
        </div>
    </div>
</div>
<div class="mx-8 mt-6">
    <p class="text-left text-white text-lg">original</p>
</div>
<div class="mx-8 mt-4">
        <audio controls="controls" ref="song" class="w-5/6">
        </audio>
    </div>
<div class="mx-8 mt-6 hidden">
    <p class="text-left text-white text-lg">crop</p>
</div>
<div class="flex hidden">
    <div class="flex flex-col text-left mx-8 w-16">
        <label class="text-white" for="start">start</label>
        <input class="pl-2" v-model="start" id="start" type="number">
    </div>
    <div  class="flex flex-col text-left  w-16">
        <label class="text-white" for="end">end</label>
        <input class="pl-2" v-model="end" id="end" type="number">
    </div>
    <div  class="flex flex-col justify-center items-center ">
        <button @click="cropSong" class="h-8 bg-blue rounded-2xl mx-4 w-16 hover:opacity-70 text-white">crop</button>
    </div>
</div> 
<div class="mx-8 mt-6">
    <p class="text-left text-white text-lg">filter</p>
</div>
<div class="flex items-center">
        <select v-model="state.effect" class="mx-8 h-8" name="filter" id="filter">
            <option value="">choose your filter</option>
            <option value="Distortion">Distortion</option>
            <option value="AutoFilter">AutoFilter</option>
            <option value="AutoPanner">AutoPanner</option>
            <option value="reverb">reverb</option>
        </select>
        <div class="flex flex-col text-left  w-16">
            <label class="text-white" for="niveau">niveau</label>
            <input class="pl-2" v-model="state.niveau" id="niveau" type="number">
        </div> 
        <div  class="flex flex-col justify-center items-center ">
            <button @click="playFiltered" class="h-8 bg-blue rounded-2xl mx-4 w-auto px-2 hover:opacity-70 text-white">play/stop filtered</button>
        </div>
</div>
</div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import axios from 'axios';
import Header from '../components/Header.vue';
import { stringifyQuery } from 'vue-router';
import * as Tone from 'tone';


export default defineComponent({
    components:{
    Header
},
setup(){
        const state = reactive({
            songname:"",
            song: "[]",
            niveau:0,
            effect: ""
            
        });
        return{
        state,
        start:0,
        end:0,
        isPlaying:false,
        player: new Tone.Player()
        }
    },
methods:{
    cropSong(){
    //     MP3Cutter.cut({
    //     src: `../assets/test.mp3`,
    //     target: this.state.songname,
    //     start: this.start,
    //     end: this.end 
    // });
    console.log("done");
    },
    async playFiltered(){        
        this.player = new Tone.Player({
            url: `http://music01bronze.westeurope.cloudapp.azure.com:9000/api/blob/${this.state.songname}`,
            loop: false,
            autostart: false,
        })
        if(!this.isPlaying)
        {
            var body = {
                UserId: localStorage.getItem("userId"),
                Name: this.state.effect,
                Level: +this.state.niveau
            }
            let response = await axios.post(`Blob/addfilter/${localStorage.getItem("songName")}`,body)
            console.log(response);
            this.isPlaying =true;
            let distortion;
            //create a distortion effect
            if(this.state.effect == "Distortion")
            {
            distortion = new Tone.Distortion(this.state.niveau).toDestination();
            }
            if(this.state.effect == "AutoFilter")
            {
            distortion = new Tone.AutoFilter(this.state.niveau).toDestination();
            }
            if(this.state.effect == "AutoPanner")
            {
            distortion = new Tone.AutoPanner(this.state.niveau).toDestination();
            }
            if(this.state.effect == "reverb")
            {
            distortion = new Tone.Reverb(this.state.niveau).toDestination();;
            }
            //connect a player to the distortion
            console.log(this.player);
            //@ts-ignore
            this.player.connect(distortion);
            Tone.loaded().then(() => {
	            this.player.start();
            });
        }
        else{
            console.log("test")
            window.location.reload();

        }
       
    },
},
async created(){
    //@ts-ignore
    this.state.songname = localStorage.getItem("songName");
    let response = await axios.get(`Blob/onesong/${localStorage.getItem("userId")}/${localStorage.getItem("songName")}`)
    console.log(response.data.filters.level);
    this.state.niveau = response.data.filters.level;
    this.state.effect = response.data.filters.name;

    //@ts-ignore
    
    },
    mounted(){
        //@ts-ignore
        this.$refs.song.innerHTML = `<source src="http://music01bronze.westeurope.cloudapp.azure.com:9000/api/blob/${this.state.songname}" type="audio/mp3">`
    }

});
</script>

