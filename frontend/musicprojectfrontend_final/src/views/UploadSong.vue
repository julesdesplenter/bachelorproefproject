<template>
<div class="h-screen">
<Header title="UP"></Header>
  <div class="h-5/6 w-full flex flex-collumn justify-center items-center">      
    <div class="w-2/5 bg-white h-2/3">
      <div class="p-8 w-5/6 items-start justify-center flex flex-col h-full">
        <h1 class="text-5xl h-16">Upload song</h1>
        <form class="flex flex-col text-left"  @submit.prevent="handleSubmit">
          <label for="Song" class="w-full mt-4">Song</label>
          <input id="song-file" type="file" class="px-2 border border-gray-500" required>
          <button @click="uploadSong" v-show="!loading" class="mt-4 border-2 border-blue bg-blue text-white rounded-xl">make song</button>
          <p v-show="loading">loading...</p>
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
      loading: false
     
    }
  },
  methods:{
    async uploadSong(){
        this.loading = true;
        //@ts-ignore
        let song = document.getElementById("song-file").files[0];
        let formData = new FormData();
        formData.append("asset", song);
        let response = await axios.post("Blob/insertfile/" + localStorage.getItem("userId"),formData);        
        localStorage.setItem("songName",song.name);
        this.$router.push("EditSong");
  }
}});
 </script>

 <style lang="css">

.bg-picture{
  background: linear-gradient(
      rgba(63,150,242,0.86), 
     rgba(63,150,242,0.86)
    ),
    /* bottom, image */
    url("../assets/uploadsong.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
}

 </style>