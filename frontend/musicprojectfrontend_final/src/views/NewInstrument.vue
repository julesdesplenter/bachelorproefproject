<template>
<div class="h-screen">
<Header title="SM"></Header>
<div class="grid grid-cols-3 h-5/6">
    <div @click="() => addInstrument('piano')" class="cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-1 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">piano</p>
            
    </div>
    <div @click="() => addInstrument('guitar')" class=" cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-2 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">guitar</p>
            
    </div>
    <div @click="() => addInstrument('drum')" class="cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-3 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">drum</p>
            
    </div>
    <div @click="() => addInstrument('violin')" class="cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-4 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">violin</p>
            
    </div>
    <div @click="() => addInstrument('synth')" class="cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-5 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">synth</p>
            
    </div>
    <div @click="() => addInstrument('trumpet')" class="cursor-pointer flex flex-col items-center justify-center hover:opacity-70">
        <div class="bg-6 w-2/3 h-4/6">
            
        </div>
        <p class="text-white mt-2 text-lg">trumpet</p>
            
    </div>
</div>
    </div>

</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import axios from 'axios';
import Header from '../components/Header.vue';


export default defineComponent({
    components:{
    Header
},
data(){

},
methods:{
    async addInstrument(name:string)
    {
        var body = {
            Userid: localStorage.getItem("userId"),
            Name:name
        }
        let response = await axios.post("SMSong/AddInstrument/" + localStorage.getItem("songName"),body);
        localStorage.setItem("instrument",name)
        this.$router.push("MakeSong");
    }
}
});
</script>

<style>
 .bg-1{
     background: linear-gradient(
      rgba(255,209,99,0.76), 
     rgba(255,209,99,0.76)
    ),
    /* bottom, image */
    url("../assets/piano.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 .bg-2{
     background: linear-gradient(
      rgba(245,147,175,0.82), 
     rgba(245,147,175,0.82)
    ),
    /* bottom, image */
    url("../assets/guitar.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 .bg-3{
     background: linear-gradient(
      rgba(63,150,242,0.76), 
     rgba(63,150,242,0.76)
    ),
    /* bottom, image */
    url("../assets/drum.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 .bg-4{
     background: linear-gradient(
      rgba(63,150,242,0.76), 
     rgba(63,150,242,0.76)
    ),
    /* bottom, image */
    url("../assets/violin.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 .bg-5{
     background: linear-gradient(
      rgba(255,209,99,0.76), 
     rgba(255,209,99,0.76)
    ),
    /* bottom, image */
    url("../assets/synth.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 .bg-6{
     background: linear-gradient(
      rgba(245,147,175,0.82), 
     rgba(245,147,175,0.82)
    ),
    /* bottom, image */
    url("../assets/trumpet.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
 }

 
</style>

