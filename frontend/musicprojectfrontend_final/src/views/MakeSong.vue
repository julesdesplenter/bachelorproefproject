<template>
<div class="h-screen">
<Header title="SM"></Header>
<div class="flex justify-between mt-4">
    <p class=" w-full text-left pl-8 text-2xl font-bold text-white">{{state.data.name}}({{state.data.instruments[0].name}})</p>
    <div class="flex mr-8">
        <div @click="playSong" class="bg-blue mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>Play</div>
        </div>
        <div @click="toggleLength" class="bg-yellow mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>Length</div>
        </div>
        <div @click="saveMessage" class="bg-pinkLight mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70">
            <div>Save</div>
        </div>
    </div>
</div>
<div class="flex">
    <div class="mt-8 ">
        <div class="w-16 h-7 bg-white border-2 border-black">si</div>
        <div class="w-16 h-7 bg-white border-2 border-black">la</div>
        <div class="w-16 h-7 bg-white border-2 border-black">sol</div>
        <div class="w-16 h-7 bg-white border-2 border-black">fa</div>
        <div class="w-16 h-7 bg-white border-2 border-black">mi</div>
        <div class="w-16 h-7 bg-white border-2 border-black">re</div>
        <div class="w-16 h-7 bg-white border-2 border-black">do</div>
        <div class="w-16 h-7 bg-white border-2 border-black">si</div>
        <div class="w-16 h-7 bg-white border-2 border-black">la</div>
        <div class="w-16 h-7 bg-white border-2 border-black">sol</div>
        <div class="w-16 h-7 bg-white border-2 border-black">fa</div>
        <div class="w-16 h-7 bg-white border-2 border-black">mi</div>
        <div class="w-16 h-7 bg-white border-2 border-black">re</div>
        <div class="w-16 h-7 bg-white border-2 border-black">do</div>
    </div>
    <div class=" ml-4 overflow-x-scroll">
        <div ref="length" class="h-8 w-2 flex py-2 lengthRow opacity-0">
        </div>
        
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
        <d class="flex noterow"></d>
    </div>
    <!-- <div ref="grid" class="mt-8 ml-4 grid grid-rows-14 w-full noterow"> -->
        
    </div>
    <div v-show="state.save">
        <div class="absolute top-0 left-0 right-0 bottom-0 bg-black bg-opacity-70 flex justify-center items-center">
            <div class="bg-white w-1/3 h-1/3 opacity-100 flex justify-center items-center flex-col">
                <p class="text-3xl">saved!</p>
                <p class="mt-4">Good to know: your song saves automatically so you don't really need to use the save butten.</p>
                <div @click="goneSave" class="mt-4 bg-yellow flex justify-center items-center w-1/5 h-8 cursor-pointer hover:opacity-70">
                    <p class="text-white">continue</p>
                </div>

            </div>
        </div>
    </div>

</div>
</template>

<script lang="ts">
import { defineComponent, reactive, resolveComponent, ref, onMounted } from 'vue';
import axios from 'axios';
import Header from '../components/Header.vue';
import * as Tone from 'tone';
import sleep from 'sleep-promise';
let dict = {1:"C3",2:"D3",3:"E3",4:"F3",5:"G3",6:"A3",7:"B3",8:"C4",9:"D4",10:"E4",11:"F4",12:"G4",13:"A4",14:"B4"};
var isPlaying = false;

export default defineComponent({
    components:{
    Header
},
methods:{   
    async playSong(){
        if(isPlaying == false)
        {
            //@ts-ignore
            let sampler,sampler2,sampler3;
            isPlaying = true;
            var notes = await axios.get(`SMSong/onesong/${localStorage.getItem("userId")}/${localStorage.getItem("songName")}`)
            let positions = notes.data.instruments[0].positions;
            
            //@ts-ignore
            if(this.state.data.instruments[0].name == "guitar")
            {
                sampler = new Tone.Sampler({
                urls: {
                    "c3": "c3.mp3",
                    "d3": "d3.mp3",
                    "e3": "e3.mp3",
                    "f3": "f3.mp3",
                    "g3": "g3.mp3",
                    "a3": "a3.mp3",
                    "b3": "b3.mp3",
                    "c4": "c4.mp3",
                    "d4": "d4.mp3",
                    "e4": "e4.mp3",
                    "f4": "f4.mp3",
                    "g4": "g4.mp3",
                    "a4": "a4.mp3",
                    "b4": "b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler2 = new Tone.Sampler({
                urls: {
                    "c3": "c3.mp3",
                    "d3": "d3.mp3",
                    "e3": "e3.mp3",
                    "f3": "f3.mp3",
                    "g3": "g3.mp3",
                    "a3": "a3.mp3",
                    "b3": "b3.mp3",
                    "c4": "c4.mp3",
                    "d4": "d4.mp3",
                    "e4": "e4.mp3",
                    "f4": "f4.mp3",
                    "g4": "g4.mp3",
                    "a4": "a4.mp3",
                    "b4": "b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler3 = new Tone.Sampler({
                urls: {
                    "c3": "c3.mp3",
                    "d3": "d3.mp3",
                    "e3": "e3.mp3",
                    "f3": "f3.mp3",
                    "g3": "g3.mp3",
                    "a3": "a3.mp3",
                    "b3": "b3.mp3",
                    "c4": "c4.mp3",
                    "d4": "d4.mp3",
                    "e4": "e4.mp3",
                    "f4": "f4.mp3",
                    "g4": "g4.mp3",
                    "a4": "a4.mp3",
                    "b4": "b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                            //@ts-ignore

                console.log(this.state.data.instruments[0].name);
               
            }
            //@ts-ignore
            else if(this.state.data.instruments[0].name == "drum")
            {
                sampler = new Tone.Sampler({
                urls: {
                    "c3": "drum_c3.mp3",
                    "d3": "drum_d3.mp3",
                    "e3": "drum_e3.mp3",
                    "f3": "drum_f3.mp3",
                    "g3": "drum_g3.mp3",
                    "a3": "drum_a3.mp3",
                    "b3": "drum_b3.mp3",
                    "c4": "drum_c4.mp3",
                    "d4": "drum_d4.mp3",
                    "e4": "drum_e4.mp3",
                    "f4": "drum_f4.mp3",
                    "g4": "drum_g4.mp3",
                    "a4": "drum_a4.mp3",
                    "b4": "drum_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler2 = new Tone.Sampler({
                urls: {
                    "c3": "drum_c3.mp3",
                    "d3": "drum_d3.mp3",
                    "e3": "drum_e3.mp3",
                    "f3": "drum_f3.mp3",
                    "g3": "drum_g3.mp3",
                    "a3": "drum_a3.mp3",
                    "b3": "drum_b3.mp3",
                    "c4": "drum_c4.mp3",
                    "d4": "drum_d4.mp3",
                    "e4": "drum_e4.mp3",
                    "f4": "drum_f4.mp3",
                    "g4": "drum_g4.mp3",
                    "a4": "drum_a4.mp3",
                    "b4": "drum_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler3 = new Tone.Sampler({
                urls: {
                    "c3": "drum_c3.mp3",
                    "d3": "drum_d3.mp3",
                    "e3": "drum_e3.mp3",
                    "f3": "drum_f3.mp3",
                    "g3": "drum_g3.mp3",
                    "a3": "drum_a3.mp3",
                    "b3": "drum_b3.mp3",
                    "c4": "drum_c4.mp3",
                    "d4": "drum_d4.mp3",
                    "e4": "drum_e4.mp3",
                    "f4": "drum_f4.mp3",
                    "g4": "drum_g4.mp3",
                    "a4": "drum_a4.mp3",
                    "b4": "drum_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
               
            }
             //@ts-ignore
            else if(this.state.data.instruments[0].name == "violin")
            {
                sampler = new Tone.Sampler({
                urls: {
                    "c3": "violin_c3.mp3",
                    "d3": "violin_d3.mp3",
                    "e3": "violin_e3.mp3",
                    "f3": "violin_f3.mp3",
                    "g3": "violin_g3.mp3",
                    "a3": "violin_a3.mp3",
                    "b3": "violin_b3.mp3",
                    "c4": "violin_c4.mp3",
                    "d4": "violin_d4.mp3",
                    "e4": "violin_e4.mp3",
                    "f4": "violin_f4.mp3",
                    "g4": "violin_g4.mp3",
                    "a4": "violin_a4.mp3",
                    "b4": "violin_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler2 = new Tone.Sampler({
                urls: {
                    "c3": "violin_c3.mp3",
                    "d3": "violin_d3.mp3",
                    "e3": "violin_e3.mp3",
                    "f3": "violin_f3.mp3",
                    "g3": "violin_g3.mp3",
                    "a3": "violin_a3.mp3",
                    "b3": "violin_b3.mp3",
                    "c4": "violin_c4.mp3",
                    "d4": "violin_d4.mp3",
                    "e4": "violin_e4.mp3",
                    "f4": "violin_f4.mp3",
                    "g4": "violin_g4.mp3",
                    "a4": "violin_a4.mp3",
                    "b4": "violin_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler3 = new Tone.Sampler({
                urls: {
                    "c3": "violin_c3.mp3",
                    "d3": "violin_d3.mp3",
                    "e3": "violin_e3.mp3",
                    "f3": "violin_f3.mp3",
                    "g3": "violin_g3.mp3",
                    "a3": "violin_a3.mp3",
                    "b3": "violin_b3.mp3",
                    "c4": "violin_c4.mp3",
                    "d4": "violin_d4.mp3",
                    "e4": "violin_e4.mp3",
                    "f4": "violin_f4.mp3",
                    "g4": "violin_g4.mp3",
                    "a4": "violin_a4.mp3",
                    "b4": "violin_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
               
            }
             //@ts-ignore
            else if(this.state.data.instruments[0].name == "piano")
            {
                sampler = new Tone.Sampler({
                urls: {
                    "c3": "piano_c3.mp3",
                    "d3": "piano_d3.mp3",
                    "e3": "piano_e3.mp3",
                    "f3": "piano_f3.mp3",
                    "g3": "piano_g3.mp3",
                    "a3": "piano_a3.mp3",
                    "b3": "piano_b3.mp3",
                    "c4": "piano_c4.mp3",
                    "d4": "piano_d4.mp3",
                    "e4": "piano_e4.mp3",
                    "f4": "piano_f4.mp3",
                    "g4": "piano_g4.mp3",
                    "a4": "piano_a4.mp3",
                    "b4": "piano_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler2 = new Tone.Sampler({
                urls: {
                    "c3": "piano_c3.mp3",
                    "d3": "piano_d3.mp3",
                    "e3": "piano_e3.mp3",
                    "f3": "piano_f3.mp3",
                    "g3": "piano_g3.mp3",
                    "a3": "piano_a3.mp3",
                    "b3": "piano_b3.mp3",
                    "c4": "piano_c4.mp3",
                    "d4": "piano_d4.mp3",
                    "e4": "piano_e4.mp3",
                    "f4": "piano_f4.mp3",
                    "g4": "piano_g4.mp3",
                    "a4": "piano_a4.mp3",
                    "b4": "piano_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler3 = new Tone.Sampler({
                urls: {
                    "c3": "piano_c3.mp3",
                    "d3": "piano_d3.mp3",
                    "e3": "piano_e3.mp3",
                    "f3": "piano_f3.mp3",
                    "g3": "piano_g3.mp3",
                    "a3": "piano_a3.mp3",
                    "b3": "piano_b3.mp3",
                    "c4": "piano_c4.mp3",
                    "d4": "piano_d4.mp3",
                    "e4": "piano_e4.mp3",
                    "f4": "piano_f4.mp3",
                    "g4": "piano_g4.mp3",
                    "a4": "piano_a4.mp3",
                    "b4": "piano_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
               
            }
             //@ts-ignore
            else if(this.state.data.instruments[0].name == "trumpet")
            {
                sampler = new Tone.Sampler({
                urls: {
                    "c3": "trumpet_c3.mp3",
                    "d3": "trumpet_d3.mp3",
                    "e3": "trumpet_e3.mp3",
                    "f3": "trumpet_f3.mp3",
                    "g3": "trumpet_g3.mp3",
                    "a3": "trumpet_a3.mp3",
                    "b3": "trumpet_b3.mp3",
                    "c4": "trumpet_c4.mp3",
                    "d4": "trumpet_d4.mp3",
                    "e4": "trumpet_e4.mp3",
                    "f4": "trumpet_f4.mp3",
                    "g4": "trumpet_g4.mp3",
                    "a4": "trumpet_a4.mp3",
                    "b4": "trumpet_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler2 = new Tone.Sampler({
                urls: {
                    "c3": "trumpet_c3.mp3",
                    "d3": "trumpet_d3.mp3",
                    "e3": "trumpet_e3.mp3",
                    "f3": "trumpet_f3.mp3",
                    "g3": "trumpet_g3.mp3",
                    "a3": "trumpet_a3.mp3",
                    "b3": "trumpet_b3.mp3",
                    "c4": "trumpet_c4.mp3",
                    "d4": "trumpet_d4.mp3",
                    "e4": "trumpet_e4.mp3",
                    "f4": "trumpet_f4.mp3",
                    "g4": "trumpet_g4.mp3",
                    "a4": "trumpet_a4.mp3",
                    "b4": "trumpet_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
                sampler3 = new Tone.Sampler({
                urls: {
                    "c3": "trumpet_c3.mp3",
                    "d3": "trumpet_d3.mp3",
                    "e3": "trumpet_e3.mp3",
                    "f3": "trumpet_f3.mp3",
                    "g3": "trumpet_g3.mp3",
                    "a3": "trumpet_a3.mp3",
                    "b3": "trumpet_b3.mp3",
                    "c4": "trumpet_c4.mp3",
                    "d4": "trumpet_d4.mp3",
                    "e4": "trumpet_e4.mp3",
                    "f4": "trumpet_f4.mp3",
                    "g4": "trumpet_g4.mp3",
                    "a4": "trumpet_a4.mp3",
                    "b4": "trumpet_b4.mp3"
                },
                release: 1,
                baseUrl: "http://music01bronze.westeurope.cloudapp.azure.com:9000/api/Blob/",
                }).toDestination();
               
            }
            else
            {
                sampler = new Tone.Synth().toDestination();
                sampler2 = new Tone.Synth().toDestination();
                sampler3 = new Tone.Synth().toDestination();
            }
             for(let position of positions)
                {
                    let array: string[] = []
                    for(let note of position.tones)
                    {
                        if(note.pitch == null)
                        {
                            break;
                        }
                        array.push(note.pitch);
                    }
                    if(array[0] == undefined)
                    {
                        break;
                    }
                    await Tone.loaded().then(() => {       
                        //@ts-ignore               
                        sampler.triggerAttackRelease(array[0],0.5);
                        //@ts-ignore
                         document.getElementById(`${array[0]}/${position.place}`).classList.add("bg-active");
                    })
                    if(array[1] != undefined)
                    {
                        Tone.loaded().then(() => {       
                        //@ts-ignore               
                        sampler2.triggerAttackRelease(array[1],"8n");
                        //@ts-ignore
                         document.getElementById(`${array[1]}/${position.place}`).classList.add("bg-active");
                    })
                    }
                    if(array[2] != undefined)
                    {
                        Tone.loaded().then(() => {
                        //@ts-ignore               
                        sampler3.triggerAttackRelease(array[2],"8n");
                        //@ts-ignore
                         document.getElementById(`${array[2]}/${position.place}`).classList.add("bg-active");
                    })
                    }
                    await sleep(position.length);
                    console.log("done");
                }
                isPlaying = false;
                let alles = document.querySelectorAll(".bg-active");
                //@ts-ignore
                for(let klas of alles)
                {
                    klas.classList.remove('bg-active');
                }
            }
        },
    toggleLength(){
        if(this.state.length){
            this.state.length = false;
            //@ts-ignore
            this.$refs.length.classList.add("opacity-0");
        }else{
            this.state.length = true;
            //@ts-ignore
            this.$refs.length.classList.remove("opacity-0");
        }
    },
    saveMessage(){
        this.state.save = true;
    },
    goneSave(){
        this.state.save = false;
    }
},
setup(){
        const state = reactive({
            data: [],
            length:false,
            save:false

        });
        return{
        state,
        }
    },
    async created(){
        let response = await axios.get(`SMSong/onesong/${localStorage.getItem("userId")}/${localStorage.getItem("songName")}`)
        this.state.data = response.data;
        localStorage.setItem("instrumentId",response.data.instruments[0].instrumentId)
    },
    async mounted(){    
        var rows = document.querySelectorAll(".noterow");
        for(let a = 0;a < 14; a++)
        {
        //@ts-ignore
            for(let i = 1;i <= (this.state.data.length); i++)
            {
                    //@ts-ignore
                    rows[a].innerHTML += `<div class="h-7 min-w-8 flex justify-center items-center"><input id="${dict[14-a]}/${i}" @change="() =>  updateTone('c1',1)" class="note" type="checkbox">
                    </div>`;
                    
                    if(a == 0)
                    {
                        var body =
                    {
                        length:500,
                        Place:i,
                        UserId: localStorage.getItem("userId")
                    }
                    await axios.post(`SMSong/AddPosition/${localStorage.getItem("songName")}/${localStorage.getItem("instrumentId")}`, body);
                    }
                    
                    
            }
        }
         for(let a = 0;a < 14; a++)
        {
        //@ts-ignore
            for(let i = 1;i <= (this.state.data.length); i++)
            {
                   
                    //@ts-ignore
                    document.getElementById(`${dict[14-a]}/${i}`).addEventListener('change', async function() {
                        //@ts-ignore
                        if (this.checked) {
                            var body = {
                                UserId: localStorage.getItem("userId"),
                                //@ts-ignore
                                Pitch: dict[14-a]
                            }
                            let response = await axios.post(`SMSong/AddTone/${localStorage.getItem("songName")}/${localStorage.getItem("instrumentId")}/${i}`,body);
                            console.log(response);
                        } else {
                            var body = {
                                UserId: localStorage.getItem("userId"),
                                //@ts-ignore
                                Pitch: dict[14-a]
                            }
                            let response = await axios.post(`SMSong/RemoveTone/${localStorage.getItem("songName")}/${localStorage.getItem("instrumentId")}/${i}`,body);
                            console.log(response);
                        }
                    });
                  
            }
        }
        let lengthRow = document.querySelector(".lengthRow");
        console.log("lengthRow");
        for(let i = 1;i <= (this.state.data.length); i++)
        {
            //@ts-ignore
            lengthRow.innerHTML += ` <select class="w-8 " name="length" id="L/${i}">
                <option value="250">s</option>
                <option value="500" selected>m</option>
                <option value="1000">l</option>
            </select>`;
        };
        for(let i = 1;i <= (this.state.data.length); i++)
        {
            //@ts-ignore
            document.getElementById(`L/${i}`).addEventListener('change', async function() {
                //@ts-ignore
                console.log(this.value);
                let body = {
                    UserId: localStorage.getItem('userId'),
                    //@ts-ignore
                    Length: +this.value,
                    Place: +i
                }
                let response = await axios.post(`SMSong/ChangePosition/${localStorage.getItem('songName')}/${localStorage.getItem('instrumentId')}`,body);
                console.log(response);
            });
        }
        var notes = await axios.get(`SMSong/onesong/${localStorage.getItem("userId")}/${localStorage.getItem("songName")}`)
        let positions = notes.data.instruments[0].positions;
        for(let position of positions)
        {
            let dink = `L/${position.place}`;
            if(+position.length == 250)
            {
                 //@ts-ignore
                document.getElementById(dink).selectedIndex  = 0;
            }
            if(+position.length == 500)
            {
               
                 //@ts-ignore
                document.getElementById(dink).selectedIndex  = 1;
            }
            if(+position.length == 1000)
            {
                 
                 //@ts-ignore
                document.getElementById(dink).selectedIndex  = 2;
            }
           
            for(let note of position.tones)
            {
                let dink = `${note.pitch}/${position.place}`;
                //@ts-ignore
                document.getElementById(dink).checked = true;
            }
        }            
    }
});
</script>

<style>

.note{
    all:unset;
    background-color: #e6aabb;
    height: 1rem;
    width: 1rem;
    display: block;
    border-radius: 50%
}

.note:checked{
    background-color: #3F96F2;
}
.bg-active{
    background-color: #FFD163 !important;
}
.min-w-8{
    min-width: 32px;
}

</style>

