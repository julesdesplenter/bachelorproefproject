<template>
<div class="h-screen">
<Header title="UP"></Header>
<div class="w-full flex flex-wrap justify-center mt-8 text-white">
    <div class="w-4/5 grid grid-cols-2 justify-start">
        <p class="text-left font-bold border-b-2">Name</p>
        <p class="text-left font-bold border-b-2">Edit</p>
    </div>
    <div class="w-4/5 grid grid-cols-2 justify-start" v-for="item in state.songs" :key="item.userId">
        <p v-show="state.songs.length <= 0" class="text-left mt-2">no songs found yet</p>
        <p  class="text-left mt-2" >
            {{ item.name }}
        </p>
        <div class="flex">
            <router-link @click="() => editSong(item.name)" class="underline pr-2 hover:opacity-70" to="/EditSong">Edit</router-link>
            <p  > |</p>
            <router-link :key="item.userId" @click="() => deleteSong(item.name)" class="underline pl-2 text-pinkDark hover:opacity-70" to="/UP">Delete</router-link>
        </div>
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
setup(){
        const state = reactive({
			songs: []
        });
        return{
        state
        }
    },
data(){
},
methods:{
    async deleteSong(name:string)
    {
        let response = await axios.delete(`Blob/${localStorage.getItem("userId")}/${name}`);
        console.log(response);
        window.location.reload();
    },
     editSong(name:string){
            console.log("whut")
            localStorage.setItem('songName',name);
        }
},
async created(){
        let response = await axios.get("Blob/AllSongs/" + localStorage.getItem("userId"));
        const stringResponse = JSON.stringify(response.data)
      const parsed = JSON.parse(stringResponse)        
        this.state.songs = parsed;
        console.log(this.state.songs);
    }
});
</script>

