<template>
<div class="h-screen">
<Header title="SM"></Header>
  <div class="h-5/6 w-full flex flex-collumn justify-center items-center">      
    <div class="w-2/5 bg-white h-2/3">
      <div class="p-8 w-5/6 items-start justify-center flex flex-col h-full">
        <h1 class="text-5xl h-16">Make song</h1>
        <form class="flex flex-col text-left"  @submit.prevent="handleSubmit">
          <label for="Name" class="w-full mt-4">Name</label>
          <input v-model="Name" type="Username" class="px-2 border border-gray-500" required>
           <label for="Length" min="1" max="45" class="w-full mt-4">Length</label>
          <input v-model="Length" type="number" class="px-2 border border-gray-500" required>
          <button class="mt-4 border-2 border-yellow bg-yellow text-white rounded-xl">make song</button>
        </form>
      </div>
    </div>
    <div class="w-1/5 bg-picture  h-2/3"></div>
  </div>
</div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import axios from 'axios'
import Header from '../components/Header.vue';

export default defineComponent({
components:{
    Header
},
  data(){
    return{
 
      Name: "",
      Length:""
    }
  },
  methods:{
    async handleSubmit(){
        let body = {
            UserId: localStorage.getItem("userId"),
            Name:this.Name,
            Length: +this.Length
        }
        var response = await axios.post("SMSong",body);
        console.log(response);
        localStorage.setItem("songName",this.Name);
        this.$router.push("NewInstrument");
    }
  }
});
 </script>

 <style lang="css">

.bg-picture{
  background: linear-gradient(
      rgba(255,209,99,0.86), 
     rgba(255,209,99,0.86)
    ),
    /* bottom, image */
    url("../assets/newSong.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
}

 </style>