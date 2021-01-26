<template>
  <div class="h-screen w-full flex flex-collumn justify-center items-center">
    <div class="w-2/5 bg-white h-2/3">
      <div class="p-8 w-5/6 items-start justify-center flex flex-col h-full">
        <h1 class="text-5xl h-16">sign in</h1>
        <p v-show="signedUp">Signed up succesfull sign in to continue</p>
        <p class="text-left text-red-500" v-show="FailedSignin">Wrong username or password</p>
        <p class="text-left text-red-500" v-show="FailedSignup">Username already taken</p>
        <form class="flex flex-col text-left"  @submit.prevent="handleSubmit">
          <label for="Username" class="w-full mt-4">Username</label>
          <input v-model="userName" type="Username" class="px-2 border border-gray-500">
           <label v-show="showEmail" for="Email" class="w-full mt-4">Email</label>
          <input v-model="Email" v-show="showEmail" type="Email" class="px-2 border border-gray-500">
          <label for="Password" class="w-full mt-4">Password</label>
          <input v-model="password" type="password" class="px-2 border border-gray-500">
          <button v-show="!showEmail" @click="login" class="mt-6 border-2 text-pinkDark border-pinkLight ">sign in</button>
          <button @click="showSignup" class="mt-4 border-2 border-pinkLight  bg-pinkLight text-white ">sign up</button>
        </form>
      </div>
    </div>
    <div class="w-1/5 bg-picture  h-2/3"></div>
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';
import axios from 'axios'

export default defineComponent({
  data(){
    return{
      showEmail: false,
      signedUp:false,
      FailedSignin: false,
      FailedSignup: false,
      userName: "",
      Email:"",
      password: ""
    }
  },
  methods:{
    async showSignup(){
      if(this.showEmail == false)
      {
        this.FailedSignin = false;
        this.showEmail = true;
      }
      else
      {
        var body = {
          UserName: this.userName,
          Email: this.Email,
          Password:this.password
        }
        try{
          var response = await axios.post('user/signup', body);
          console.log(response);
          if(response.statusText == "OK")
          {
            this.FailedSignup = false;
            this.signedUp = true,
            this.showEmail = false
          }
        }
       catch
        {
          this.FailedSignup = true;
        }
      }
    },
    async login(){
      var body = {
          UserName: this.userName,
          Password:this.password
        }
        var response = await axios.post('user/login', body);
        console.log(response.data);
        if(!(response.data.user.user == undefined))
        {
          this.FailedSignin = false;
          localStorage.setItem("userId",response.data.user.user);
          localStorage.setItem("token",response.data.token.token);
          this.$router.push("SM")

        }else
        {
          this.FailedSignin = true;
     }
    }
  }
});
 </script>

 <style lang="css">

.bg-picture{
  background: linear-gradient(
      rgba(245,147,175,0.82), 
     rgba(245,147,175,0.82)
    ),
    /* bottom, image */
    url("../assets/casette.jpg");
  background-position: center;
  background-repeat: no-repeat; 
  background-size: cover;
}

 </style>